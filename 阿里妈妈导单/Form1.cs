using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Threading;

namespace 阿里妈妈导单
{
    public partial class Form1 : Form
    {
        private string logAdd = "runLog.txt";//日志地址

        private string acc;//当前处理的账户
        private string importUrl= ConfigHelper.GetAppConfig("importUrl");//后台请求地址
        private List<string> accList = new List<string>();//账户列表
        private int ifHanddleStart = 0;//手动导单是否开始
        private int ifProsseStart = 0;//是否已经有线程在导单
        public Form1()
        {   
            InitializeComponent();
            loadConfig();
        }
        //加载配置
        private void loadConfig() {
            //设置和修改程序标题加上账户信息
            this.Text = ConfigHelper.GetAppConfig("AppName")+"_"+ ConfigHelper.GetAppConfig("acc");
            acc = ConfigHelper.GetAppConfig("acc");
            DateTimePicker_start.CustomFormat = "yyyy年MM月dd日HH时";
            DateTimePicker_start.Value= DateTime.Now.AddHours(-1);
            DateTimePicker_end.CustomFormat = "yyyy年MM月dd日HH时";
            DateTimePicker_end.Value = DateTime.Now;
            //搜索账户信息添加到list
            try
            {
                DataTable accs = Mysqler.Get_DataTable("SELECT * FROM `fanli_taopid` WHERE `if_ok` = 1;", Mysqler.ConnStr, "xfz178_com");
                foreach (DataRow dr in accs.Rows)
                {
                    accList.Add(dr[2].ToString());
                }
                int count = 0;
                foreach (string value in accList)
                {

                    if (count == 0) {
                        ComboBox_acc.Text = value;
                        acc = value;
                    }
                    ComboBox_acc.Items.Add(value);
                    count += 1;
                }
                string start_time = DateTimePicker_start.Value.ToString("yyyy-MM-dd HH:mm:00");
                string end_time = DateTimePicker_end.Value.ToString("yyyy-MM-dd HH:mm:00");
                string page = TextBox_page.Text;
                TextBox_url.Text = importUrl + "start_time=" + start_time + "&order_query_type=create_time&page_no=" + page + "&acc=" + acc;//订单创建
            }
            catch (Exception) {
            }
            
        }
        //每分钟导单
        private void timer_fz_Tick(object sender, EventArgs e)
        {
            DateTime Strtime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:00"));
            //将当前日期减两分钟
            Strtime = Strtime.AddMinutes(-2);
            string start_time = Strtime.ToString("yyyy-MM-dd HH:mm:00");
            //运行分钟数
            int fzs;
            if (int.Parse(fz_time.Text) + 1 == 60)
            {
                fzs = 0;
            }
            else
            {
                fzs = int.Parse(fz_time.Text) + 1;
            }
            fz_time.Text = Convert.ToString(fzs);
        }
        //每小时导单导上一个小时的
        private void timer_xs_Tick(object sender, EventArgs e)
        {
            //运行小时数
            int xss;
            if (int.Parse(xs_time.Text) + 1 == 24)
            {
                xss = 0;
            }
            else
            {
                xss = int.Parse(xs_time.Text) + 1;
            }
            xs_time.Text = Convert.ToString(xss);
        }
        //每天导单
        private void timer_day_Tick(object sender, EventArgs e)
        {
            DateTime Strtime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 00:00:00"));
            //将当前日期减两分钟
            Strtime = Strtime.AddDays(-30);
            string start_time = Strtime.ToString("yyyy-MM-dd HH:mm:00");
            //凌晨一点开始运行
            string hourTime = DateTime.Now.ToString("HH");
            if (hourTime == "00")
            {
                //运行天数
                int days;
                days = int.Parse(day_time.Text) + 1;
                day_time.Text = Convert.ToString(days);
            }

        }

        private void hanndleStart(object sender, EventArgs e) {
            if (ifProsseStart==0)
            {
                ifHanddleStart = 1;
                string start_time = DateTimePicker_start.Value.ToString("yyyy-MM-dd HH:mm:00");
                //计算开始和结束时间相差的分钟数
                DateTime startTime = Convert.ToDateTime(DateTimePicker_start.Value.ToString("yyyy-MM-dd HH:mm:00"));
                DateTime endTime = Convert.ToDateTime(DateTimePicker_end.Value.ToString("yyyy-MM-dd HH:mm:00"));
                TimeSpan ts = endTime - startTime;
                string days = ts.Days.ToString();
                string fz = ts.Minutes.ToString();
                string xs = ts.Hours.ToString();
                int totalfz = int.Parse(days) * 1440 + int.Parse(xs) * 60 + int.Parse(fz);
                int times = totalfz / 20;
                if (times < 0)
                {
                    MessageBox.Show("时间选择有误");
                    return;
                }
                string page = TextBox_page.Text;
                acc = ComboBox_acc.Text;
                string getUrl = importUrl + "start_time=" + start_time + "&order_query_type=create_time&page_no=" + page + "&acc=" + acc;//订单创建
                                                                                                                                         //定义参数,导入创建时间订单 
                GroupBox1.Visible = false;
                out_text.Visible = true;
                //导入创建时间订单
                var send = new object[4];
                send[0] = start_time;
                send[1] = 1;//page参数
                send[2] = 1;//订单类别
                send[3] = 3;//请求次数
                beginImportPress(send);
            }
            else
            {
                GroupBox1.Visible = true;
                out_text.Visible = false;
            }
            
        }
        //每分钟导入订单函数
        private void doImortTrade(string start_time,int page,int tradeType, DoWorkEventArgs e,BackgroundWorker bgWorker)
        {
            var getUrl = "";
            var tradeTypeStr = "";
            switch (tradeType)
            {
                case 1: getUrl = importUrl + "start_time=" + start_time + "&order_query_type=create_time&page_no=" + page + "&acc=" + acc;//订单创建
                    tradeTypeStr = "创建订单";
                    break;
                case 2: getUrl = importUrl + "start_time=" + start_time + "&order_query_type=settle_time&page_no=" + page + "&acc=" + acc;//计算订单
                    tradeTypeStr = "结算订单";
                    break;
            }
            try
            {//请求服务器
                Console.WriteLine(getUrl);
                string re = HttpRequestHelper.HttpGetRequest(getUrl);
                Console.WriteLine(re);
                ReObject Resault = JsonConvert.DeserializeObject<ReObject>(re);
                string ifEnd = Resault.ifEnd;
                string code = Resault.code;
                if (code == "-1")
                {
                    //报错
                    string result = Resault.data;
                    var send = new object[2];
                    send[0] = code;
                    send[1] = result;
                    //e.Result = send;汇报结束
                    bgWorker.ReportProgress(1, send);
                }
                else
                {
                    if (ifEnd == "1")
                    {
                        //结束
                        string result = Resault.startTime + " " + tradeTypeStr + "P" + page + ": 共" + Resault.totalNum + "单,插入" + Resault.newNum + "单,更新" + Resault.updateNum + "单";
                        var send = new object[2];
                        send[0] = code;
                        send[1] = result;
                        //e.Result = send;
                        bgWorker.ReportProgress(1, send);
                    }
                    else
                    {
                        //下一页
                        string result = Resault.startTime + " " + tradeTypeStr + "P" + page + ": 共" + Resault.totalNum + "单,插入" + Resault.newNum + "单,更新" + Resault.updateNum + "单";
                        var send = new object[2];
                        send[0] = code;
                        send[1] = result;
                        //e.Result = send;
                        bgWorker.ReportProgress(1, send);
                        // handleResult(code, result);
                        doImortTrade(start_time, page + 1, tradeType, e, bgWorker);
                    }
                }
            }catch(Exception )
            {
                var send = new object[2];
                send[0] = "-1";
                send[1] = "请求服务器错误";
                //e.Result = send;
                bgWorker.ReportProgress(1, send);
            }
            
        }
        /**
         * 导入订单可以指定导入多少次,每次导入20分钟的
         * doTimes导入次数
         * */
        private void doImortTrade1(string start_time, int page, int tradeType,int doTimes, DoWorkEventArgs e, BackgroundWorker bgWorker)
        {
            var getUrl = "";
            var tradeTypeStr = "";
            switch (tradeType)
            {
                case 1:
                    getUrl = importUrl + "start_time=" + start_time + "&order_query_type=create_time&page_no=" + page + "&acc=" + acc + "&span=1200";//订单创建
                    tradeTypeStr = "创建订单";
                    break;
                case 2:
                    getUrl = importUrl + "start_time=" + start_time + "&order_query_type=settle_time&page_no=" + page + "&acc=" + acc + "&span=1200";//计算订单
                    tradeTypeStr = "结算订单";
                    break;
            }
            try {
                Console.WriteLine(getUrl);
                string re = HttpRequestHelper.HttpGetRequest(getUrl);
                Console.WriteLine(re);
                ReObject Resault = JsonConvert.DeserializeObject<ReObject>(re);
                string ifEnd = Resault.ifEnd;
                string code = Resault.code;
                if (doTimes >= 0)
                {
                    if (code == "-1")
                    {
                        //报错
                        string result = Resault.data;
                        var send = new object[2];
                        send[0] = code;
                        send[1] = result;
                        //e.Result = send;汇报结束
                        bgWorker.ReportProgress(1, send);
                    }
                    else
                    {
                        if (ifEnd == "1")
                        {
                            doTimes = doTimes - 1;
                            //结束
                            string result = Resault.startTime + " " + tradeTypeStr + "P" + page + ": 共" + Resault.totalNum + "单,插入" + Resault.newNum + "单,更新" + Resault.updateNum + "单";
                            var send = new object[2];
                            send[0] = code;
                            send[1] = result;
                            //e.Result = send;
                            bgWorker.ReportProgress(1, send);
                            //handleResult(code, result);
                            //增加20分钟继续
                            DateTime t1 = Convert.ToDateTime(Resault.startTime);
                            t1 = t1.AddMinutes(20);
                            string t2 = t1.ToString("yyyy-MM-dd HH:mm:00");
                            doImortTrade1(t2, 1, tradeType, doTimes, e, bgWorker);
                        }
                        else
                        {
                            //下一页
                            string result = Resault.startTime + " " + tradeTypeStr + "P" + page + ":  共" + Resault.totalNum + "单,插入" + Resault.newNum + "单,更新" + Resault.updateNum + "单";
                            var send = new object[2];
                            send[0] = code;
                            send[1] = result;
                            //e.Result = send;
                            bgWorker.ReportProgress(1, send);
                            //handleResult(code, result);
                            doImortTrade1(start_time, page + 1, tradeType, doTimes, e, bgWorker);
                        }
                    }
                }
            }
            catch (Exception) {
                var send = new object[2];
                send[0] = "-1";
                send[1] = "链接服务器出错";
                //e.Result = send;
                bgWorker.ReportProgress(1, send);
            }
            
        }
    

      
        //写入log
        public void WriteLog(string str)
        {
            try
            {
                FileStream fs = new FileStream(logAdd, FileMode.Create);
                //获得字节数组
                byte[] data = System.Text.Encoding.Default.GetBytes(str);
                //开始写入
                fs.Write(data, 0, data.Length);
                //清空缓冲区、关闭流
                fs.Flush();
                fs.Close();
            }
            catch (Exception)
            {

            }
            
        }
        //解析json使用
        public class ReObject
        {
            public string totalNum { get; set; }
            public string newNum { get; set; }
            public string updateNum { get; set; }
            public string code { get; set; }
            public string startTime { get; set; }
            public string endTime { get; set; }
            public string ifEnd { get; set; }
            public string data { get; set; }
        }
     
        //开启导单进程
        void beginImportPress(object send) {
            using (BackgroundWorker bw = new BackgroundWorker())
            {
                //开始背景线程
                bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);//线程结束时汇报状态
                bw.WorkerReportsProgress = true;
                bw.ProgressChanged += bw_ProgressChanged;
                bw.DoWork += new DoWorkEventHandler(bw_DoWork);
                bw.RunWorkerAsync(send);
            }
        }
        //定义导单的后台工作
        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            if (ifProsseStart == 1) {
                MessageBox.Show("正在进行任务");
                
                return;
            }
            ifProsseStart = 1;
            BackgroundWorker bgWorker = sender as BackgroundWorker;//定义一个后台汇报进度的进程
            var receive = e.Argument as object[];
            string start_time = (string)receive[0];
            int page = (int)receive[1];
            int tradeType = (int)receive[2];
            int doTimes = (int)receive[3];
            if (doTimes==-1)
            {
                doImortTrade(start_time, page, tradeType, e, bgWorker);
            }
            else
            {
                doImortTrade1(start_time, page, tradeType,doTimes, e, bgWorker);
            }
            
        }
        //导单后台进程结束时调用,没有使用
        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //这时后台线程已经完成，并返回了主线程，所以可以直接使用UI控件了 
            ifProsseStart = 0;
           
        }
        //导单后台进程运行时调用
        void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //这时后台线程已经完成，并返回了主线程，所以可以直接使用UI控件了 
            var receive = e.UserState as object[];

            string code = (string)receive[0];
            string info = (string)receive[1];

            Console.WriteLine(code);

            if (code == "-1")
            {
                if (out_text.Text == "")
                {
                    out_text.Text = info;
                    WriteLog(info);
                }
                else
                {
                    out_text.Text = info + System.Environment.NewLine + out_text.Text;
                    WriteLog(info + System.Environment.NewLine + out_text.Text);
                }
            }
            else
            {
                if (out_text.Text == "")
                {
                    out_text.Text = info;
                    WriteLog(info);
                }
                else
                {
                    out_text.Text = info + System.Environment.NewLine + out_text.Text;
                    WriteLog(info + System.Environment.NewLine + out_text.Text);
                }
            }
        }

        //测试按钮
        private void button2_Click(object sender, EventArgs e)
        {
            
            DateTime Strtime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 00:00:00"));
            //将当前日期减两分钟
            Strtime = Strtime.AddDays(-30);
            string start_time = Strtime.ToString("yyyy-MM-dd HH:mm:00");
            //凌晨一点开始运行
            string hourTime = DateTime.Now.ToString("HH");
            if (hourTime == "00")
            {
                //运行天数
                int days;
                days = int.Parse(day_time.Text) + 1;
                day_time.Text = Convert.ToString(days);
                //导入创建时间订单
                var send = new object[4];
                send[0] = start_time;
                send[1] = 1;//page参数
                send[2] = 1;//订单类别
                send[3] = 2160;//请求次数
                beginImportPress(send);

                //导入结算时间订单
                var send1 = new object[4];
                send1[0] = start_time;
                send1[1] = 1;//参数
                send1[2] = 2;//订单类别
                send1[3] = 2160;//请求次数
                beginImportPress(send1);
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void out_text_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            GroupBox1.Visible = false;
            out_text.Visible = true;
            DateTime Strtime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 00:00:00"));
            //将当前日期减两分钟
            Strtime = Strtime.AddDays(-1);
            string start_time = Strtime.ToString("yyyy-MM-dd HH:mm:00");
            //凌晨一点开始运行
            string hourTime = DateTime.Now.ToString("HH");
            if (hourTime == "00")
            {
                //运行天数
                int days;
                days = int.Parse(day_time.Text) + 1;
                day_time.Text = Convert.ToString(days);
            }
        }
    }
        

}

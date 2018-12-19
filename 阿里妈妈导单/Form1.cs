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

        private string acc;
        private string importUrl= ConfigHelper.GetAppConfig("importUrl");
        public Form1()
        {   
            InitializeComponent();
            loadConfig();
        }
        //加载配置
        private void loadConfig() {
            this.Text = ConfigHelper.GetAppConfig("AppName")+"_"+ ConfigHelper.GetAppConfig("acc");
            acc = ConfigHelper.GetAppConfig("acc");
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
            //定义参数,导入创建时间订单
            var send = new object[4];
            send[0] = start_time;
            send[1] = 1;//page参数
            send[2] = 1;//订单类别
            send[3] = -1;
            beginImportPress(send);
            //定义参数,导入结算时间订单
            var send1 = new object[4];
            send1[0] = start_time;
            send1[1] = 1;//page参数
            send1[2] = 2;//订单类别11
            send1[3] = -1;
            beginImportPress(send1);
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
            //触发导单
            DateTime Strtime = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:00:00"));
            //将当前日期减两分钟
            Strtime = Strtime.AddMinutes(-60);
            string start_time = Strtime.ToString("yyyy-MM-dd HH:mm:00");
            //导入创建时间订单
            var send = new object[4];
            send[0] = start_time;
            send[1] = 1;//page参数
            send[2] = 1;//订单类别
            send[3] = 3;//请求次数
            beginImportPress(send);

            //导入结算时间订单
            var send1 = new object[4];
            send1[0] = start_time;
            send1[1] = 1;//参数
            send1[2] = 2;//订单类别
            send1[3] = 3;//请求次数
            beginImportPress(send1);
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
                try
                {
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
                }catch(Exception e2)
                {
                    var send = new object[2];
                    send[0] = "-1";
                    send[1] = re;
                    //e.Result = send;
                    bgWorker.ReportProgress(1, send);
                }
                
            }catch(Exception eo)
            {
                var send = new object[2];
                send[0] = "-1";
                send[1] = "请求服务器错误:"+ eo.Message;
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
                try
                {
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
                }catch(Exception e2)
                {
                    var send = new object[2];
                    send[0] = "-1";
                    send[1] = "链接服务器出错" + re;
                    //e.Result = send;
                    bgWorker.ReportProgress(1, send);
                }
                
            }
            catch (Exception e1) {
                var send = new object[2];
                send[0] = "-1";
                send[1] = "链接服务器出错"+e1.Message;
                //e.Result = send;
                bgWorker.ReportProgress(1, send);
            }
            
        }
        
        //开始菜单
        private void begin(object sender, EventArgs e)
        {
            timer_fz.Enabled = true;
            timer_xs.Enabled = true;
            timer_day.Enabled = true;
        }
        //停止菜单
        private void over(object sender, EventArgs e)
        {
            timer_fz.Enabled = false;
            timer_xs.Enabled = false;
            timer_day.Enabled = false;
        }
        //设置账户菜单
        private void changAcc(object sender, EventArgs e)
        {
            group_acc.Visible = true;
            text_acc.Text = acc;
            timer_fz.Enabled = false;
            timer_xs.Enabled = false;
            timer_day.Enabled = false;
        }

        //设置账户
        private void acc_ok_Click(object sender, EventArgs e)
        {
            
            acc = text_acc.Text;
            this.Text= ConfigHelper.GetAppConfig("AppName") + "_" + acc;
            ConfigHelper.UpdateAppConfig("acc", acc);
            group_acc.Visible = false;
            timer_fz.Enabled = true;
            timer_xs.Enabled = true;
            timer_day.Enabled = true;

        }
        //取消设置账户
        private void acc_cancel_Click(object sender, EventArgs e)
        {
            group_acc.Visible = false;
            timer_fz.Enabled = true;
            timer_xs.Enabled = true;
            timer_day.Enabled = true;
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
                // bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);//线程结束时汇报状态
                bw.WorkerReportsProgress = true;
                bw.ProgressChanged += bw_ProgressChanged;
                bw.DoWork += new DoWorkEventHandler(bw_DoWork);
                bw.RunWorkerAsync(send);
            }
        }
        //定义导单的后台工作
        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
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
            var receive = e.Result as object[];

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
    }
        

}

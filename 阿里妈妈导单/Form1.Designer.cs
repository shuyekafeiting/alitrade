namespace 阿里妈妈导单
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer_fz = new System.Windows.Forms.Timer(this.components);
            this.out_text = new System.Windows.Forms.TextBox();
            this.statu = new System.Windows.Forms.Label();
            this.timer_xs = new System.Windows.Forms.Timer(this.components);
            this.timer_day = new System.Windows.Forms.Timer(this.components);
            this.day_time = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.xs_time = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.fz_time = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.ComboBox_acc = new System.Windows.Forms.ComboBox();
            this.DateTimePicker_end = new System.Windows.Forms.DateTimePicker();
            this.DateTimePicker_start = new System.Windows.Forms.DateTimePicker();
            this.TextBox_page = new System.Windows.Forms.TextBox();
            this.TextBox_url = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Button4 = new System.Windows.Forms.Button();
            this.Button3 = new System.Windows.Forms.Button();
            this.button_start = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer_fz
            // 
            this.timer_fz.Enabled = true;
            this.timer_fz.Interval = 60000;
            this.timer_fz.Tick += new System.EventHandler(this.timer_fz_Tick);
            // 
            // out_text
            // 
            this.out_text.BackColor = System.Drawing.Color.White;
            this.out_text.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.out_text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.out_text.Location = new System.Drawing.Point(5, 7);
            this.out_text.Margin = new System.Windows.Forms.Padding(30, 10, 10, 30);
            this.out_text.Multiline = true;
            this.out_text.Name = "out_text";
            this.out_text.ReadOnly = true;
            this.out_text.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.out_text.Size = new System.Drawing.Size(372, 277);
            this.out_text.TabIndex = 1;
            this.out_text.Visible = false;
            this.out_text.TextChanged += new System.EventHandler(this.out_text_TextChanged);
            // 
            // statu
            // 
            this.statu.AutoSize = true;
            this.statu.Location = new System.Drawing.Point(12, 292);
            this.statu.Name = "statu";
            this.statu.Size = new System.Drawing.Size(47, 12);
            this.statu.TabIndex = 2;
            this.statu.Text = "已运行:";
            // 
            // timer_xs
            // 
            this.timer_xs.Enabled = true;
            this.timer_xs.Interval = 3600000;
            this.timer_xs.Tick += new System.EventHandler(this.timer_xs_Tick);
            // 
            // timer_day
            // 
            this.timer_day.Enabled = true;
            this.timer_day.Interval = 3600000;
            this.timer_day.Tick += new System.EventHandler(this.timer_day_Tick);
            // 
            // day_time
            // 
            this.day_time.AutoSize = true;
            this.day_time.Location = new System.Drawing.Point(64, 292);
            this.day_time.Name = "day_time";
            this.day_time.Size = new System.Drawing.Size(11, 12);
            this.day_time.TabIndex = 3;
            this.day_time.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 292);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "天";
            // 
            // xs_time
            // 
            this.xs_time.AutoSize = true;
            this.xs_time.Location = new System.Drawing.Point(102, 292);
            this.xs_time.Name = "xs_time";
            this.xs_time.Size = new System.Drawing.Size(11, 12);
            this.xs_time.TabIndex = 5;
            this.xs_time.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(115, 292);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "小时";
            // 
            // fz_time
            // 
            this.fz_time.AutoSize = true;
            this.fz_time.Location = new System.Drawing.Point(148, 292);
            this.fz_time.Name = "fz_time";
            this.fz_time.Size = new System.Drawing.Size(11, 12);
            this.fz_time.TabIndex = 7;
            this.fz_time.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(162, 292);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "分钟";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(666, 39);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.GroupBox1.Controls.Add(this.Label6);
            this.GroupBox1.Controls.Add(this.ComboBox_acc);
            this.GroupBox1.Controls.Add(this.DateTimePicker_end);
            this.GroupBox1.Controls.Add(this.DateTimePicker_start);
            this.GroupBox1.Controls.Add(this.TextBox_page);
            this.GroupBox1.Controls.Add(this.TextBox_url);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.label1);
            this.GroupBox1.Controls.Add(this.label7);
            this.GroupBox1.Controls.Add(this.label8);
            this.GroupBox1.Controls.Add(this.label9);
            this.GroupBox1.Location = new System.Drawing.Point(14, 12);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(330, 264);
            this.GroupBox1.TabIndex = 11;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "输入参数";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(139, 132);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(17, 12);
            this.Label6.TabIndex = 11;
            this.Label6.Text = "页";
            // 
            // ComboBox_acc
            // 
            this.ComboBox_acc.FormattingEnabled = true;
            this.ComboBox_acc.Location = new System.Drawing.Point(105, 51);
            this.ComboBox_acc.Name = "ComboBox_acc";
            this.ComboBox_acc.Size = new System.Drawing.Size(122, 20);
            this.ComboBox_acc.TabIndex = 10;
            // 
            // DateTimePicker_end
            // 
            this.DateTimePicker_end.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTimePicker_end.Location = new System.Drawing.Point(105, 206);
            this.DateTimePicker_end.Name = "DateTimePicker_end";
            this.DateTimePicker_end.Size = new System.Drawing.Size(151, 21);
            this.DateTimePicker_end.TabIndex = 9;
            // 
            // DateTimePicker_start
            // 
            this.DateTimePicker_start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DateTimePicker_start.Location = new System.Drawing.Point(105, 167);
            this.DateTimePicker_start.MaxDate = new System.DateTime(9998, 1, 31, 0, 0, 0, 0);
            this.DateTimePicker_start.Name = "DateTimePicker_start";
            this.DateTimePicker_start.Size = new System.Drawing.Size(151, 21);
            this.DateTimePicker_start.TabIndex = 8;
            this.DateTimePicker_start.UseWaitCursor = true;
            this.DateTimePicker_start.Value = new System.DateTime(2018, 12, 7, 0, 0, 0, 0);
            // 
            // TextBox_page
            // 
            this.TextBox_page.Location = new System.Drawing.Point(105, 128);
            this.TextBox_page.Name = "TextBox_page";
            this.TextBox_page.Size = new System.Drawing.Size(23, 21);
            this.TextBox_page.TabIndex = 7;
            this.TextBox_page.Text = "1";
            // 
            // TextBox_url
            // 
            this.TextBox_url.Location = new System.Drawing.Point(105, 89);
            this.TextBox_url.Name = "TextBox_url";
            this.TextBox_url.Size = new System.Drawing.Size(167, 21);
            this.TextBox_url.TabIndex = 6;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(33, 212);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(59, 12);
            this.Label5.TabIndex = 4;
            this.Label5.Text = "结束时间:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "起始时间:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "起始页码:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(33, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "请求地址:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(33, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "选择账号:";
            // 
            // Button4
            // 
            this.Button4.Location = new System.Drawing.Point(388, 167);
            this.Button4.Name = "Button4";
            this.Button4.Size = new System.Drawing.Size(75, 23);
            this.Button4.TabIndex = 14;
            this.Button4.Text = "退出程序";
            this.Button4.UseVisualStyleBackColor = true;
            this.Button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // Button3
            // 
            this.Button3.Location = new System.Drawing.Point(388, 91);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(75, 23);
            this.Button3.TabIndex = 13;
            this.Button3.Text = "配置参数";
            this.Button3.UseVisualStyleBackColor = true;
            this.Button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(388, 15);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(75, 23);
            this.button_start.TabIndex = 12;
            this.button_start.Text = "开始运行";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.hanndleStart);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(388, 243);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 15;
            this.button6.Text = "订单检测";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 313);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.Button4);
            this.Controls.Add(this.Button3);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.fz_time);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.xs_time);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.day_time);
            this.Controls.Add(this.statu);
            this.Controls.Add(this.out_text);
            this.Controls.Add(this.button2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "阿里导单";
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer_fz;
        private System.Windows.Forms.Label statu;
        private System.Windows.Forms.Timer timer_xs;
        private System.Windows.Forms.Timer timer_day;
        private System.Windows.Forms.Label day_time;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label xs_time;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label fz_time;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        internal System.Windows.Forms.TextBox out_text;
        private System.Windows.Forms.Button button2;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.DateTimePicker DateTimePicker_end;
        internal System.Windows.Forms.DateTimePicker DateTimePicker_start;
        internal System.Windows.Forms.TextBox TextBox_page;
        internal System.Windows.Forms.TextBox TextBox_url;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Button Button4;
        internal System.Windows.Forms.Button Button3;
        internal System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ComboBox ComboBox_acc;
    }
}


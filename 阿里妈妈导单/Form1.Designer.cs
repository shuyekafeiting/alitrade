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
            this.out_text.Location = new System.Drawing.Point(0, 35);
            this.out_text.Margin = new System.Windows.Forms.Padding(30, 10, 10, 30);
            this.out_text.Multiline = true;
            this.out_text.Name = "out_text";
            this.out_text.ReadOnly = true;
            this.out_text.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.out_text.Size = new System.Drawing.Size(461, 419);
            this.out_text.TabIndex = 1;
            // 
            // statu
            // 
            this.statu.AutoSize = true;
            this.statu.Location = new System.Drawing.Point(0, 460);
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
            this.day_time.Location = new System.Drawing.Point(52, 460);
            this.day_time.Name = "day_time";
            this.day_time.Size = new System.Drawing.Size(11, 12);
            this.day_time.TabIndex = 3;
            this.day_time.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 460);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "天";
            // 
            // xs_time
            // 
            this.xs_time.AutoSize = true;
            this.xs_time.Location = new System.Drawing.Point(90, 460);
            this.xs_time.Name = "xs_time";
            this.xs_time.Size = new System.Drawing.Size(11, 12);
            this.xs_time.TabIndex = 5;
            this.xs_time.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(103, 460);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "小时";
            // 
            // fz_time
            // 
            this.fz_time.AutoSize = true;
            this.fz_time.Location = new System.Drawing.Point(136, 460);
            this.fz_time.Name = "fz_time";
            this.fz_time.Size = new System.Drawing.Size(11, 12);
            this.fz_time.TabIndex = 7;
            this.fz_time.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(150, 460);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "分钟";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(386, -1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 479);
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
    }
}


namespace Notifications
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.InterceptButton = new System.Windows.Forms.Button();
            this.HeroButton = new System.Windows.Forms.Button();
            this.ScheduleButton = new System.Windows.Forms.Button();
            this.AlarmButton = new System.Windows.Forms.Button();
            this.TextInputButton = new System.Windows.Forms.Button();
            this.SelectButton = new System.Windows.Forms.Button();
            this.DownLoadButton = new System.Windows.Forms.Button();
            this.StopScheduledNotificationButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InterceptButton
            // 
            this.InterceptButton.Location = new System.Drawing.Point(23, 257);
            this.InterceptButton.Name = "InterceptButton";
            this.InterceptButton.Size = new System.Drawing.Size(295, 29);
            this.InterceptButton.TabIndex = 6;
            this.InterceptButton.Text = "Intercept";
            this.InterceptButton.UseVisualStyleBackColor = true;
            this.InterceptButton.Click += new System.EventHandler(this.InterceptButton_Click);
            // 
            // HeroButton
            // 
            this.HeroButton.Location = new System.Drawing.Point(23, 47);
            this.HeroButton.Name = "HeroButton";
            this.HeroButton.Size = new System.Drawing.Size(295, 29);
            this.HeroButton.TabIndex = 0;
            this.HeroButton.Text = "Hero";
            this.HeroButton.UseVisualStyleBackColor = true;
            this.HeroButton.Click += new System.EventHandler(this.HeroButton_Click);
            // 
            // ScheduleButton
            // 
            this.ScheduleButton.Location = new System.Drawing.Point(23, 82);
            this.ScheduleButton.Name = "ScheduleButton";
            this.ScheduleButton.Size = new System.Drawing.Size(295, 29);
            this.ScheduleButton.TabIndex = 1;
            this.ScheduleButton.Text = "Schedule - in five seconds";
            this.ScheduleButton.UseVisualStyleBackColor = true;
            this.ScheduleButton.Click += new System.EventHandler(this.ScheduleButton_Click);
            // 
            // AlarmButton
            // 
            this.AlarmButton.Location = new System.Drawing.Point(23, 117);
            this.AlarmButton.Name = "AlarmButton";
            this.AlarmButton.Size = new System.Drawing.Size(295, 29);
            this.AlarmButton.TabIndex = 2;
            this.AlarmButton.Text = "Alarm";
            this.AlarmButton.UseVisualStyleBackColor = true;
            this.AlarmButton.Click += new System.EventHandler(this.AlarmButton_Click);
            // 
            // TextInputButton
            // 
            this.TextInputButton.Location = new System.Drawing.Point(23, 152);
            this.TextInputButton.Name = "TextInputButton";
            this.TextInputButton.Size = new System.Drawing.Size(295, 29);
            this.TextInputButton.TabIndex = 3;
            this.TextInputButton.Text = "Text input";
            this.TextInputButton.UseVisualStyleBackColor = true;
            this.TextInputButton.Click += new System.EventHandler(this.TextInputButton_Click);
            // 
            // SelectButton
            // 
            this.SelectButton.Location = new System.Drawing.Point(23, 187);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(295, 29);
            this.SelectButton.TabIndex = 4;
            this.SelectButton.Text = "ComboBox";
            this.SelectButton.UseVisualStyleBackColor = true;
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // DownLoadButton
            // 
            this.DownLoadButton.Location = new System.Drawing.Point(23, 222);
            this.DownLoadButton.Name = "DownLoadButton";
            this.DownLoadButton.Size = new System.Drawing.Size(295, 29);
            this.DownLoadButton.TabIndex = 5;
            this.DownLoadButton.Text = "Download";
            this.DownLoadButton.UseVisualStyleBackColor = true;
            this.DownLoadButton.Click += new System.EventHandler(this.DownLoadButton_Click);
            // 
            // StopScheduledNotificationButton
            // 
            this.StopScheduledNotificationButton.Location = new System.Drawing.Point(23, 292);
            this.StopScheduledNotificationButton.Name = "StopScheduledNotificationButton";
            this.StopScheduledNotificationButton.Size = new System.Drawing.Size(295, 29);
            this.StopScheduledNotificationButton.TabIndex = 7;
            this.StopScheduledNotificationButton.Text = "Stop annoying notification";
            this.StopScheduledNotificationButton.UseVisualStyleBackColor = true;
            this.StopScheduledNotificationButton.Click += new System.EventHandler(this.StopScheduledNotificationButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(344, 378);
            this.Controls.Add(this.StopScheduledNotificationButton);
            this.Controls.Add(this.DownLoadButton);
            this.Controls.Add(this.SelectButton);
            this.Controls.Add(this.TextInputButton);
            this.Controls.Add(this.AlarmButton);
            this.Controls.Add(this.ScheduleButton);
            this.Controls.Add(this.HeroButton);
            this.Controls.Add(this.InterceptButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Toast";
            this.ResumeLayout(false);

        }

        #endregion

        private Button InterceptButton;
        private Button HeroButton;
        private Button ScheduleButton;
        private Button AlarmButton;
        private Button TextInputButton;
        private Button SelectButton;
        private Button DownLoadButton;
        private Button StopScheduledNotificationButton;
    }
}
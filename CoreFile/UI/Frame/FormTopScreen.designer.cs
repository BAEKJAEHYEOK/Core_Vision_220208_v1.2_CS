namespace Core.UI
{
    partial class FormTopScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTopScreen));
            this.TimerUI = new System.Windows.Forms.Timer(this.components);
            this.ImgList = new System.Windows.Forms.ImageList(this.components);
            this.lblSwVersion = new System.Windows.Forms.Label();
            this.BtnHistoryPage = new System.Windows.Forms.Button();
            this.BtnTeachPage = new System.Windows.Forms.Button();
            this.BtnParamPage = new System.Windows.Forms.Button();
            this.BtnSettingPage = new System.Windows.Forms.Button();
            this.BtnMainPage = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.BtnPlayback = new System.Windows.Forms.Button();
            this.lblTime = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.BtnUserLogin = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TimerUI
            // 
            this.TimerUI.Tick += new System.EventHandler(this.TimerUI_Tick);
            // 
            // ImgList
            // 
            this.ImgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImgList.ImageStream")));
            this.ImgList.TransparentColor = System.Drawing.Color.Transparent;
            this.ImgList.Images.SetKeyName(0, "MainView_Normal.png");
            this.ImgList.Images.SetKeyName(1, "MainView_Clicked.png");
            this.ImgList.Images.SetKeyName(2, "MainView_Over.png");
            this.ImgList.Images.SetKeyName(3, "Setting_Normal.png");
            this.ImgList.Images.SetKeyName(4, "Setting_Clicked.png");
            this.ImgList.Images.SetKeyName(5, "Setting_Over.png");
            this.ImgList.Images.SetKeyName(6, "Parameter_Normal.png");
            this.ImgList.Images.SetKeyName(7, "Parameter_Clicked.png");
            this.ImgList.Images.SetKeyName(8, "Parameter_Over.png");
            this.ImgList.Images.SetKeyName(9, "Teach_Normal.png");
            this.ImgList.Images.SetKeyName(10, "Teach_Clicked.png");
            this.ImgList.Images.SetKeyName(11, "Teach_Over.png");
            this.ImgList.Images.SetKeyName(12, "History_Normal.png");
            this.ImgList.Images.SetKeyName(13, "History_Clicked.png");
            this.ImgList.Images.SetKeyName(14, "History_Over.png");
            this.ImgList.Images.SetKeyName(15, "Exit_Normal.png");
            this.ImgList.Images.SetKeyName(16, "Exit_Clicked.png");
            this.ImgList.Images.SetKeyName(17, "Exit_Over.png");
            // 
            // lblSwVersion
            // 
            this.lblSwVersion.AutoSize = true;
            this.lblSwVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblSwVersion.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSwVersion.Location = new System.Drawing.Point(533, 51);
            this.lblSwVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSwVersion.Name = "lblSwVersion";
            this.lblSwVersion.Size = new System.Drawing.Size(92, 18);
            this.lblSwVersion.TabIndex = 772;
            this.lblSwVersion.Text = "SW-Version";
            // 
            // BtnHistoryPage
            // 
            this.BtnHistoryPage.BackColor = System.Drawing.Color.Transparent;
            this.BtnHistoryPage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnHistoryPage.BackgroundImage")));
            this.BtnHistoryPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnHistoryPage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(137)))), ((int)(((byte)(134)))));
            this.BtnHistoryPage.FlatAppearance.BorderSize = 0;
            this.BtnHistoryPage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(137)))), ((int)(((byte)(134)))));
            this.BtnHistoryPage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(137)))), ((int)(((byte)(134)))));
            this.BtnHistoryPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnHistoryPage.Location = new System.Drawing.Point(593, 85);
            this.BtnHistoryPage.Name = "BtnHistoryPage";
            this.BtnHistoryPage.Size = new System.Drawing.Size(137, 45);
            this.BtnHistoryPage.TabIndex = 779;
            this.BtnHistoryPage.UseVisualStyleBackColor = false;
            this.BtnHistoryPage.Click += new System.EventHandler(this.BtnHistoryPage_Click);
            this.BtnHistoryPage.MouseEnter += new System.EventHandler(this.BtnHistoryPage_MouseEnter);
            this.BtnHistoryPage.MouseLeave += new System.EventHandler(this.BtnHistoryPage_MouseLeave);
            // 
            // BtnTeachPage
            // 
            this.BtnTeachPage.BackColor = System.Drawing.Color.Transparent;
            this.BtnTeachPage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnTeachPage.BackgroundImage")));
            this.BtnTeachPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnTeachPage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(137)))), ((int)(((byte)(134)))));
            this.BtnTeachPage.FlatAppearance.BorderSize = 0;
            this.BtnTeachPage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(137)))), ((int)(((byte)(134)))));
            this.BtnTeachPage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(137)))), ((int)(((byte)(134)))));
            this.BtnTeachPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnTeachPage.Location = new System.Drawing.Point(463, 85);
            this.BtnTeachPage.Name = "BtnTeachPage";
            this.BtnTeachPage.Size = new System.Drawing.Size(127, 45);
            this.BtnTeachPage.TabIndex = 778;
            this.BtnTeachPage.UseVisualStyleBackColor = false;
            this.BtnTeachPage.Click += new System.EventHandler(this.BtnTeachPage_Click);
            this.BtnTeachPage.MouseEnter += new System.EventHandler(this.BtnTeachPage_MouseEnter);
            this.BtnTeachPage.MouseLeave += new System.EventHandler(this.BtnTeachPage_MouseLeave);
            // 
            // BtnParamPage
            // 
            this.BtnParamPage.BackColor = System.Drawing.Color.Transparent;
            this.BtnParamPage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnParamPage.BackgroundImage")));
            this.BtnParamPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnParamPage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(137)))), ((int)(((byte)(134)))));
            this.BtnParamPage.FlatAppearance.BorderSize = 0;
            this.BtnParamPage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(137)))), ((int)(((byte)(134)))));
            this.BtnParamPage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(137)))), ((int)(((byte)(134)))));
            this.BtnParamPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnParamPage.Location = new System.Drawing.Point(300, 85);
            this.BtnParamPage.Name = "BtnParamPage";
            this.BtnParamPage.Size = new System.Drawing.Size(160, 45);
            this.BtnParamPage.TabIndex = 777;
            this.BtnParamPage.UseVisualStyleBackColor = false;
            this.BtnParamPage.Click += new System.EventHandler(this.BtnParamPage_Click);
            this.BtnParamPage.MouseEnter += new System.EventHandler(this.BtnParamPage_MouseEnter);
            this.BtnParamPage.MouseLeave += new System.EventHandler(this.BtnParamPage_MouseLeave);
            // 
            // BtnSettingPage
            // 
            this.BtnSettingPage.BackColor = System.Drawing.Color.Transparent;
            this.BtnSettingPage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnSettingPage.BackgroundImage")));
            this.BtnSettingPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnSettingPage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(137)))), ((int)(((byte)(134)))));
            this.BtnSettingPage.FlatAppearance.BorderSize = 0;
            this.BtnSettingPage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(137)))), ((int)(((byte)(134)))));
            this.BtnSettingPage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(137)))), ((int)(((byte)(134)))));
            this.BtnSettingPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSettingPage.Location = new System.Drawing.Point(159, 85);
            this.BtnSettingPage.Name = "BtnSettingPage";
            this.BtnSettingPage.Size = new System.Drawing.Size(138, 45);
            this.BtnSettingPage.TabIndex = 776;
            this.BtnSettingPage.UseVisualStyleBackColor = false;
            this.BtnSettingPage.Click += new System.EventHandler(this.BtnSettingPage_Click);
            this.BtnSettingPage.MouseEnter += new System.EventHandler(this.BtnSettingPage_MouseEnter);
            this.BtnSettingPage.MouseLeave += new System.EventHandler(this.BtnSettingPage_MouseLeave);
            // 
            // BtnMainPage
            // 
            this.BtnMainPage.BackColor = System.Drawing.Color.Transparent;
            this.BtnMainPage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnMainPage.BackgroundImage")));
            this.BtnMainPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnMainPage.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(137)))), ((int)(((byte)(134)))));
            this.BtnMainPage.FlatAppearance.BorderSize = 0;
            this.BtnMainPage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(137)))), ((int)(((byte)(134)))));
            this.BtnMainPage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(137)))), ((int)(((byte)(134)))));
            this.BtnMainPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMainPage.Location = new System.Drawing.Point(2, 85);
            this.BtnMainPage.Name = "BtnMainPage";
            this.BtnMainPage.Size = new System.Drawing.Size(160, 45);
            this.BtnMainPage.TabIndex = 775;
            this.BtnMainPage.UseVisualStyleBackColor = false;
            this.BtnMainPage.Click += new System.EventHandler(this.BtnMainPage_Click_1);
            this.BtnMainPage.MouseEnter += new System.EventHandler(this.BtnMainPage_MouseEnter);
            this.BtnMainPage.MouseLeave += new System.EventHandler(this.BtnMainPage_MouseLeave);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(137)))), ((int)(((byte)(134)))));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(137)))), ((int)(((byte)(134)))));
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(137)))), ((int)(((byte)(134)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Location = new System.Drawing.Point(733, 85);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(118, 45);
            this.btnExit.TabIndex = 5;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            this.btnExit.MouseEnter += new System.EventHandler(this.btnExit_MouseEnter);
            this.btnExit.MouseLeave += new System.EventHandler(this.btnExit_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Controls.Add(this.BtnPlayback);
            this.panel1.Controls.Add(this.lblTime);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.BtnUserLogin);
            this.panel1.Controls.Add(this.lblSwVersion);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1920, 85);
            this.panel1.TabIndex = 774;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Font = new System.Drawing.Font("Arial", 15F);
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(1724, 57);
            this.lblDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(170, 23);
            this.lblDate.TabIndex = 772;
            this.lblDate.Text = "2022-01-01 (Mon)";
            // 
            // BtnPlayback
            // 
            this.BtnPlayback.BackColor = System.Drawing.Color.Transparent;
            this.BtnPlayback.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnPlayback.BackgroundImage")));
            this.BtnPlayback.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnPlayback.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.BtnPlayback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPlayback.Location = new System.Drawing.Point(1132, 0);
            this.BtnPlayback.Margin = new System.Windows.Forms.Padding(2);
            this.BtnPlayback.Name = "BtnPlayback";
            this.BtnPlayback.Size = new System.Drawing.Size(72, 69);
            this.BtnPlayback.TabIndex = 769;
            this.BtnPlayback.UseVisualStyleBackColor = false;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.Font = new System.Drawing.Font("Arial", 32F);
            this.lblTime.ForeColor = System.Drawing.Color.White;
            this.lblTime.Location = new System.Drawing.Point(1708, 10);
            this.lblTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(190, 49);
            this.lblTime.TabIndex = 771;
            this.lblTime.Text = "12:30:59";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Gold;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.Location = new System.Drawing.Point(1209, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 69);
            this.button1.TabIndex = 770;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // BtnUserLogin
            // 
            this.BtnUserLogin.BackColor = System.Drawing.Color.Transparent;
            this.BtnUserLogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnUserLogin.BackgroundImage")));
            this.BtnUserLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnUserLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnUserLogin.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnUserLogin.Location = new System.Drawing.Point(1316, 3);
            this.BtnUserLogin.Name = "BtnUserLogin";
            this.BtnUserLogin.Size = new System.Drawing.Size(119, 48);
            this.BtnUserLogin.TabIndex = 3;
            this.BtnUserLogin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnUserLogin.UseVisualStyleBackColor = false;
            this.BtnUserLogin.Click += new System.EventHandler(this.BtnUserLogin_Click);
            // 
            // FormTopScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(137)))), ((int)(((byte)(134)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1920, 130);
            this.ControlBox = false;
            this.Controls.Add(this.BtnHistoryPage);
            this.Controls.Add(this.BtnTeachPage);
            this.Controls.Add(this.BtnParamPage);
            this.Controls.Add(this.BtnSettingPage);
            this.Controls.Add(this.BtnMainPage);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormTopScreen";
            this.Text = "Top Screen";
            this.Load += new System.EventHandler(this.FormTopScreen_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer TimerUI;
        private System.Windows.Forms.Button BtnUserLogin;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ImageList ImgList;
        private System.Windows.Forms.Button BtnPlayback;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblSwVersion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnMainPage;
        private System.Windows.Forms.Button BtnSettingPage;
        private System.Windows.Forms.Button BtnParamPage;
        private System.Windows.Forms.Button BtnTeachPage;
        private System.Windows.Forms.Button BtnHistoryPage;
        private System.Windows.Forms.Label lblDate;
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Core.Layers;
using static Core.Layers.DEF_System;
using static Core.Layers.DEF_Common;
using static Core.Layers.DEF_UI;
using Core;

namespace Core.UI
{
    public partial class FormTopScreen : Form
    {
        public static FormTopScreen TopMenu = null;

        enum EBtnOption
        {
            Normal,
            Clicked,
            Over,
            Max,
        }
        public FormTopScreen()
        {
            InitializeComponent();

            InitializeForm();

            ResouceMapping();

            TopMenu = this;
            lblSwVersion.Text = SYSTEM_VER;

            BtnPlayback.FlatStyle = FlatStyle.Flat;
        }

        protected virtual void InitializeForm()
        {
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.DesktopLocation = new Point(DEF_UI.TOP_POS_X, DEF_UI.TOP_POS_Y);
            this.Size = new Size(DEF_UI.TOP_SIZE_WIDTH, DEF_UI.TOP_SIZE_HEIGHT);
            this.FormBorderStyle = FormBorderStyle.None;

            TimerUI.Interval = UITimerInterval;
            TimerUI.Enabled = true;
            TimerUI.Start();
        }

        private void TimerUI_Tick(object sender, EventArgs e)
        {
            //TextTime.Text = DateTime.Now.ToString("yyyy-MM-dd [ddd] <tt> HH:mm:ss");

            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en");
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
            lblDate.Text = DateTime.Now.ToString("yyyy-MM-dd (ddd)", culture);

            //LabelCurUser.Text = $"Current User : {CMainFrame.DataManager.LoginInfo.User.Name}";
            //BtnUserLogin.Text = $"Login : {CMainFrame.DataManager.LoginInfo.User.Name}";            
        }

        public void SetMessage(string strMsg)
        {
            //TextMessage.Text = strMsg;
        }

        private void BtnUserLogin_Click(object sender, EventArgs e)
        {
            FormUserLogin dlg = new FormUserLogin();
            dlg.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (CMainFrame.InquireMsg("Exit System?"))
            {
                CMainFrame.mCore.CloseSystem();
                
                try
                {
                    Environment.Exit(0);
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                }
                catch
                {

                }
                
            }
        }

        Button[] BtnPage = new Button[6];


        private EFormType CurrentPage = EFormType.NONE;


        private void ResouceMapping()
        {
            BtnPage[0] = BtnMainPage;
            BtnPage[1] = BtnSettingPage;
            BtnPage[2] = BtnParamPage;
            BtnPage[3] = BtnTeachPage;
            BtnPage[4] = BtnHistoryPage;
            BtnPage[5] = btnExit;

            SelectPage(EFormType.AUTO);
        }

        void SelectPage(EFormType index)
        {
            if (CurrentPage == index) return;
            CurrentPage = index;
            for (int i = 0; i < (int)EFormType.MAX; i++)
            {
                if (i == (int)CurrentPage) continue;
                ButtonDisplay(i, EBtnOption.Normal);

                BtnPage[i].FlatStyle = FlatStyle.Flat;
            }

            ButtonDisplay((int)index, EBtnOption.Clicked);
            CMainFrame.MainFrame?.DisplayManager.FormSelectChange(index);
        }

        public void EnableBottomPage(bool bEnable)
        {
            for (int i = 0; i < (int)EFormType.MAX; i++)
            {
                if (i == (int)CurrentPage) continue;
                if (bEnable) ButtonDisplay(i, EBtnOption.Normal);
                else ButtonDisplay(i, EBtnOption.Normal);
                BtnPage[i].Enabled = bEnable;
            }
        }

        private void ButtonDisplay(int BtnNo, EBtnOption Option)
        {
            BtnPage[BtnNo].BackgroundImage = ImgList.Images[(int)Option + (BtnNo * 3)];
        }


        private void FormTopScreen_Load(object sender, EventArgs e)
        {

        }

        private void textVersion_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnMainPage_Click_1(object sender, EventArgs e)
        {
            SelectPage(EFormType.AUTO);
        }

        private void BtnSettingPage_Click(object sender, EventArgs e)
        {
            SelectPage(EFormType.SETTING);
        }

        private void BtnParamPage_Click(object sender, EventArgs e)
        {
            SelectPage(EFormType.PARAM);
        }

        private void BtnTeachPage_Click(object sender, EventArgs e)
        {
            SelectPage(EFormType.TEACH);
        }

        private void BtnHistoryPage_Click(object sender, EventArgs e)
        {
            SelectPage(EFormType.HISTORY);
        }

        private void BtnMainPage_MouseEnter(object sender, EventArgs e)
        {
            if(CurrentPage != EFormType.AUTO)
                ButtonDisplay(0, EBtnOption.Over);
        }

        private void BtnMainPage_MouseLeave(object sender, EventArgs e)
        {
            if (CurrentPage != EFormType.AUTO)
                ButtonDisplay(0, EBtnOption.Normal);
        }

        private void BtnSettingPage_MouseEnter(object sender, EventArgs e)
        {
            if (CurrentPage != EFormType.SETTING)
                ButtonDisplay(1, EBtnOption.Over);
        }

        private void BtnSettingPage_MouseLeave(object sender, EventArgs e)
        {
            if (CurrentPage != EFormType.SETTING)
                ButtonDisplay(1, EBtnOption.Normal);
        }

        private void BtnParamPage_MouseEnter(object sender, EventArgs e)
        {
            if (CurrentPage != EFormType.PARAM)
                ButtonDisplay(2, EBtnOption.Over);
        }

        private void BtnParamPage_MouseLeave(object sender, EventArgs e)
        {
            if (CurrentPage != EFormType.PARAM)
                ButtonDisplay(2, EBtnOption.Normal);
        }

        private void BtnTeachPage_MouseEnter(object sender, EventArgs e)
        {
            if (CurrentPage != EFormType.TEACH)
                ButtonDisplay(3, EBtnOption.Over);
        }

        private void BtnTeachPage_MouseLeave(object sender, EventArgs e)
        {
            if (CurrentPage != EFormType.TEACH)
                ButtonDisplay(3, EBtnOption.Normal);
        }

        private void BtnHistoryPage_MouseEnter(object sender, EventArgs e)
        {
            if (CurrentPage != EFormType.HISTORY)
                ButtonDisplay(4, EBtnOption.Over);
        }

        private void BtnHistoryPage_MouseLeave(object sender, EventArgs e)
        {
            if (CurrentPage != EFormType.HISTORY)
                ButtonDisplay(4, EBtnOption.Normal);
        }

        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            ButtonDisplay(5, EBtnOption.Over);
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            ButtonDisplay(5, EBtnOption.Normal);
        }
    }
}

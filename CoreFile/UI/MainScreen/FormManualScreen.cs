using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading.Tasks;

using Cognex.VisionPro;
using Cognex.VisionPro.Implementation;

using Core.Layers;
using static Core.Layers.DEF_Common;
using static Core.Layers.DEF_Thread;
using static Core.Layers.DEF_Error;
using static Core.Layers.DEF_DataManager;

namespace Core.UI
{
    public partial class FormManualScreen : Form
    {
        const int INPUT = 0;
        const int OUTPUT = 1;
        const int LoHandler = 0;
        const int UpHandler = 1;
        const int Spinner1 = 0;
        const int Spinner2 = 1;

        ICogImage cogAcquireImage = null;
        CogRecord cogRecordDisplay = null;

        public FormManualScreen()
        {
            InitializeComponent();
            InitializeForm();
        }

        protected virtual void InitializeForm()
        {
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.DesktopLocation = new Point(DEF_UI.MAIN_POS_X, DEF_UI.MAIN_POS_Y);
            this.Size = new Size(DEF_UI.MAIN_SIZE_WIDTH, DEF_UI.MAIN_SIZE_HEIGHT);
            this.FormBorderStyle = FormBorderStyle.None;

        }


        private void SetButtonsEnable(bool bEnable)
        {
            CMainFrame.MainFrame.TopScreen.EnableBottomPage(bEnable);

            var btns = CMainFrame.MainFrame.GetAllControl(this, typeof(System.Windows.Forms.Button));
            foreach (var btn in btns)
            {
                System.Windows.Forms.Button abtn = btn as System.Windows.Forms.Button;
                abtn.Enabled = bEnable;
            }
            
        }

        // 계측 이미지 클릭
        private void btn_AcquireImage_Click(object sender, EventArgs e)
        {
            cogAcquireImage = CMainFrame.mCore.m_GigE.AcquisitionImage(0);
            cogRecordDisplay = new CogRecord("Image", cogAcquireImage.GetType(), CogRecordUsageConstants.Result, false, cogAcquireImage, "Image");

            rd_MainDisplay_Cam0.Record = cogRecordDisplay;
            rd_MainDisplay_Cam0.Fit();
        }

        // RedTool 검사
        private void btn_RunRedTool_Click(object sender, EventArgs e)
        {
            cogRecordDisplay = CMainFrame.mCore.m_FuncInspection.RunRedTool(cogAcquireImage);
            rd_MainDisplay_Cam0.Record = cogRecordDisplay;
            rd_MainDisplay_Cam0.Fit();
        }

        // Live On
        private void btn_LiveOn_Click(object sender, EventArgs e)
        {
            CMainFrame.mCore.m_GigE.LiveOn(rd_MainDisplay_Cam0, 0);
        }

        // Live Off
        private void btn_LiveOff_Click(object sender, EventArgs e)
        {
            CMainFrame.mCore.m_GigE.LiveOff(rd_MainDisplay_Cam0, 0);
        }

        // 카메라 셋팅값 적용
        private void btn_CamSetApply_Click(object sender, EventArgs e)
        {
            double dExpValue = Convert.ToDouble(txt_Exposure.Text);
            double dBrightValue = Convert.ToDouble(txt_Brightness.Text);
            double dContrastValue = Convert.ToDouble(txt_Contrast.Text);

            CMainFrame.mCore.m_GigE.SetExposure(0, dExpValue);
            CMainFrame.mCore.m_GigE.SetBrightness(0, dBrightValue);
            CMainFrame.mCore.m_GigE.SetContrast(0, dContrastValue);
        }

        // Simul Image Load
        private void btn_LoadImage_Click(object sender, EventArgs e)
        {
            string filePath = "";
            Bitmap bmpImage = null;
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.InitialDirectory = "D:\\ConnectedInsight\\WorkSpace\\Image\\";

            // Image open
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // Image Name
                filePath = ofd.FileName;

                bmpImage = new Bitmap(filePath);
                cogAcquireImage = new CogImage8Grey(bmpImage) as ICogImage;
            }
        }


    }
}
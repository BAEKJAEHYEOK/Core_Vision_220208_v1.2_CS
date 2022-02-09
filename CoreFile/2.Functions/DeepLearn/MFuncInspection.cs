using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using Cognex.VisionPro;
using Cognex.VisionPro.Implementation;
using ViDi2;
using ViDi2.Local;

namespace Core.Layers
{
    public class MFuncInspection
    {
        //RedTool BlueTool 등등.... 220208 
        // 우선 Display 도 여기에... 
        CogRecord recordDisplay;

        // Control
        private ViDi2.Runtime.Local.Control vidiControl = null;

        // WorkSpace
        private ViDi2.Runtime.IWorkspace vidiWorkSpace = null;

        // Stream
        private ViDi2.Runtime.IStream vidiStream = null;

        // RedTool 관련
        private ISample redSample;
        private IImage processImage;
        private IRedMarking redMarking; // Marking

      

        public MFuncInspection()
        {
            
        }

        // WorKSpace Load
        public void InitialControl(string wsName)
        {

            // Create New Control
            vidiControl = new ViDi2.Runtime.Local.Control(GpuMode.Deferred);

            // GPU 할당
            vidiControl.InitializeComputeDevices(GpuMode.SingleDevicePerTool, new List<int>() { });

            // WorkSpace 경로 설정
            vidiWorkSpace = vidiControl.Workspaces.Add(wsName, "D:\\ConnectedInsight\\WorkSpace\\" + wsName + ".vrws");
            //m_formMain.textBox_WorkSpace.Text = vidiWorkSpace.Name;

            // Stream 설정
            vidiStream = vidiWorkSpace.Streams["Stream"];
            //m_formMain.textBox_Stream.Text = vidiStream.Name;
        }

        #region RedTool
        public CogRecord RunRedTool(ICogImage icogImage)
        {

            CogImage8Grey cogImage = icogImage as CogImage8Grey;
            Bitmap bmp = cogImage.ToBitmap();

            processImage = new FormsImage(bmp);

            //stream.Tools["Analyze"].Parameters.SamplingDensity = 5;
            //stream.Tools["Analyze"].Parameters as IRedToolParameters) = new Interval(0.02, 0.03); // Threshold(Lower, Upper)
            //(stream.Tools["Analyze"].ParametersBase as IRedToolParameters).Threshold = new Interval(0.02, 0.03); // Threshold(Lower, Upper)

            redSample = vidiStream.Tools["Analyze 2"].Process(processImage);
            redMarking = redSample.Markings["Analyze 2"] as IRedMarking;
            //redSample.Markings[""].

            //Bitmap bmpOverlayImage = (Bitmap)redSample.Markings["Analyze 2"]
            //redSample.Markings[""].
            Bitmap bmpViewImage = redSample.Markings["Analyze 2"].ViewImage(0).Bitmap;
            
                /*
            Bitmap _Bitmap1 = (Bitmap)_Sample_Analyze.Markings["Analyze"].OverlayImage(_i_Index_View, "").Bitmap.Clone();
            Bitmap _Bitmap2 = _Sample_Analyze.Markings["Analyze"].ViewImage(_i_Index_View).Bitmap;
            _Bitmap1 = _Bitmap1.LoadArgbBitmap();
            cogDisplay_Analyze.Image = new CogImage24PlanarColor(bmpViewImage.BlendImage(_Bitmap1));
            */

            // Score 출력
            //m_formMain.textBox_Score.Text = (redMarking.Views[0].Score * 100).ToString("F0");

            // 그래픽 출력

            // VIDI 상에서 Red Tool 처리 (잘라내기 된) 영역의 좌상 좌표 
            double offsetedRegionX = redMarking.Views[0].Pose.OffsetX;
            double offsetedRegionY = redMarking.Views[0].Pose.OffsetY;

            //redMarking.Views[0].Pose.wpf().vidi().
            CogGraphicCollection gc = new CogGraphicCollection();

            foreach (IRegion tempRegion in redMarking.Views[0].Regions) // 불량이 있을때만 타게 돼 있음
            {
                double NG_PosX_Pixel = offsetedRegionX + tempRegion.Center.X;
                double NG_PosY_Pixel = offsetedRegionY + tempRegion.Center.Y;
                double NG_RegionLength = Math.Sqrt(tempRegion.Area) * 1.5; // 새로 그릴 사각형의 가로 세로 길이 (정사각형)

                // 불량을 표시할 빨간색 사각형 
                CogRectangle recNG = new CogRectangle();
                recNG.Interactive = true;
                recNG.GraphicDOFEnable = CogRectangleDOFConstants.None;
                recNG.Color = CogColorConstants.Red;
                recNG.Visible = true;
                recNG.LineWidthInScreenPixels = 2;
                recNG.X = NG_PosX_Pixel - NG_RegionLength / 2;
                recNG.Y = NG_PosY_Pixel - NG_RegionLength / 2;
                recNG.Width = NG_RegionLength;
                recNG.Height = NG_RegionLength;

                gc.Add(recNG);

                // Score 표시 라벨
                CogGraphicLabel scoreLabel = new CogGraphicLabel();
                scoreLabel.Text = "Score : " + (tempRegion.Score * 100).ToString("F0");
                scoreLabel.X = NG_PosX_Pixel - NG_RegionLength / 2;
                scoreLabel.Y = NG_PosY_Pixel - NG_RegionLength / 2 - 50;
                scoreLabel.Font = new Font("Arial", 13, FontStyle.Regular);
                scoreLabel.Color = CogColorConstants.Red;

                gc.Add(scoreLabel);
            }

            /*
            // 판정 표시 라벨
            CogGraphicLabel resultLabel = new CogGraphicLabel();
            resultLabel.Text = resultJudge + "(" + highScore.ToString("F2") + ")";
            resultLabel.Font = new Font("Arial", 25, FontStyle.Regular);
            resultLabel.X = 2100;
            resultLabel.Y = 200;
            resultLabel.Color = (resultJudge == "OK") ? CogColorConstants.Green : CogColorConstants.Red;

            gc.Add(resultLabel);
            */

            recordDisplay = new CogRecord("Image", cogImage.GetType(), CogRecordUsageConstants.Result, false, cogImage, "Image");
            recordDisplay.SubRecords.Add(new CogRecord("rectangle", typeof(CogGraphicCollection), CogRecordUsageConstants.Result, false, gc, "rectangle"));

            return recordDisplay;
        }


        
        #endregion



    }
}

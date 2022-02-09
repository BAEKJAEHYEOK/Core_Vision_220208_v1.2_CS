using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Cognex.VisionPro;
using Cognex.VisionPro.Implementation;
using Cognex.VisionPro.FGGigE;



namespace Core.Layers
{
    
    public class MGigE
    {
        private string m_videoFormat = "Generic GigEVision (Mono)";
        private CogFrameGrabbers m_cogFG;
        ICogAcqFifo fifoTemp = null;

        ICogAcqFifo[] g_cameraFifo;

        public MGigE(int ncamNum)
        {

            // 카메라 수만큼 배열에 추가
            List<ICogAcqFifo> ConvertArr = new List<ICogAcqFifo>();

            for (int i = 0; i < ncamNum; i++)
            {

                ConvertArr.Add(fifoTemp);
            }

            g_cameraFifo = ConvertArr.ToArray();
        }

        #region Camera Connect/DisConnect

        // 카메라 연결
        public void ConnectGige(int nCamNum, out int iCam0Status, out int iCam1Status, out int iCam2Status, out int iCam3Status)
        {
            // 카메라 연결상태 Return
            iCam0Status = -1;
            iCam1Status = -1;
            iCam2Status = -1;
            iCam3Status = -1;

            try
            {
                m_cogFG = new CogFrameGrabbers();

                //
                if (m_cogFG.Count == 0)
                {
                    MessageBox.Show("No cameras can be connected");
                    return;

                }

                for (int i = 0; i < nCamNum; i++)
                {
                    if (m_cogFG[i].SerialNumber == "22531910095") // Def.CAMSERIALNUM0
                    {
                        iCam0Status = 1;

                        g_cameraFifo[0] = m_cogFG[i].CreateAcqFifo(m_videoFormat, CogAcqFifoPixelFormatConstants.Format8Grey, 0, true); // CogAcqFifo 초기화
                    }
                    else if (m_cogFG[i].SerialNumber == "11111111")
                    {
                        iCam1Status = 1;

                        g_cameraFifo[1] = m_cogFG[i].CreateAcqFifo(m_videoFormat, CogAcqFifoPixelFormatConstants.Format8Grey, 0, true); // CogAcqFifo 초기화
                    }
                    else if (m_cogFG[i].SerialNumber == "11111111")
                    {
                        iCam2Status = 1;

                        g_cameraFifo[2] = m_cogFG[i].CreateAcqFifo(m_videoFormat, CogAcqFifoPixelFormatConstants.Format8Grey, 0, true); // CogAcqFifo 초기화
                    }
                    else if (m_cogFG[i].SerialNumber == "11111111")
                    {
                        iCam3Status = 1;

                        g_cameraFifo[3] = m_cogFG[i].CreateAcqFifo(m_videoFormat, CogAcqFifoPixelFormatConstants.Format8Grey, 0, true); // CogAcqFifo 초기화
                    }
                }
            }
            catch (Exception e)
            {
           
            }

        }

        // 카메라 연결 해제
        public void DisposeGige()
        {
            CogFrameGrabbers frameGrabbers = new CogFrameGrabbers();
            foreach (ICogFrameGrabber fg in frameGrabbers)
                fg.Disconnect(false);
        }
        #endregion

        #region Camera Setting Value

        // Camera Setting값 적용
        public void SetExposure(int iCamIndex, double dValue)
        {
            g_cameraFifo[iCamIndex].OwnedExposureParams.Exposure = dValue;
        }
        public void SetBrightness(int iCamIndex, double dValue)
        {
            g_cameraFifo[iCamIndex].OwnedBrightnessParams.Brightness = dValue;
        }
        public void SetContrast(int iCamIndex, double dValue)
        {
            g_cameraFifo[iCamIndex].OwnedContrastParams.Contrast = dValue;
        }

        #endregion

        #region Camera Acquisition 

        // 카메라 계측
        public ICogImage AcquisitionImage(int iCamIndex)
        {
            int iTrigNum = 0;
            ICogImage iCogReturnImage = null;
            g_cameraFifo[iCamIndex].AcquiredPixelFormat();
            iCogReturnImage = g_cameraFifo[iCamIndex].Acquire(out iTrigNum);

            return iCogReturnImage;
        }

        #endregion

        public void LiveOn(CogRecordDisplay recordDisplay, int iDisplayIndex)
        {

            if(iDisplayIndex == 0)
                recordDisplay.StartLiveDisplay(g_cameraFifo[iDisplayIndex], false);
        }

        public void LiveOff(CogRecordDisplay recordDisplay, int iDisplayIndex)
        {
            
            if(iDisplayIndex == 0)
                recordDisplay.StopLiveDisplay();
        }


    }
}

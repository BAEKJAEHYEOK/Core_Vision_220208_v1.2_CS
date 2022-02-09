using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matrox.MatroxImagingLibrary;
using System.Runtime.InteropServices;

namespace Core.Layers
{
    public class MCxp
    {
        MIL_ID milApplication = MIL.M_NULL;  // MIL Application identifier.
        MIL_ID milSystem = MIL.M_NULL;     // MIL System identifier.
        MIL_ID[] milDisplay = { MIL.M_NULL, MIL.M_NULL, MIL.M_NULL, MIL.M_NULL };      // MIL Display identifier.
        MIL_ID[] milImage = { MIL.M_NULL, MIL.M_NULL, MIL.M_NULL, MIL.M_NULL };       // MIL Image buffer identifier.
        MIL_ID[] milDigitizer = { MIL.M_NULL, MIL.M_NULL, MIL.M_NULL, MIL.M_NULL };   // MIL Digitizer identifier.
        MIL_INT milBoardDevNum = MIL.M_NULL;
        MIL_INT milDevNum = MIL.M_NULL;
        MIL_ID[] milChildBuffer;

        MIL_INT[] milBufSizeBand = { 1, 1, 1, 1 }; // Statics.DEFAULT_IMAGE_SIZE_BAND;
        MIL_INT[] milImagePtr = { MIL.M_NULL, MIL.M_NULL, MIL.M_NULL, MIL.M_NULL };   // Image pointer.
        MIL_INT[] milImagePitch = { MIL.M_NULL, MIL.M_NULL, MIL.M_NULL, MIL.M_NULL }; // Image pitch.
        MIL_INT milGrabBufferListSize;
        public MIL_INT[] milBufSizeX = { 0, 0, 0, 0 };
        public MIL_INT[] milBufSizeY = { 0, 0, 0, 0 };


        public byte[] Cam0_buff = null;
        public byte[] Cam1_buff = null;
        public byte[] Cam2_buff = null;
        public byte[] Cam3_buff = null;

        MIL_ID[] Cam0_MilGrabBufferList;
        MIL_ID[] Cam1_MilGrabBufferList;
        MIL_ID[] Cam2_MilGrabBufferList;
        MIL_ID[] Cam3_MilGrabBufferList;

        MIL_DIG_HOOK_FUNCTION_PTR Cam0_ProcessingFunctionPtr = null;
        MIL_DIG_HOOK_FUNCTION_PTR Cam0_HookGrabStartFunctionPtr = null;

        MIL_DIG_HOOK_FUNCTION_PTR Cam1_ProcessingFunctionPtr = null;
        MIL_DIG_HOOK_FUNCTION_PTR Cam1_HookGrabStartFunctionPtr = null;

        MIL_DIG_HOOK_FUNCTION_PTR Cam2_ProcessingFunctionPtr = null;
        MIL_DIG_HOOK_FUNCTION_PTR Cam2_HookGrabStartFunctionPtr = null;

        MIL_DIG_HOOK_FUNCTION_PTR Cam3_ProcessingFunctionPtr = null;
        MIL_DIG_HOOK_FUNCTION_PTR Cam3_HookGrabStartFunctionPtr = null;

        const int CHILD_BUFFER = 1;
        const int BUFFERING = 50;

        string boardType = "";
        int nCamNum = 0;

        private bool isDigProcessRunning = false;
        public bool isCam0_grabComplete = true;
        public bool isCam1_grabComplete = true;
        public bool isCam2_grabComplete = true;
        public bool isCam3_grabComplete = true;

        public bool isCam0_buffComplete = false;
        public bool isCam1_buffComplete = false;
        public bool isCam2_buffComplete = false;
        public bool isCam3_buffComplete = false;

        public MCxp(int camIndex)
        {
            nCamNum = camIndex;
        }

        // Matrox Connect
        public void connectCXP(int iBoardIndex, string sBoardType, int nCamNum, int iCamChannel, string sDCFCam0, string sDCFCam1, string sDCFCam2, string sDCFCam3)
        {


            try
            {
                switch (iBoardIndex)                                //  Board 선택 
                {
                    case 0: milBoardDevNum = MIL.M_DEV0; break;
                    case 1: milBoardDevNum = MIL.M_DEV1; break;
                    case 2: milBoardDevNum = MIL.M_DEV2; break;
                    case 3: milBoardDevNum = MIL.M_DEV3; break;
                }

                switch (sBoardType)                                //  Board TYPE 선택 
                {
                    case "RAPIXOCXP": boardType = MIL.M_SYSTEM_RAPIXOCXP; break;
                    case "RAPIXOCL": boardType = MIL.M_SYSTEM_RAPIXOCL; break;
                    case "SOLIOS": boardType = MIL.M_SYSTEM_SOLIOS; break;
                    case "RADIENTCXP": boardType = MIL.M_SYSTEM_RADIENTCXP; break;
                    case "RADIENTEVCL": boardType = MIL.M_SYSTEM_RADIENTEVCL; break;
                    case "USB3_VISION": boardType = MIL.M_SYSTEM_USB3_VISION; break;
                    case "GIGE_VISION": boardType = MIL.M_SYSTEM_GIGE_VISION; break;
                    case "GENTL": boardType = MIL.M_SYSTEM_GENTL; break;
                    case "": boardType = MIL.M_SYSTEM_RAPIXOCXP; break;
                }

                milChildBuffer = new MIL_ID[CHILD_BUFFER];
                MIL.MappAlloc(MIL.M_DEFAULT, ref milApplication);

                MIL.MappControl(MIL.M_DEFAULT, MIL.M_ERROR, MIL.M_PRINT_DISABLE);

                // Allocate a MIL system.
                MIL.MsysAlloc(boardType, milBoardDevNum, MIL.M_DEFAULT, ref milSystem); // Msys : 보드 번호, 보드가 1장 일 경우 DEFAULT 로 해도 무방 


                // Allocate a MIL digitizer, if supported, and set the target image size.
                if (MIL.MsysInquire(milSystem, MIL.M_DIGITIZER_NUM, MIL.M_NULL) > 0)
                {
                    MIL.MdigAlloc(milSystem, MIL.M_DEV0, sDCFCam0, MIL.M_DEFAULT, ref milDigitizer[0]); // Mdig : Camera 번호  
                    MIL.MdigInquire(milDigitizer[0], MIL.M_SIZE_X, ref milBufSizeX[0]);
                    MIL.MdigInquire(milDigitizer[0], MIL.M_SIZE_Y, ref milBufSizeY[0]);
                    MIL.MdigInquire(milDigitizer[0], MIL.M_SIZE_BAND, ref milBufSizeBand[0]);

                    Cam0_MilGrabBufferList = new MIL_ID[BUFFERING];

                    Cam0_buff = new byte[milBufSizeX[0] * milBufSizeY[0]];


                    if (nCamNum > 1)
                    {
                        if (iCamChannel == 1)
                        {
                            MIL.MdigAlloc(milSystem, MIL.M_DEV1, sDCFCam1, MIL.M_DEFAULT, ref milDigitizer[1]); // Mdig : Camera 번호  
                            MIL.MdigInquire(milDigitizer[1], MIL.M_SIZE_X, ref milBufSizeX[1]);
                            MIL.MdigInquire(milDigitizer[1], MIL.M_SIZE_Y, ref milBufSizeY[1]);
                            MIL.MdigInquire(milDigitizer[1], MIL.M_SIZE_BAND, ref milBufSizeBand[1]);

                            Cam1_MilGrabBufferList = new MIL_ID[BUFFERING];

                            Cam1_buff = new byte[milBufSizeX[1] * milBufSizeY[1]];

                        }
                        else
                        {
                            MIL.MdigAlloc(milSystem, MIL.M_DEV2, sDCFCam1, MIL.M_DEFAULT, ref milDigitizer[1]); // Mdig : Camera 번호  
                            MIL.MdigInquire(milDigitizer[1], MIL.M_SIZE_X, ref milBufSizeX[1]);
                            MIL.MdigInquire(milDigitizer[1], MIL.M_SIZE_Y, ref milBufSizeY[1]);
                            MIL.MdigInquire(milDigitizer[1], MIL.M_SIZE_BAND, ref milBufSizeBand[1]);

                            Cam1_MilGrabBufferList = new MIL_ID[BUFFERING];

                            Cam1_buff = new byte[milBufSizeX[1] * milBufSizeY[1]];
                        }

                    }

                    if (nCamNum > 2)
                    {
                        if (iCamChannel == 1)
                        {
                            MIL.MdigAlloc(milSystem, MIL.M_DEV2, sDCFCam2, MIL.M_DEFAULT, ref milDigitizer[2]); // Mdig : Camera 번호  
                            MIL.MdigInquire(milDigitizer[2], MIL.M_SIZE_X, ref milBufSizeX[2]);
                            MIL.MdigInquire(milDigitizer[2], MIL.M_SIZE_Y, ref milBufSizeY[2]);
                            MIL.MdigInquire(milDigitizer[2], MIL.M_SIZE_BAND, ref milBufSizeBand[2]);

                            Cam2_MilGrabBufferList = new MIL_ID[BUFFERING];

                            Cam2_buff = new byte[milBufSizeX[2] * milBufSizeY[2]];
                        }
                    }

                    if (nCamNum > 3)
                    {
                        if (iCamChannel == 1)
                        {
                            MIL.MdigAlloc(milSystem, MIL.M_DEV3, sDCFCam3, MIL.M_DEFAULT, ref milDigitizer[3]); // Mdig : Camera 번호  
                            MIL.MdigInquire(milDigitizer[3], MIL.M_SIZE_X, ref milBufSizeX[3]);
                            MIL.MdigInquire(milDigitizer[3], MIL.M_SIZE_Y, ref milBufSizeY[3]);
                            MIL.MdigInquire(milDigitizer[3], MIL.M_SIZE_BAND, ref milBufSizeBand[3]);

                            Cam3_MilGrabBufferList = new MIL_ID[BUFFERING];

                            Cam3_buff = new byte[milBufSizeX[3] * milBufSizeY[3]];
                        }
                    }

                }

                for (milGrabBufferListSize = 0; milGrabBufferListSize < BUFFERING; milGrabBufferListSize++)
                {
                    MIL.MbufAlloc2d(milSystem,
                        milBufSizeX[0],
                        milBufSizeY[0],
                        8 + MIL.M_UNSIGNED,
                        MIL.M_IMAGE + MIL.M_GRAB + MIL.M_DISP + MIL.M_PROC,
                        ref Cam0_MilGrabBufferList[milGrabBufferListSize]);



                    if (Cam0_MilGrabBufferList[milGrabBufferListSize] != MIL.M_NULL)
                    {
                        MIL.MbufClear(Cam0_MilGrabBufferList[milGrabBufferListSize], 0);
                    }
                    else
                        break;

                    if ((nCamNum > 1))
                    {
                        MIL.MbufAlloc2d(milSystem,
                            milBufSizeX[1],
                            milBufSizeY[1],
                            8 + MIL.M_UNSIGNED,
                            MIL.M_IMAGE + MIL.M_GRAB + MIL.M_DISP + MIL.M_PROC,
                            ref Cam1_MilGrabBufferList[milGrabBufferListSize]);

                        if (Cam1_MilGrabBufferList[milGrabBufferListSize] != MIL.M_NULL)
                        {
                            MIL.MbufClear(Cam1_MilGrabBufferList[milGrabBufferListSize], 0);
                        }
                        else
                            break;
                    }

                    if ((nCamNum > 2))
                    {
                        MIL.MbufAlloc2d(milSystem,
                            milBufSizeX[2],
                            milBufSizeY[2],
                            8 + MIL.M_UNSIGNED,
                            MIL.M_IMAGE + MIL.M_GRAB + MIL.M_DISP + MIL.M_PROC,
                            ref Cam2_MilGrabBufferList[milGrabBufferListSize]);

                        if (Cam2_MilGrabBufferList[milGrabBufferListSize] != MIL.M_NULL)
                        {
                            MIL.MbufClear(Cam2_MilGrabBufferList[milGrabBufferListSize], 0);
                        }
                        else
                            break;
                    }

                    if ((nCamNum > 3))
                    {
                        MIL.MbufAlloc2d(milSystem,
                            milBufSizeX[3],
                            milBufSizeY[3],
                            8 + MIL.M_UNSIGNED,
                            MIL.M_IMAGE + MIL.M_GRAB + MIL.M_DISP + MIL.M_PROC,
                            ref Cam3_MilGrabBufferList[milGrabBufferListSize]);

                        if (Cam3_MilGrabBufferList[milGrabBufferListSize] != MIL.M_NULL)
                        {
                            MIL.MbufClear(Cam3_MilGrabBufferList[milGrabBufferListSize], 0);
                        }
                        else
                            break;
                    }



                }



                Cam0_ProcessingFunctionPtr = new MIL_DIG_HOOK_FUNCTION_PTR(Cam0_ProcessingFunction); MIL.MdigHookFunction(milDigitizer[0], MIL.M_GRAB_START, Cam0_HookGrabStartFunctionPtr, (IntPtr)null);
                if ((nCamNum > 1))
                    Cam1_ProcessingFunctionPtr = new MIL_DIG_HOOK_FUNCTION_PTR(Cam1_ProcessingFunction); MIL.MdigHookFunction(milDigitizer[1], MIL.M_GRAB_START, Cam1_HookGrabStartFunctionPtr, (IntPtr)null);
                if ((nCamNum > 2))
                    Cam2_ProcessingFunctionPtr = new MIL_DIG_HOOK_FUNCTION_PTR(Cam2_ProcessingFunction); MIL.MdigHookFunction(milDigitizer[2], MIL.M_GRAB_START, Cam2_HookGrabStartFunctionPtr, (IntPtr)null);
                if ((nCamNum > 3))
                    Cam3_ProcessingFunctionPtr = new MIL_DIG_HOOK_FUNCTION_PTR(Cam3_ProcessingFunction); MIL.MdigHookFunction(milDigitizer[3], MIL.M_GRAB_START, Cam3_HookGrabStartFunctionPtr, (IntPtr)null);

            }
            catch (Exception e)
            {

            }
        }

        // Matrox Disconnect
        public void DisconnectCXP()
        {

            for (milGrabBufferListSize = 0; milGrabBufferListSize < BUFFERING; milGrabBufferListSize++)
            {

                MIL.MbufFree(Cam0_MilGrabBufferList[milGrabBufferListSize]);
                if (nCamNum > 1)
                    MIL.MbufFree(Cam1_MilGrabBufferList[milGrabBufferListSize]);
                if (nCamNum > 2)
                    MIL.MbufFree(Cam2_MilGrabBufferList[milGrabBufferListSize]);
                if (nCamNum > 3)
                    MIL.MbufFree(Cam3_MilGrabBufferList[milGrabBufferListSize]);


            }

            // Free allocated objects.
            MIL.MbufFree(milImage[0]);

            if (milDigitizer[0] != MIL.M_NULL)
            {
                MIL.MdigFree(milDigitizer[0]);
            }

            MIL.MdispFree(milDisplay[0]);

            if (nCamNum > 1)
            {
                MIL.MbufFree(milImage[1]);

                if (milDigitizer[1] != MIL.M_NULL)
                {
                    MIL.MdigFree(milDigitizer[1]);
                }

                MIL.MdispFree(milDisplay[1]);
            }

            if (nCamNum > 2)
            {
                MIL.MbufFree(milImage[2]);

                if (milDigitizer[2] != MIL.M_NULL)
                {
                    MIL.MdigFree(milDigitizer[2]);
                }

                MIL.MdispFree(milDisplay[2]);
            }

            if (nCamNum > 3)
            {
                MIL.MbufFree(milImage[3]);

                if (milDigitizer[3] != MIL.M_NULL)
                {
                    MIL.MdigFree(milDigitizer[3]);
                }

                MIL.MdispFree(milDisplay[3]);
            }

            MIL.MsysFree(milSystem);
            MIL.MappFree(milApplication);
        }

        // Process Start
        public void ProcessStart()
        {
            try
            {

                for (int i = 0; i < nCamNum; i++)
                {
                    // Grab in the user window if supported.
                    if (milDigitizer[i] != MIL.M_NULL)
                    {
                        // 사용하려는 M_START 및 M_SEQUENCE Mode에 따라 주석처리 하기
                        // Grab이 Start되면 Hooking Callback Fucntion인 ProcessingFunction에서 각 프레임들에 대해 실시간적으로 제어할 수 있음
                        if (!isDigProcessRunning)
                        {

                            switch (i)
                            {
                                case 0: MIL.MdigProcess(milDigitizer[i], Cam0_MilGrabBufferList, milGrabBufferListSize, MIL.M_START, MIL.M_DEFAULT, Cam0_ProcessingFunctionPtr, (IntPtr)null); break;
                                case 1: MIL.MdigProcess(milDigitizer[i], Cam1_MilGrabBufferList, milGrabBufferListSize, MIL.M_START, MIL.M_DEFAULT, Cam1_ProcessingFunctionPtr, (IntPtr)null); break;
                                case 2: MIL.MdigProcess(milDigitizer[i], Cam2_MilGrabBufferList, milGrabBufferListSize, MIL.M_START, MIL.M_DEFAULT, Cam2_ProcessingFunctionPtr, (IntPtr)null); break;
                                case 3: MIL.MdigProcess(milDigitizer[i], Cam3_MilGrabBufferList, milGrabBufferListSize, MIL.M_START, MIL.M_DEFAULT, Cam3_ProcessingFunctionPtr, (IntPtr)null); break;
                            }

                        }


                        //MIL.MdigProcess(MilDigitizer, MilChildBuffer, CHILD_BUFFER, MIL.M_START, MIL.M_DEFAULT, ProcessingFunctionPtr, (IntPtr)null); // SEQUENCE MODE
                    }


                }

                isDigProcessRunning = true;

            }
            catch (Exception ex)
            {
            }
        }

        // Process Stop
        public void ProcessStop()
        {
            try
            {
                for (int i = 0; i < nCamNum; i++)
                {
                    if (milDigitizer[i] != MIL.M_NULL)
                    {
                        switch (i)
                        {
                            case 0: MIL.MdigProcess(milDigitizer[i], Cam0_MilGrabBufferList, milGrabBufferListSize, MIL.M_STOP, MIL.M_DEFAULT, Cam0_ProcessingFunctionPtr, (IntPtr)null); break;
                            case 1: MIL.MdigProcess(milDigitizer[i], Cam1_MilGrabBufferList, milGrabBufferListSize, MIL.M_STOP, MIL.M_DEFAULT, Cam1_ProcessingFunctionPtr, (IntPtr)null); break;
                            case 2: MIL.MdigProcess(milDigitizer[i], Cam2_MilGrabBufferList, milGrabBufferListSize, MIL.M_STOP, MIL.M_DEFAULT, Cam2_ProcessingFunctionPtr, (IntPtr)null); break;
                            case 3: MIL.MdigProcess(milDigitizer[i], Cam3_MilGrabBufferList, milGrabBufferListSize, MIL.M_STOP, MIL.M_DEFAULT, Cam3_ProcessingFunctionPtr, (IntPtr)null); break;
                        }

                        isDigProcessRunning = false;

                        // M_SEQUENCE Mode 사용 시 M_STOP은 동작하지 않음
                    }

                }
            }
            catch (Exception ex)
            {
            }
        }

        #region ProcessingFunction
        public MIL_INT Cam0_ProcessingFunction(MIL_INT HookType, MIL_ID HookId, IntPtr HookDataPtr)
        {


            isCam0_buffComplete = false;
            isCam0_grabComplete = true;

            MIL_ID ModifiedBufferId = MIL.M_NULL;

            MIL.MdigGetHookInfo(HookId, MIL.M_MODIFIED_BUFFER + MIL.M_BUFFER_ID, ref ModifiedBufferId); // <- ModifiedBufferId 가 제대로 가져온 Image buffer 

            MIL.MbufInquire(ModifiedBufferId, MIL.M_HOST_ADDRESS, ref milImagePtr[0]);
            MIL.MbufInquire(ModifiedBufferId, MIL.M_PITCH, ref milImagePitch[0]);

            IntPtr MilImagePtrIntPtr = milImagePtr[0];

            for (int i = 0; i < milBufSizeY[0]; i++)
            {
                Marshal.Copy(MilImagePtrIntPtr, Cam0_buff, (int)milBufSizeX[0] * i, (int)milBufSizeX[0]);
                MilImagePtrIntPtr += milImagePitch[0];
            }

            isCam0_buffComplete = true;

            //strCam0_FrameTime = Cam0_FrameWatch.ElapsedMilliseconds.ToString("F3");

            //Cam0_FrameWatch.Restart();




            return 0;
        }

        public MIL_INT Cam1_ProcessingFunction(MIL_INT HookType, MIL_ID HookId, IntPtr HookDataPtr)
        {


            isCam1_buffComplete = false;
            isCam1_grabComplete = true;

            MIL_ID ModifiedBufferId = MIL.M_NULL;

            MIL.MdigGetHookInfo(HookId, MIL.M_MODIFIED_BUFFER + MIL.M_BUFFER_ID, ref ModifiedBufferId); // <- ModifiedBufferId 가 제대로 가져온 Image buffer 

            MIL.MbufInquire(ModifiedBufferId, MIL.M_HOST_ADDRESS, ref milImagePtr[1]);
            MIL.MbufInquire(ModifiedBufferId, MIL.M_PITCH, ref milImagePitch[1]);

            IntPtr MilImagePtrIntPtr = milImagePtr[1];

            for (int i = 0; i < milBufSizeY[1]; i++)
            {
                Marshal.Copy(MilImagePtrIntPtr, Cam1_buff, (int)milBufSizeX[1] * i, (int)milBufSizeX[1]);
                MilImagePtrIntPtr += milImagePitch[1];
            }

            isCam1_buffComplete = true;


            //strCam1_FrameTime = Cam1_FrameWatch.ElapsedMilliseconds.ToString("F3");

            //Cam1_FrameWatch.Restart();



            return 0;
        }

        public MIL_INT Cam2_ProcessingFunction(MIL_INT HookType, MIL_ID HookId, IntPtr HookDataPtr)
        {
            if (!isCam2_grabComplete)
            {
                isCam2_grabComplete = true;

                MIL_ID ModifiedBufferId = MIL.M_NULL;

                MIL.MdigGetHookInfo(HookId, MIL.M_MODIFIED_BUFFER + MIL.M_BUFFER_ID, ref ModifiedBufferId); // <- ModifiedBufferId 가 제대로 가져온 Image buffer 

                MIL.MbufInquire(ModifiedBufferId, MIL.M_HOST_ADDRESS, ref milImagePtr[2]);
                MIL.MbufInquire(ModifiedBufferId, MIL.M_PITCH, ref milImagePitch[2]);

                IntPtr MilImagePtrIntPtr = milImagePtr[2];

                for (int i = 0; i < milBufSizeY[2]; i++)
                {
                    Marshal.Copy(MilImagePtrIntPtr, Cam2_buff, (int)milBufSizeX[2] * i, (int)milBufSizeX[2]);
                    MilImagePtrIntPtr += milImagePitch[2];
                }

                isCam2_buffComplete = true;
            }


            return 0;
        }

        public MIL_INT Cam3_ProcessingFunction(MIL_INT HookType, MIL_ID HookId, IntPtr HookDataPtr)
        {
            if (!isCam3_grabComplete)
            {
                isCam3_grabComplete = true;

                MIL_ID ModifiedBufferId = MIL.M_NULL;

                MIL.MdigGetHookInfo(HookId, MIL.M_MODIFIED_BUFFER + MIL.M_BUFFER_ID, ref ModifiedBufferId); // <- ModifiedBufferId 가 제대로 가져온 Image buffer 

                MIL.MbufInquire(ModifiedBufferId, MIL.M_HOST_ADDRESS, ref milImagePtr[3]);
                MIL.MbufInquire(ModifiedBufferId, MIL.M_PITCH, ref milImagePitch[3]);

                IntPtr MilImagePtrIntPtr = milImagePtr[3];

                for (int i = 0; i < milBufSizeY[0]; i++)
                {
                    Marshal.Copy(MilImagePtrIntPtr, Cam3_buff, (int)milBufSizeX[3] * i, (int)milBufSizeX[3]);
                    MilImagePtrIntPtr += milImagePitch[3];
                }

                isCam3_buffComplete = true;
            }


            return 0;
        }
        #endregion

        #region CamSetting
        public int SetExposure(int iCamNum, double dExposure)
        {

            switch (iCamNum)                                //  Exposure 조절할 카메라 선택 
            {
                case 0: MIL.MdigControlFeature(milDigitizer[0], MIL.M_FEATURE_VALUE, "ExposureTime", MIL.M_TYPE_DOUBLE, ref dExposure); break;
                case 1: MIL.MdigControlFeature(milDigitizer[1], MIL.M_FEATURE_VALUE, "ExposureTime", MIL.M_TYPE_DOUBLE, ref dExposure); break;
                case 2: MIL.MdigControlFeature(milDigitizer[2], MIL.M_FEATURE_VALUE, "ExposureTime", MIL.M_TYPE_DOUBLE, ref dExposure); break;
                case 3: MIL.MdigControlFeature(milDigitizer[3], MIL.M_FEATURE_VALUE, "ExposureTime", MIL.M_TYPE_DOUBLE, ref dExposure); break;
            }

            return 0;
        }

        public int SetGain(int iCamNum, double dGain)
        {

            switch (iCamNum)                                //  Gain 조절할 카메라 선택 
            {
                case 0: MIL.MdigControlFeature(milDigitizer[0], MIL.M_FEATURE_VALUE, "Gain", MIL.M_TYPE_DOUBLE, ref dGain); break;
                case 1: MIL.MdigControlFeature(milDigitizer[1], MIL.M_FEATURE_VALUE, "Gain", MIL.M_TYPE_DOUBLE, ref dGain); break;
                case 2: MIL.MdigControlFeature(milDigitizer[2], MIL.M_FEATURE_VALUE, "Gain", MIL.M_TYPE_DOUBLE, ref dGain); break;
                case 3: MIL.MdigControlFeature(milDigitizer[3], MIL.M_FEATURE_VALUE, "Gain", MIL.M_TYPE_DOUBLE, ref dGain); break;
            }

            return 0;
        }

        public int SetImageROIControl(int iCamNum, long LWidth, long LHeight)
        {

            switch (iCamNum)                                //  이미지 크기 조절 할 카메라 선택 
            {
                case 0: MIL.MdigControlFeature(milDigitizer[0], MIL.M_FEATURE_VALUE, "Width", MIL.M_TYPE_INT64, ref LWidth); MIL.MdigControlFeature(milDigitizer[0], MIL.M_FEATURE_VALUE, "Height", MIL.M_TYPE_INT64, ref LHeight); break;
                case 1: MIL.MdigControlFeature(milDigitizer[1], MIL.M_FEATURE_VALUE, "Width", MIL.M_TYPE_INT64, ref LWidth); MIL.MdigControlFeature(milDigitizer[1], MIL.M_FEATURE_VALUE, "Height", MIL.M_TYPE_INT64, ref LHeight); break;
                case 2: MIL.MdigControlFeature(milDigitizer[2], MIL.M_FEATURE_VALUE, "Width", MIL.M_TYPE_INT64, ref LWidth); MIL.MdigControlFeature(milDigitizer[2], MIL.M_FEATURE_VALUE, "Height", MIL.M_TYPE_INT64, ref LHeight); break;
                case 3: MIL.MdigControlFeature(milDigitizer[3], MIL.M_FEATURE_VALUE, "Width", MIL.M_TYPE_INT64, ref LWidth); MIL.MdigControlFeature(milDigitizer[3], MIL.M_FEATURE_VALUE, "Height", MIL.M_TYPE_INT64, ref LHeight); break;
            }

            return 0;
        }
        #endregion
    }
}

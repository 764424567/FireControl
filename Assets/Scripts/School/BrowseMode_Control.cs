using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrowseMode_Control : MonoBehaviour
{
    //左手柄或者右手柄
    public SteamVR_TrackedObject m_TrackedObjLeft;
    public SteamVR_TrackedObject m_TrackedObjRight;
    //左手柄射线
    private VRTK.VRTK_Pointer m_LeftPointer;
    //头盔位置
    public GameObject m_CameraRig;
    //射线信息
    RaycastHit hit;
    //位置信息
    //初始位置 -4.9,15.8f,-17.53f
    //mc into -3.1f,15.8f,-17.173f
    //mc out -1.079f,15.8f,-16.532f
    //office out 0.095f,15.8f,-13.92f
    //office into 1.877f,15.873f,-15.252f
    //computer out 0.102f,19.445f,-5.774f
    //computer into 1.722f,19.445f,-5.09f
    //3 1-2 -0.989f,15.8f,12.035f
    //3 2-3 -0.989f,19.5f,12.035f
    //3 3-4 -0.989f,23.09f,12.035f
    //2 1-2 -0.989f,15.8f,-7.77f
    //2 2-3 -0.989f,19.5f,-7.77f
    //2 3-4 -0.989f,23.09f,-7.77f
    //1 1-2 -0.989f,15.8f,-27.497f
    //1 2-3 -0.989f,19.5f,-27.497f
    //1 3-4 -0.989f,23.09f,-27.497f

    void Start()
    {
        m_LeftPointer = m_TrackedObjLeft.GetComponent<VRTK.VRTK_Pointer>();
    }

    void Update()
    {
        SteamVR_Controller.Device deviceLeft = SteamVR_Controller.Input((int)m_TrackedObjLeft.index);
        SteamVR_Controller.Device deviceRight = SteamVR_Controller.Input((int)m_TrackedObjRight.index);

        //射线检测
        Ray rayLeft = new Ray(m_TrackedObjLeft.transform.position, m_TrackedObjLeft.transform.forward);
        Ray rayRight = new Ray(m_TrackedObjRight.transform.position, m_TrackedObjRight.transform.forward);
        //左手射线
        if (Physics.Raycast(rayLeft, out hit,100,LayerMask.GetMask("UI")))
        {
            if (deviceLeft.GetPressDown(SteamVR_Controller.ButtonMask.Trigger) || deviceRight.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                switch (hit.transform.name)
                {
                    case "UI_MC_Into":
                        m_CameraRig.transform.position =new Vector3(-3.1f, 15.8f, -17.173f);
                        break;
                    case "UI_MC_Out":
                        m_CameraRig.transform.position = new Vector3(-3.1f, 15.8f, -17.173f);
                        break;
                    case "UI_Office_Into":
                        m_CameraRig.transform.position = new Vector3(1.877f, 15.873f, -15.252f);
                        break;
                    case "UI_Office_Out":
                        m_CameraRig.transform.position = new Vector3(0.095f, 15.8f, -13.92f);
                        break;
                    case "UI_Computer_Into":
                        m_CameraRig.transform.position = new Vector3(1.722f, 19.445f, -5.09f);
                        break;
                    case "UI_Computer_Out":
                        m_CameraRig.transform.position = new Vector3(0.102f, 19.445f, -5.774f);
                        break;
                    case "UI_Left_1-2":
                        m_CameraRig.transform.position = new Vector3(-0.989f, 15.8f, -27.497f);
                        break;
                    case "UI_Left_2-3":
                        m_CameraRig.transform.position = new Vector3(-0.989f, 19.5f, -27.497f);
                        break;
                    case "UI_Left_3-4":
                        m_CameraRig.transform.position = new Vector3(-0.989f, 23.09f, -27.497f);
                        break;
                    case "UI_Center_1-2":
                        m_CameraRig.transform.position = new Vector3(-0.989f, 15.8f, -7.77f);
                        break;
                    case "UI_Center_2-3":
                        m_CameraRig.transform.position = new Vector3(-0.989f, 19.5f, -7.77f);
                        break;
                    case "UI_Center_3-4":
                        m_CameraRig.transform.position = new Vector3(-0.989f, 23.09f, -7.77f);
                        break;
                    case "UI_Right_1-2":
                        m_CameraRig.transform.position = new Vector3(-0.989f, 15.8f, 12.035f);
                        break;
                    case "UI_Right_2-3":
                        m_CameraRig.transform.position = new Vector3(-0.989f, 19.5f, 12.035f);
                        break;
                    case "UI_Right_3-4":
                        m_CameraRig.transform.position = new Vector3(-0.989f, 23.09f, 12.035f);
                        break;
                    default:
                        break;
                }
            }
        }
        //右手射线
        if (Physics.Raycast(rayRight, out hit, 100, LayerMask.GetMask("UI")))
        {
            if (deviceLeft.GetPressDown(SteamVR_Controller.ButtonMask.Trigger) || deviceRight.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                switch (hit.transform.name)
                {
                    case "UI_MC_Into":
                        m_CameraRig.transform.position = new Vector3(-3.1f, 15.8f, -17.173f);
                        break;
                    case "UI_MC_Out":
                        m_CameraRig.transform.position = new Vector3(-3.1f, 15.8f, -17.173f);
                        break;
                    case "UI_Office_Into":
                        m_CameraRig.transform.position = new Vector3(1.877f, 15.873f, -15.252f);
                        break;
                    case "UI_Office_Out":
                        m_CameraRig.transform.position = new Vector3(0.095f, 15.8f, -13.92f);
                        break;
                    case "UI_Computer_Into":
                        m_CameraRig.transform.position = new Vector3(1.722f, 19.445f, -5.09f);
                        break;
                    case "UI_Computer_Out":
                        m_CameraRig.transform.position = new Vector3(0.102f, 19.445f, -5.774f);
                        break;
                    case "UI_Left_1-2":
                        m_CameraRig.transform.position = new Vector3(-0.989f, 15.8f, -27.497f);
                        break;
                    case "UI_Left_2-3":
                        m_CameraRig.transform.position = new Vector3(-0.989f, 19.5f, -27.497f);
                        break;
                    case "UI_Left_3-4":
                        m_CameraRig.transform.position = new Vector3(-0.989f, 23.09f, -27.497f);
                        break;
                    case "UI_Center_1-2":
                        m_CameraRig.transform.position = new Vector3(-0.989f, 15.8f, -7.77f);
                        break;
                    case "UI_Center_2-3":
                        m_CameraRig.transform.position = new Vector3(-0.989f, 19.5f, -7.77f);
                        break;
                    case "UI_Center_3-4":
                        m_CameraRig.transform.position = new Vector3(-0.989f, 23.09f, -7.77f);
                        break;
                    case "UI_Right_1-2":
                        m_CameraRig.transform.position = new Vector3(-0.989f, 15.8f, 12.035f);
                        break;
                    case "UI_Right_2-3":
                        m_CameraRig.transform.position = new Vector3(-0.989f, 19.5f, 12.035f);
                        break;
                    case "UI_Right_3-4":
                        m_CameraRig.transform.position = new Vector3(-0.989f, 23.09f, 12.035f);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}

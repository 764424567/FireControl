using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyMode_Control : MonoBehaviour
{
    //模型控制对象
    private StudyModeModel_Control m_ModelControl;
    //左手柄或者右手柄
    public SteamVR_TrackedObject m_TrackedObjLeft;
    public SteamVR_TrackedObject m_TrackedObjRight;
    // Use this for initialization
    void Start()
    {
        m_ModelControl = GameObject.Find("Scenes_Control").GetComponent<StudyModeModel_Control>();
    }

    // Update is called once per frame
    void Update()
    {
        SteamVR_Controller.Device deviceLeft = SteamVR_Controller.Input((int)m_TrackedObjLeft.index);
        SteamVR_Controller.Device deviceRight = SteamVR_Controller.Input((int)m_TrackedObjRight.index);

        //左手
        if (deviceLeft.GetPressDown(SteamVR_Controller.ButtonMask.Trigger) && m_ModelControl.m_OrderNumber == 0)
        {

        }
        else if (deviceLeft.GetPressDown(SteamVR_Controller.ButtonMask.Trigger) && m_ModelControl.m_OrderNumber == 2)
        {

        }

        //右手
        if (deviceRight.GetPressDown(SteamVR_Controller.ButtonMask.Trigger) && m_ModelControl.m_OrderNumber == 0)
        {

        }
        else if (deviceRight.GetPressDown(SteamVR_Controller.ButtonMask.Trigger) && m_ModelControl.m_OrderNumber == 2)
        {

        }
    }
}

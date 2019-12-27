using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test01 : MonoBehaviour
{
    //手柄
    public SteamVR_TrackedObject m_TrackedObjLeft;

    void Update()
    {
        SteamVR_Controller.Device deviceLeft = SteamVR_Controller.Input((int)m_TrackedObjLeft.index);
        //手柄事件
        if (deviceLeft.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            Debug.Log("按了 “Touchpad” “圆盘位置”");
            //方法返回一个坐标 接触圆盘位置  
            Vector2 cc = deviceLeft.GetAxis();
            Debug.Log(cc);
            // 例子：圆盘分成上下左右  
            float jiaodu = VectorAngle(new Vector2(1, 0), cc);
            Debug.Log(jiaodu);
            //下  
            if (jiaodu > 45 && jiaodu < 135)
            {
                Debug.Log("下");
            }
            //上  
            if (jiaodu < -45 && jiaodu > -135)
            {
                Debug.Log("上");
            }
            //左  
            if ((jiaodu < 180 && jiaodu > 135) || (jiaodu < -135 && jiaodu > -180))
            {
                Debug.Log("左");
            }
            //右  
            if ((jiaodu > 0 && jiaodu < 45) || (jiaodu > -45 && jiaodu < 0))
            {
                Debug.Log("右");
            }
        }
        if (deviceLeft.GetTouchDown(SteamVR_Controller.ButtonMask.System))
        {
            Debug.Log("按下了 “system” “系统按钮/Steam”");
        }
        if (deviceLeft.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("按下了 “trigger” “扳机键”");
            //左手震动  
            var deviceIndex = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost);
            SteamVR_Controller.Input(deviceIndex).TriggerHapticPulse(3000);
        }
        if (deviceLeft.GetTouchDown(SteamVR_Controller.ButtonMask.System))
        {
            Debug.Log("按下了 “system” “系统按钮/Steam”");
        }
        if (deviceLeft.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
        {
            Debug.Log("用press按下了 “ApplicationMenu” “菜单键”");
        }
        //Axis0键 与圆盘有交互 与圆盘有关  
        //触摸触发  
        if (deviceLeft.GetTouchDown(SteamVR_Controller.ButtonMask.Axis0))
        {
            Debug.Log("按下了 “Axis0” “方向 ”");
        }
        //Axis1键  目前未发现按键位置  
        //触摸触发  
        if (deviceLeft.GetTouchDown(SteamVR_Controller.ButtonMask.Axis1))
        {
            Debug.Log("按下了 “Axis1” “ ”");
        }
        //Axis2键 目前未发现按键位置  
        //触摸触发  
        if (deviceLeft.GetTouchDown(SteamVR_Controller.ButtonMask.Axis2))
        {
            Debug.Log("按下了 “Axis2” “ ”");
        }
        //Axis3键  未目前未发现按键位置  
        //触摸触发  
        if (deviceLeft.GetTouchDown(SteamVR_Controller.ButtonMask.Axis3))
        {
            Debug.Log("按下了 “Axis3” “ ”");
        }
        //Axis4键  目前未发现按键位置  
        //触摸触发  
        if (deviceLeft.GetTouchDown(SteamVR_Controller.ButtonMask.Axis4))
        {
            Debug.Log("按下了 “Axis4” “ ”");
        }


        
    }
    //方向圆盘最好配合这个使用 圆盘的.GetAxis()会检测返回一个二位向量，可用角度划分圆盘按键数量  
    //这个函数输入两个二维向量会返回一个夹角 180 到 -180  
    float VectorAngle(Vector2 from, Vector2 to)
    {
        float angle;
        Vector3 cross = Vector3.Cross(from, to);
        angle = Vector2.Angle(from, to);
        return cross.z > 0 ? -angle : angle;
    }
}

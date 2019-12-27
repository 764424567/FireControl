using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViveControllerInputTest : MonoBehaviour
{

    private SteamVR_TrackedObject trackedobj;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedobj.index); }
    }

    private void Awake()
    {
        trackedobj = GetComponent<SteamVR_TrackedObject>();
    }

    // Update is called once per frame
    void Update()
    {
        //获取手指在touchpad的位置并输出到控制台
        if (Controller.GetAxis() != Vector2.zero)
        {
            Debug.Log(gameObject.name + Controller.GetAxis());
        }
        //按下扳机时输出到控制台
        if (Controller.GetHairTriggerDown())
        {
            Debug.Log(gameObject.name + "TriggerDown");
        }
        //松开扳机时输出到控制台
        if (Controller.GetHairTriggerUp())
        {
            Debug.Log(gameObject.name + "TriggerUp");
        }
        //按下抓取键
        if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
        {
            Debug.Log(gameObject.name + "Press Grip");
        }
        //松开抓取键
        if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Grip))
        {
            Debug.Log(gameObject.name + "Loosen Grip");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackedController : MonoBehaviour {
    private SteamVR_TrackedObject trackedobj;
    private SteamVR_Controller.Device device;
    private GameObject currentGrab;
    private bool shake;
	// Use this for initialization
	void Start () {
        trackedobj = transform.GetComponent<SteamVR_TrackedObject>();
        device = SteamVR_Controller.Input((int)trackedobj.index);
	}
	
	// Update is called once per frame
	void Update () {


	}
    private void OnTriggerStay(Collider collider)
    {
        Debug.Log("111");
        currentGrab = collider.transform.gameObject;
        if (currentGrab.tag.Equals("File"))
        {
            Debug.Log("222");
            shake = true;
            StartCoroutine(HpaticPulse());
            if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger)) 
            {
                currentGrab.transform.parent = transform;
                Rigidbody rig = currentGrab.GetComponent<Rigidbody>();      
                rig.useGravity = false;      
                rig.isKinematic = true;

            }

        }
    }
    
    IEnumerator HpaticPulse() {
        Debug.Log("333");
        while (shake) { 
             Invoke("StopHapticPulse",1);
             device.TriggerHapticPulse(3000);
                //等待帧结束执行，等待所有的摄像机和GUI渲染接受后渲染（在屏幕显示之前）
             yield return new WaitForEndOfFrame();
        }
    }
    void StopHapticPulse()
    {
        shake = false;
    }

}

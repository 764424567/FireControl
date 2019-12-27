using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_ColliderAlertor : MonoBehaviour
{
    private SC_ModelControl m_ModelControl;

    private void Awake()
    {
        m_ModelControl = GameObject.Find("Scenes_Control").GetComponent<SC_ModelControl>();
    }

    void OnTriggerEnter(Collider collisionInfo)
    {
        if (m_ModelControl.m_OrderNumber == 4)
        {
            if (collisionInfo.gameObject.name == "Controller (left)")
            {
                m_ModelControl.m_UIObject[2].SetActive(false);
                for (int i = 0; i < m_ModelControl.m_Arrow2.Length; i++)
                {
                    m_ModelControl.m_Arrow2[i].SetActive(false);
                }
                m_ModelControl.m_UIObject[3].SetActive(true);
                for (int i = 0; i < m_ModelControl.m_Arrow3.Length; i++)
                {
                    m_ModelControl.m_Arrow3[i].SetActive(true);
                }
                m_ModelControl.m_CameraRig.transform.position = new Vector3(0.35f, 15.8f, 6.87f);
                //m_ModelControl.m_CameraRig.transform.DOMove(new Vector3(0.35f, 15.8f, 6.87f), 2f);
                m_ModelControl.m_OrderNumber = 5;
            }
            else if (collisionInfo.gameObject.name == "Controller (right)")
            {
                m_ModelControl.m_UIObject[2].SetActive(false);
                for (int i = 0; i < m_ModelControl.m_Arrow2.Length; i++)
                {
                    m_ModelControl.m_Arrow2[i].SetActive(false);
                }
                m_ModelControl.m_UIObject[3].SetActive(true);
                for (int i = 0; i < m_ModelControl.m_Arrow3.Length; i++)
                {
                    m_ModelControl.m_Arrow3[i].SetActive(true);
                }
                m_ModelControl.m_CameraRig.transform.position = new Vector3(0.35f, 15.8f, 6.87f);
                //m_ModelControl.m_CameraRig.transform.DOMove(new Vector3(0.35f, 15.8f, 6.87f), 2f);
                m_ModelControl.m_OrderNumber = 5;
            }
        }
    }
}

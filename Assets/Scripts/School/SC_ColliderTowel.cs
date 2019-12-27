using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_ColliderTowel : MonoBehaviour
{
    private SC_ModelControl m_ModelControl;
    private SC_SceneControl m_SceneControl;

    private void Awake()
    {
        m_ModelControl = GameObject.Find("Scenes_Control").GetComponent<SC_ModelControl>();
        m_SceneControl = GameObject.Find("Scenes_Control").GetComponent<SC_SceneControl>();
    }

    void OnTriggerEnter(Collider collisionInfo)
    {
        if (m_ModelControl.m_OrderNumber == 5)
        {
            if (collisionInfo.gameObject.name == "Controller (left)")
            {
                m_ModelControl.m_Towel.SetActive(false);
                m_ModelControl.m_UIObject[3].SetActive(false);
                for (int i = 0; i < m_ModelControl.m_Arrow3.Length; i++)
                {
                    m_ModelControl.m_Arrow3[i].SetActive(false);
                }
                m_ModelControl.m_UIObject[4].SetActive(true);
                for (int i = 0; i < m_ModelControl.m_Arrow5.Length; i++)
                {
                    m_ModelControl.m_Arrow5[i].SetActive(true);
                }
                for (int i = 0; i < m_ModelControl.m_Arrow4.Length; i++)
                {
                    m_ModelControl.m_Arrow4[i].SetActive(true);
                }
                //m_ModelControl.m_CameraRig.transform.position = new Vector3(-0.59f, 15.8f, 12.11f);
                //m_ModelControl.m_CameraRig.transform.DOMove(new Vector3(-0.59f, 15.8f, 12.11f), 2f);
                m_ModelControl.m_OrderNumber = 6;
                m_SceneControl.Throng_Move();
            }
            else if (collisionInfo.gameObject.name == "Controller (right)")
            {
                m_ModelControl.m_Towel.SetActive(false);
                m_ModelControl.m_UIObject[3].SetActive(false);
                for (int i = 0; i < m_ModelControl.m_Arrow3.Length; i++)
                {
                    m_ModelControl.m_Arrow3[i].SetActive(false);
                }
                m_ModelControl.m_UIObject[4].SetActive(true);
                for (int i = 0; i < m_ModelControl.m_Arrow5.Length; i++)
                {
                    m_ModelControl.m_Arrow5[i].SetActive(true);
                }
                for (int i = 0; i < m_ModelControl.m_Arrow4.Length; i++)
                {
                    m_ModelControl.m_Arrow4[i].SetActive(true);
                }
                //m_ModelControl.m_CameraRig.transform.position = new Vector3(-0.59f, 15.8f, 12.11f);
                //m_ModelControl.m_CameraRig.transform.DOMove(new Vector3(-0.59f, 15.8f, 12.11f), 2f);
                m_ModelControl.m_OrderNumber = 6;
                m_SceneControl.Throng_Move();
            }
        }
    }
}

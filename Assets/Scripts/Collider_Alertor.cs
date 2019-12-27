using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider_Alertor : MonoBehaviour
{
    private Model_Control m_ModelControl;

    private void Awake()
    {
        m_ModelControl = GameObject.Find("Scenes_Control").GetComponent<Model_Control>();
    }

    void OnTriggerEnter(Collider collisionInfo)
    {
        if (m_ModelControl.m_OrderNumber == 3)
        {
            if (collisionInfo.gameObject.name == "Controller (left)")
            {
                m_ModelControl.m_UIObject[4].SetActive(true);
                m_ModelControl.m_Arrow2[4].SetActive(false);
                m_ModelControl.m_OrderNumber = 4;
            }
            if (collisionInfo.gameObject.name == "Controller (right)")
            {
                m_ModelControl.m_UIObject[4].SetActive(true);
                m_ModelControl.m_Arrow2[4].SetActive(false);
                m_ModelControl.m_OrderNumber = 4;
            }
        }
    }
}

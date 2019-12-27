using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_HandControl : MonoBehaviour
{
    private SC_ModelControl m_ModelControl;
    private SC_SceneControl m_ScenesControl;

    private void Awake()
    {
        m_ModelControl = GameObject.Find("Scenes_Control").GetComponent<SC_ModelControl>();
        m_ScenesControl = GameObject.Find("Scenes_Control").GetComponent<SC_SceneControl>();
    }

    void OnTriggerEnter(Collider collisionInfo)
    {
        if (m_ModelControl.m_OrderNumber == 1)
        {
            if (m_ScenesControl.m_HandType == SC_HandType.Left)
            {
                switch (collisionInfo.gameObject.name)
                {
                    case "Extinguisher0":
                        m_ModelControl.m_Extinguisher[0].SetActive(false);
                        m_ModelControl.m_ExtinguisherLeftHand.SetActive(true);
                        m_ModelControl.m_OrderNumber = 2;
                        break;
                    case "Extinguisher1":
                        m_ModelControl.m_Extinguisher[1].SetActive(false);
                        m_ModelControl.m_ExtinguisherLeftHand.SetActive(true);
                        m_ModelControl.m_OrderNumber = 2;
                        break;
                    case "Extinguisher2":
                        m_ModelControl.m_Extinguisher[2].SetActive(false);
                        m_ModelControl.m_ExtinguisherLeftHand.SetActive(true);
                        m_ModelControl.m_OrderNumber = 2;
                        break;
                    default:
                        break;
                }
            }
            else if (m_ScenesControl.m_HandType == SC_HandType.Right)
            {
                switch (collisionInfo.gameObject.name)
                {
                    case "Extinguisher0":
                        m_ModelControl.m_Extinguisher[0].SetActive(false);
                        m_ModelControl.m_ExtinguisherRightHand.SetActive(true);
                        m_ModelControl.m_OrderNumber = 2;
                        break;
                    case "Extinguisher1":
                        m_ModelControl.m_Extinguisher[1].SetActive(false);
                        m_ModelControl.m_ExtinguisherRightHand.SetActive(true);
                        m_ModelControl.m_OrderNumber = 2;
                        break;
                    case "Extinguisher2":
                        m_ModelControl.m_Extinguisher[2].SetActive(false);
                        m_ModelControl.m_ExtinguisherRightHand.SetActive(true);
                        m_ModelControl.m_OrderNumber = 2;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}

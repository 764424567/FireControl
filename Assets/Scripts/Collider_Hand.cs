using UnityEngine;

//手柄上的碰撞器
public class Collider_Hand : MonoBehaviour
{
    private Model_Control m_ModelControl;
    private Scenes_Control m_ScenesControl;

    private void Awake()
    {
        m_ModelControl = GameObject.Find("Scenes_Control").GetComponent<Model_Control>();
        m_ScenesControl= GameObject.Find("Scenes_Control").GetComponent<Scenes_Control>();
    }

    void OnTriggerEnter(Collider collisionInfo)
    {
        if (m_ModelControl.m_OrderNumber == 1)
        {
            if (m_ScenesControl.m_HandType == HandType.Left)
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
            else if (m_ScenesControl.m_HandType == HandType.Right)
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
        if (m_ModelControl.m_OrderNumber == 4)
        {
            if (collisionInfo.gameObject.name == "AlertorBoxCollider")
            {
                m_ModelControl.m_UIObject[3].SetActive(false);
                m_ModelControl.m_UIObject[4].SetActive(true);
                m_ModelControl.m_Arrow2[4].SetActive(false);
                m_ModelControl.m_AlertorWall.SetActive(false);
                m_ModelControl.m_OrderNumber = 5;
            }
        }
    }
}

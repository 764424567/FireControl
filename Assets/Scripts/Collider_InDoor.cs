using UnityEngine;
using DG.Tweening;

//室内碰撞器
public class Collider_InDoor : MonoBehaviour
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
            if (collisionInfo.gameObject.name == "[CameraRig]")
            {
                m_ModelControl.m_UIObject[2].SetActive(false);
                m_ModelControl.m_UIObject[3].SetActive(true);
                //m_ModelControl.m_CameraRig.transform.position = new Vector3(1.2f, 19.6f, 37.38f);
                m_ModelControl.m_CameraRig.transform.DOMove(new Vector3(1.2f, 19.6f, 37.38f), 2f);
                //m_ModelControl.m_CameraRig.transform.DORotate(new Vector3(0, -270, 0), 2f);
                m_ModelControl.m_Alertor.SetActive(true);
                m_ModelControl.m_OrderNumber = 4;
                for (int i = 0; i < m_ModelControl.m_Arrow1.Length; i++)
                {
                    m_ModelControl.m_Arrow1[i].SetActive(false);
                }
                for (int i = 0; i < m_ModelControl.m_Arrow2.Length; i++)
                {
                    m_ModelControl.m_Arrow2[i].SetActive(true);
                }
            }
        }
    }
}

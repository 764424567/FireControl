using UnityEngine;
using DG.Tweening;

//室内碰撞器
public class SC_ColliderInDoor : MonoBehaviour
{
    private SC_ModelControl m_ModelControl;

    private void Awake()
    {
        m_ModelControl = GameObject.Find("Scenes_Control").GetComponent<SC_ModelControl>();
    }

    void OnTriggerEnter(Collider collisionInfo)
    {
        if (m_ModelControl.m_OrderNumber == 3)
        {
            if (collisionInfo.gameObject.name == "[CameraRig]")
            {
                m_ModelControl.m_UIObject[1].SetActive(false);
                m_ModelControl.m_UIObject[2].SetActive(true);
                //初始 -4.9f,15.8f,-17.53f
                //警铃 -0.26f,15.8f,-2.5f
                //水池 0.35f,15.8f,6.87f
                //下楼 -0.59f,15.8f,12.11f
                //m_ModelControl.m_CameraRig.transform.DOMove(new Vector3(-0.26f, 15.8f, -2.5f), 2f);
                m_ModelControl.m_CameraRig.transform.position = new Vector3(-0.26f, 15.8f, -2.5f);
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

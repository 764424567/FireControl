using UnityEngine;

//室外碰撞器
public class SC_ColliderSafeArea : MonoBehaviour
{
    private SC_ModelControl m_ModelControl;

    private void Awake()
    {
        m_ModelControl = GameObject.Find("Scenes_Control").GetComponent<SC_ModelControl>();
    }

    void OnTriggerEnter(Collider collisionInfo)
    {
        if (m_ModelControl.m_OrderNumber == 6)
        {
            if (collisionInfo.gameObject.name == "[CameraRig]")
            {
                m_ModelControl.m_UIObject[4].SetActive(false);
                m_ModelControl.m_UIObject[5].SetActive(true);
                for (int i = 0; i < m_ModelControl.m_Arrow4.Length; i++)
                {
                    m_ModelControl.m_Arrow4[i].SetActive(false);
                }
                m_ModelControl.m_OrderNumber = 7;
            }
        }
    }
}

using UnityEngine;

//室外碰撞器
public class Collider_SafeArea : MonoBehaviour
{
    private Model_Control m_ModelControl;

    private void Awake()
    {
        m_ModelControl = GameObject.Find("Scenes_Control").GetComponent<Model_Control>();
    }

    void OnTriggerEnter(Collider collisionInfo)
    {
        if (m_ModelControl.m_OrderNumber == 5)
        {
            if (collisionInfo.gameObject.name == "[CameraRig]")
            {
                m_ModelControl.m_UIObject[5].SetActive(true);
                m_ModelControl.m_OrderNumber = 6;
            }
        }
    }
}

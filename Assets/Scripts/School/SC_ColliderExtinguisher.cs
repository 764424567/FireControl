using System.Collections;
using UnityEngine;

//灭火器的碰撞器
public class SC_ColliderExtinguisher : MonoBehaviour
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
        if (collisionInfo.gameObject.name == "FireBoxCollider")
        {
            //火粒子消失 火声音暂停  灭火器消失
            if (m_ScenesControl.m_HandType == SC_HandType.Left)
            {
                StartCoroutine(OutFire());
            }
            else if(m_ScenesControl.m_HandType == SC_HandType.Right)
            {
                StartCoroutine(OutFireRight());
            }
        }
    }

    void OnTriggerExit(Collider collisionInfo)
    {
        if (collisionInfo.gameObject.name == "FireBoxCollider")
        {
            StopAllCoroutines();
        }
    }

    IEnumerator OutFire()
    {
        yield return new WaitForSeconds(2.5f);
        m_ModelControl.m_ParticleObject[0].SetActive(false);
        m_ModelControl.m_ParticleObject[1].SetActive(true);
        m_ModelControl.m_AudioObject[1].Pause();
        m_ModelControl.m_UIObject[1].SetActive(true);
        m_ModelControl.m_AudioObject[0].Pause();
        for (int i = 0; i < m_ModelControl.m_Arrow1.Length; i++)
        {
            m_ModelControl.m_Arrow1[i].SetActive(true);
        }
        m_ModelControl.m_OrderNumber = 3;
        m_ModelControl.m_ExtinguisherLeftHand.SetActive(false); 
    }
    IEnumerator OutFireRight()
    {
        yield return new WaitForSeconds(2.5f);
        m_ModelControl.m_ParticleObject[0].SetActive(false);
        m_ModelControl.m_ParticleObject[1].SetActive(true);
        m_ModelControl.m_AudioObject[1].Pause();
        m_ModelControl.m_UIObject[1].SetActive(true);
        m_ModelControl.m_AudioObject[2].Pause();
        for (int i = 0; i < m_ModelControl.m_Arrow1.Length; i++)
        {
            m_ModelControl.m_Arrow1[i].SetActive(true);
        }
        m_ModelControl.m_OrderNumber = 3;
        m_ModelControl.m_ExtinguisherRightHand.SetActive(false);
    }
}


using System.Collections;
using UnityEngine;

//灭火器的碰撞器
public class Collider_Extinguisher : MonoBehaviour
{
    private Model_Control m_ModelControl;
    private Scenes_Control m_ScenesControl;

    private void Awake()
    {
        m_ModelControl = GameObject.Find("Scenes_Control").GetComponent<Model_Control>();
        m_ScenesControl = GameObject.Find("Scenes_Control").GetComponent<Scenes_Control>();
    }

    void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.gameObject.name == "FireBoxCollider")
        {
            //火粒子消失 火声音暂停  灭火器消失
            if (m_ScenesControl.m_HandType == HandType.Left)
            {
                StartCoroutine(OutFire());
            }
            else if(m_ScenesControl.m_HandType == HandType.Right)
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
        yield return new WaitForSeconds(1.5f);
        m_ModelControl.m_ParticleObject[0].SetActive(false);
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
        yield return new WaitForSeconds(1.5f);
        m_ModelControl.m_ParticleObject[0].SetActive(false);
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


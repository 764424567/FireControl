using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_SceneControl : MonoBehaviour
{
    //模型控制对象
    private SC_ModelControl m_ModelControl;
    //左手柄或者右手柄
    public SteamVR_TrackedObject m_TrackedObjLeft;
    public SteamVR_TrackedObject m_TrackedObjRight;
    //随机数
    private int m_RandomNum = 1;
    //时间间隔
    private float m_TimeBetween = 0;
    //生成敌人
    private bool m_IsProduce = false;
    //灭火器开关
    private bool m_IsFlame = true;
    //左右手
    [HideInInspector]
    public SC_HandType m_HandType = SC_HandType.Default;
 
    // Use this for initialization
    void Start()
    {
        m_ModelControl = GameObject.Find("Scenes_Control").GetComponent<SC_ModelControl>();
        m_ModelControl.m_UIObject[0].SetActive(true);
        m_ModelControl.m_ParticleObject[0].SetActive(true);
        m_ModelControl.m_AudioObject[1].Play();
        //测试
        //m_ModelControl.m_OrderNumber = 6;
        //m_IsProduce = true;
    }

    // Update is called once per frame
    void Update()
    {
        //随机数生成
        if (m_ModelControl.m_OrderNumber == 6 && m_IsProduce)
        {
            m_RandomNum = Random.Range(1, m_ModelControl.m_Target.Length);
            int IntRandomNum = m_RandomNum;
            m_TimeBetween += Time.deltaTime;
            if (m_TimeBetween >= 5)
            {
                m_TimeBetween = 0;
                Instantiate(m_ModelControl.m_ThrongObj, m_ModelControl.m_Target[IntRandomNum].transform.position, Quaternion.identity, m_ModelControl.m_Parent.transform);
            }
        } 

        SteamVR_Controller.Device deviceLeft = SteamVR_Controller.Input((int)m_TrackedObjLeft.index);
        SteamVR_Controller.Device deviceRight = SteamVR_Controller.Input((int)m_TrackedObjRight.index);

        //左手
        if (deviceLeft.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad) && m_ModelControl.m_OrderNumber == 0)
        {
            //UI隐藏
            m_ModelControl.m_UIObject[0].SetActive(false);
            m_ModelControl.m_OrderNumber = 1;
            m_HandType = SC_HandType.Left;
        }
        else if (deviceLeft.GetPressDown(SteamVR_Controller.ButtonMask.Trigger) && m_ModelControl.m_OrderNumber == 0)
        {
            //UI隐藏
            m_ModelControl.m_UIObject[0].SetActive(false);
            m_ModelControl.m_OrderNumber = 1;
            m_HandType = SC_HandType.Left;
        }
        else if (deviceLeft.GetPressDown(SteamVR_Controller.ButtonMask.Trigger) && m_ModelControl.m_OrderNumber == 2)
        {
            if (m_IsFlame && m_HandType == SC_HandType.Left)
            {
                StartCoroutine(OutFireAniControlLeft());
            }
        }

        //右手
        if (deviceRight.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad) && m_ModelControl.m_OrderNumber == 0)
        {
            //UI隐藏
            m_ModelControl.m_UIObject[0].SetActive(false);
            m_ModelControl.m_OrderNumber = 1;
            m_HandType = SC_HandType.Left;
        }
        else if (deviceRight.GetPressDown(SteamVR_Controller.ButtonMask.Trigger) && m_ModelControl.m_OrderNumber == 0)
        {
            //UI隐藏
            m_ModelControl.m_UIObject[0].SetActive(false);
            m_ModelControl.m_OrderNumber = 1;
            m_HandType = SC_HandType.Left;
        }
        else if (deviceRight.GetPressDown(SteamVR_Controller.ButtonMask.Trigger) && m_ModelControl.m_OrderNumber == 2)
        {
            if (m_IsFlame && m_HandType == SC_HandType.Left)
            {
                StartCoroutine(OutFireAniControlLeft());
            }
        }
    }

    public void Throng_Move()
    {
        m_IsProduce = true;
        //人群随机生成，自动寻路
    }

    IEnumerator OutFireAniControlLeft()
    {
        //灭火器关闭
        m_IsFlame = false;
        //灭火器动画 灭火器粒子特效 灭火器音效
        m_ModelControl.m_AniObject[0].GetComponent<Animation>().Play("miehuo");
        yield return new WaitForSeconds(3.5f);
        m_ModelControl.m_ParticleObject[2].SetActive(true);
        m_ModelControl.m_AudioObject[0].Play();
    }

    IEnumerator OutFireAniControlRight()
    {
        //灭火器关闭
        m_IsFlame = false;
        //灭火器动画 灭火器粒子特效 灭火器音效
        m_ModelControl.m_AniObject[1].GetComponent<Animation>().Play("miehuo");
        yield return new WaitForSeconds(3.5f);
        m_ModelControl.m_ParticleObject[3].SetActive(true);
        m_ModelControl.m_AudioObject[2].Play();
    }
}

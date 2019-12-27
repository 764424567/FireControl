using System.Collections;
using UnityEngine;

public class Scenes_Control : MonoBehaviour
{
    //模型控制对象
    private Model_Control m_ModelControl;
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
    public HandType m_HandType = HandType.Default;

    // Use this for initialization
    void Start()
    {
        m_ModelControl = GameObject.Find("Scenes_Control").GetComponent<Model_Control>();
        m_ModelControl.m_UIObject[0].SetActive(true);
        m_ModelControl.m_ParticleObject[0].SetActive(true);
        m_ModelControl.m_AudioObject[1].Play();

        //测试：生成人群
        //m_ModelControl.m_OrderNumber = 5;
        //m_IsProduce = true;
    }

    // Update is called once per frame
    void Update()
    {
        //随机数生成
        if (m_ModelControl.m_OrderNumber == 5 && m_IsProduce)
        {
            m_RandomNum = Random.Range(1, m_ModelControl.m_Target.Length);
            int IntRandomNum = m_RandomNum;
            m_TimeBetween += Time.deltaTime;
            if (m_TimeBetween >= 3)
            { 
                m_TimeBetween = 0;
                Instantiate(m_ModelControl.m_ThrongObj, m_ModelControl.m_Target[IntRandomNum].transform.position, Quaternion.identity, m_ModelControl.m_Parent.transform);
            }
        }

        SteamVR_Controller.Device deviceLeft = SteamVR_Controller.Input((int)m_TrackedObjLeft.index);
        SteamVR_Controller.Device deviceRight = SteamVR_Controller.Input((int)m_TrackedObjRight.index);
        if (deviceLeft.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad)&& m_ModelControl.m_OrderNumber == 0)
        {
            //UI隐藏
            m_ModelControl.m_UIObject[0].SetActive(false);
            m_ModelControl.m_OrderNumber = 1;
            m_HandType = HandType.Left;
        }
        else if (deviceLeft.GetPressDown(SteamVR_Controller.ButtonMask.Trigger) && m_ModelControl.m_OrderNumber == 0)
        {
            //UI隐藏
            m_ModelControl.m_UIObject[0].SetActive(false);
            m_ModelControl.m_OrderNumber = 1;
            m_HandType = HandType.Left;
        }
        else if (deviceLeft.GetPressDown(SteamVR_Controller.ButtonMask.Trigger) && m_ModelControl.m_OrderNumber == 2)
        {
            if (m_IsFlame && m_HandType==HandType.Left)
            {
                StartCoroutine(OutFireAniControlLeft());
            }
        }
        else if (deviceLeft.GetPressDown(SteamVR_Controller.ButtonMask.Trigger) && m_ModelControl.m_OrderNumber == 5)
        {
            //自动生成人群
            Throng_Move();
        }

        if (deviceRight.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad) && m_ModelControl.m_OrderNumber == 0)
        {
            //UI隐藏
            m_ModelControl.m_UIObject[0].SetActive(false);
            m_ModelControl.m_OrderNumber = 1;
            m_HandType = HandType.Right;
        }
        else if (deviceRight.GetPressDown(SteamVR_Controller.ButtonMask.Trigger) && m_ModelControl.m_OrderNumber == 0)
        {
            //UI隐藏
            m_ModelControl.m_UIObject[0].SetActive(false);
            m_ModelControl.m_OrderNumber = 1;
            m_HandType = HandType.Right;
        }
        else if (deviceRight.GetPressDown(SteamVR_Controller.ButtonMask.Trigger) && m_ModelControl.m_OrderNumber == 2)
        {
            if (m_IsFlame && m_HandType == HandType.Right)
            {
                StartCoroutine(OutFireAniControlRight());
            }
        }
        else if (deviceRight.GetPressDown(SteamVR_Controller.ButtonMask.Trigger) && m_ModelControl.m_OrderNumber == 3)
        {
            m_ModelControl.m_UIObject[1].SetActive(false);
            m_ModelControl.m_UIObject[2].SetActive(true);
        }
        else if (deviceRight.GetPressDown(SteamVR_Controller.ButtonMask.Trigger) && m_ModelControl.m_OrderNumber == 5)
        {
            //自动生成人群
            Throng_Move();
        }
    }

    public void Throng_Move()
    {
        m_IsProduce = true;
        m_ModelControl.m_UIObject[4].SetActive(false);
        m_ModelControl.m_Alertor.SetActive(false);
        //路面指示箭头显示
        //人群随机生成，自动寻路
        for (int i = 0; i < m_ModelControl.m_Arrow3.Length; i++)
        {
            m_ModelControl.m_Arrow3[i].SetActive(true);
        }
    }

    IEnumerator OutFireAniControlLeft()
    {
        //灭火器关闭
        m_IsFlame = false;
        //灭火器动画 灭火器粒子特效 灭火器音效
        m_ModelControl.m_AniObject[0].GetComponent<Animation>().Play("miehuo");
        yield return new WaitForSeconds(4.0f);
        m_ModelControl.m_ParticleObject[1].SetActive(true);
        m_ModelControl.m_AudioObject[0].Play();
    }

    IEnumerator OutFireAniControlRight()
    {
        //灭火器关闭
        m_IsFlame = false;
        //灭火器动画 灭火器粒子特效 灭火器音效
        m_ModelControl.m_AniObject[1].GetComponent<Animation>().Play("miehuo");
        yield return new WaitForSeconds(4.0f);
        m_ModelControl.m_ParticleObject[2].SetActive(true);
        m_ModelControl.m_AudioObject[2].Play();
    }
}

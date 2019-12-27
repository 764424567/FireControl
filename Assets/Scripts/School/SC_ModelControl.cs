using UnityEngine;

//手柄左右手
public enum SC_HandType
{
    Default,
    Left,
    Right
}
//模型对象类
public class SC_ModelControl : MonoBehaviour
{
    //手柄上的灭火器
    public GameObject m_ExtinguisherLeftHand;
    public GameObject m_ExtinguisherRightHand;
    //头盔位置
    public GameObject m_CameraRig;
    //人物对象
    public GameObject m_ThrongObj;
    //父对象
    public GameObject m_Parent;
    //毛巾
    public GameObject m_Towel;
    //灭火器
    public GameObject[] m_Extinguisher;
    //动画对象
    public GameObject[] m_AniObject;
    //音频对象
    public AudioSource[] m_AudioObject;
    //粒子对象
    public GameObject[] m_ParticleObject;
    //UI对象
    public GameObject[] m_UIObject;
    //流程控制
    [HideInInspector]
    public int m_OrderNumber = 0;
    //箭头
    public GameObject[] m_Arrow1;
    public GameObject[] m_Arrow2;
    public GameObject[] m_Arrow3;
    public GameObject[] m_Arrow4;
    public GameObject[] m_Arrow5;
    //目标点
    public GameObject[] m_Target;
   

    void Awake()
    {
        for (int i = 0; i < m_UIObject.Length; i++)
        {
            m_UIObject[i].SetActive(false);
        }
        for (int i = 0; i < m_ParticleObject.Length; i++)
        {
            m_ParticleObject[i].SetActive(false);
        }
        for (int i = 0; i < m_Arrow1.Length; i++)
        {
            m_Arrow1[i].SetActive(false);
        }
        for (int i = 0; i < m_Arrow2.Length; i++)
        {
            m_Arrow2[i].SetActive(false);
        }
        for (int i = 0; i < m_Arrow3.Length; i++)
        {
            m_Arrow3[i].SetActive(false);
        }
        for (int i = 0; i < m_Arrow4.Length; i++)
        {
            m_Arrow4[i].SetActive(false);
        }
        for (int i = 0; i < m_Arrow5.Length; i++)
        {
            m_Arrow5[i].SetActive(false);
        }
    }
}

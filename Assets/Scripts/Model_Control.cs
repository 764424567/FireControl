using UnityEngine;

//手柄左右手
public enum HandType
{
    Default,
    Left,
    Right
}
//模型对象类
public class Model_Control : MonoBehaviour
{
    //灭火器
    public GameObject[] m_Extinguisher;
    //左手柄上的灭火器
    public GameObject m_ExtinguisherLeftHand;
    public GameObject m_ExtinguisherRightHand;
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
    //头盔位置
    public GameObject m_CameraRig;
    //目标点
    public GameObject[] m_Target;
    //人物对象
    public GameObject m_ThrongObj;
    //父对象
    public GameObject m_Parent;
    //报警器高亮
    public GameObject m_Alertor;
    //报警器阻挡墙壁
    public GameObject m_AlertorWall;

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
        m_Alertor.SetActive(false);
    }
}

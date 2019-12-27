using UnityEngine;

public class Arrow_Control : MonoBehaviour
{
    //所有的图片路径
    private string[] m_Url;
    //图片名称
    private string m_Name = "Arrow/JianTou_";
    //切换图片的时间
    private float m_Time = 0;
    //图片计数器
    private int TeInt = 0;
    //切换图片的间隔比例
    private float m_Fps = 25;
    //自身的Renderer组件
    private Renderer m_Image;

    void Start()
    {
        //初始化路径字段
        m_Url = new string[27];
        //获取到自身的Renderer
        m_Image = gameObject.GetComponent<Renderer>();
    }


    void Update()
    {
        m_Time += Time.deltaTime;
        // 0.04秒更换一次图片
        if (m_Time >= 1.0 / m_Fps)
        {
            TeInt++;
            m_Time = 0;
        }
        //计数器读取到最后一张图片之后
        if (TeInt > m_Url.Length - 1)
        {   
            TeInt = 0;
        }
        //数组赋值，图片的名字
        m_Url[TeInt] = m_Name + TeInt.ToString();
        //赋值
        m_Image.material.mainTexture = Resources.Load(m_Url[TeInt]) as Texture2D;
    }
}

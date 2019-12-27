using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//模式
public enum Mode
{
    BrowseMode,//浏览模式
    StudyMode,//学习模式
    ExamMode//考试模式
}
//火灾情况
public enum FireCase
{
    Electric,//电器失火
    Furniture,//家具失火
    Wire,//电线失火
    Tinder,//易燃物失火
    PowerBank//充电宝爆炸
}
public class StudyModeModel_Control : MonoBehaviour
{
    //流程控制
    [HideInInspector]
    public int m_OrderNumber = 0;
}

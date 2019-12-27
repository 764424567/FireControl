using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Index_Control : MonoBehaviour
{
    Button m_ButtonBrowse;
    Button m_ButtonStudy;
    Button m_ButtonExam;

    void Start()
    {
        m_ButtonBrowse= GameObject.Find("Button_Browse").GetComponent<Button>();
        m_ButtonStudy = GameObject.Find("Button_Study").GetComponent<Button>();
        m_ButtonExam = GameObject.Find("Button_Exam").GetComponent<Button>();
        m_ButtonBrowse.onClick.AddListener(delegate () { ButtonOnClick_Event("BrowseMode"); });
        m_ButtonStudy.onClick.AddListener(delegate () { ButtonOnClick_Event("StudyMode"); });
        m_ButtonExam.onClick.AddListener(delegate () { ButtonOnClick_Event("ExamMode"); });
    }

    void ButtonOnClick_Event(string sceneName)
    {
        
        switch (sceneName)
        {
            case "BrowseMode":
                SceneManager.LoadScene("BrowseMode");
                break;
            case "StudyMode":
                SceneManager.LoadScene("StudyMode");
                break;
            case "ExamMode":
                SceneManager.LoadScene("ExamMode");
                break;
            default:
                break;
        }
    }
}

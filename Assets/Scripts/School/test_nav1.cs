﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class test_nav1 : MonoBehaviour
{
    private NavMeshAgent m_Agent;
    private GameObject m_Target;
    private SC_ModelControl m_ModelControl;
    float m_Random = 1f;
    
    // Use this for initialization
    void Start()
    {
        m_ModelControl = GameObject.Find("Scenes_Control").GetComponent<SC_ModelControl>();
        m_Agent = GetComponent<NavMeshAgent>();
        m_Target = GameObject.Find("Target01");
        m_Random = Random.Range(2.5f, 3.5f);
        m_Agent.speed = m_Random;
    }

    // Update is called once per frame
    void Update()
    {
        m_Agent.SetDestination(m_Target.transform.position);
    }

    void OnTriggerEnter(Collider collisionInfo)
    {
        if (m_ModelControl.m_OrderNumber == 5 || m_ModelControl.m_OrderNumber == 6)
        {
            Debug.Log("SC_ModelControl");
            if (collisionInfo.gameObject.name == "SafeAreaBoxCollider")
            {
                Destroy(gameObject);
            }
        }
    }
}

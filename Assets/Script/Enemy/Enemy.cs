using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.AI;

public class Enemy :MonoBehaviour
{
    // Start is called before the first frame update

    private NavMeshAgent agent;

    public Node currentDesc;

    private void Awake()
    {
        agent = this.gameObject.GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        setDesc(currentDesc.gameObject.transform.position);
    }
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (currentDesc.isEnd)
        {
            EnemyArriveEnd();
        }
        if (!currentDesc.isEnd && (Vector3.SqrMagnitude(this.gameObject.transform.position - agent.destination) < agent.stoppingDistance))
        {
            this.currentDesc = this.currentDesc.nextNode;
            Debug.Log(currentDesc);
            setDesc(this.currentDesc.gameObject.transform.position);
        }

    }
    public void setDesc(Vector3 vec3)
    {
        agent.SetDestination(vec3);
    }

    //����ִ��յ���������
    void EnemyArriveEnd()
    {
        EnemyManager.EnemyAliveCount--;
        //���˺��Լ���������
    }
}
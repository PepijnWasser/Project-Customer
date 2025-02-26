﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToQue : MonoBehaviour
{
    List<Vector3> que = new List<Vector3>();

    int targetIndex = 0;
    Vector3 target;

    NavMeshAgent myAgent;

    void Start()
    {
        if(GetComponent<NavMeshAgent>() != null)
        {
            myAgent = GetComponent<NavMeshAgent>();
        }
        else
        {
            Debug.Log("no navmeshagent component found in movetoque");
        }
    }

    void Update() 
    {
        if (transform.GetComponent<MovementQue>() != null)
        {
            que = transform.GetComponent<MovementQue>().que;
        }
        if(que != null && que.Count != 0 && targetIndex < que.Count)
        {
            target = que[targetIndex];           
        }

        Move();
    }

    void Move()
    {
        if (que != null && que.Count != 0)
        {
            if(myAgent != null)
            {
                myAgent.SetDestination(target);
            }
            else
            {
                Debug.Log("could not locate myagent in movetoque");
            }

            if (Vector3.Distance(transform.position, target) < 1)
            {
                if(targetIndex < que.Count - 1)
                {
                    targetIndex += 1;
                }
                else
                {
                    targetIndex = 0;
                }
            }
        }       
    }
}
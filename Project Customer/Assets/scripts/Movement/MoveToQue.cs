using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToQue : MonoBehaviour
{
    public float speed;

    List<Vector3> que = new List<Vector3>();

    int targetIndex = 0;
    Vector3 target;

    NavMeshAgent myAgent;

    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();    
    }

    void Update()
    {
        if (transform.GetComponent<MovementQue>() != null)
        {
            que = transform.GetComponent<MovementQue>().que;
        }
        if(que != null && que.Count != 0)
        {
            target = que[targetIndex];
        }

        Move();
    }

    void Move()
    {
        if (que != null && que.Count != 0)
        {
            myAgent.SetDestination(target);

            if (transform.position == target)
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
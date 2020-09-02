using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToQue : MonoBehaviour
{
    public float speed;
    List<Vector3> que = new List<Vector3>();

    void Update()
    {
        if (transform.GetComponent<MovementQue>() != null)
        {
            que = transform.GetComponent<MovementQue>().que;
        }
        Move();
    }

    void Move()
    {
        if (que != null && que.Count != 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, que[0], speed * Time.deltaTime);
        }
    }
}
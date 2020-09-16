using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementQueAesthetics : MonoBehaviour
{
    List<Transform> queNodes = new List<Transform>();
    private List<Vector3> que = new List<Vector3>();
    public Transform queNode;

    void Update()
    {
        if (GetComponent<MovementQue>() != null)
        {
            que = GetComponent<MovementQue>().que;
        }
        else
        {
            Debug.Log("cannot locate movementque component in movementqueaesthetics");
        }

        SpawnNodes();
        DestroyNodes();
    }

    void SpawnNodes()
    {
        foreach (Vector3 coordinate in que)
        {
            bool needToSpawn = true;
            foreach (Transform queNode in queNodes)
            {
                if (queNode.position == coordinate)
                {
                    needToSpawn = false;
                    break;
                }
            }
            if (needToSpawn == true)
            {
                Transform newNode = Instantiate(queNode, coordinate, Quaternion.identity);
                newNode.GetComponent<DeleteNode>().objectCreatedFor = transform;
                queNodes.Add(newNode);
            }
        }
    }

    void DestroyNodes()
    {
        List<Transform> nodesToDestroy = new List<Transform>();
        foreach(Transform Node in queNodes)
        {
            bool needToDestroy = true;
            if(que.Contains(Node.position)){
                needToDestroy = false;
            }
            if(needToDestroy == true)
            {
                nodesToDestroy.Add(Node);
            }
        }

        foreach(Transform Node in nodesToDestroy)
        {
            queNodes.Remove(Node);
            Destroy(Node.gameObject);         
        }
    }
}

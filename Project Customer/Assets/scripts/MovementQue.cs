using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using UnityEngine.UIElements;

public class MovementQue : MonoBehaviour
{
    bool selected;
    public List<Vector3> que = new List<Vector3>();

    void Update()
    {
        if(transform.GetComponent<BoatSelected>() != null)
        {
            selected = transform.GetComponent<BoatSelected>().selected;
        }       
        if(selected == true)
        {
            UpdateQue();           
        }
    }

    void UpdateQue()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ClearLog();
            Debug.Log("Mouse is down");

            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit)
            {
                Debug.Log("Hit " + hitInfo.transform.gameObject.name);
                if (hitInfo.transform.gameObject.tag == "Water")
                {
                    Debug.Log("It's working!");
                    AddPositionToQue(hitInfo.point);
                }
                else
                {
                    Debug.Log("nopz");
                }
            }
            else
            {
                Debug.Log("No hit");
            }
            Debug.Log("Mouse is down");
        }

        if(que != null && que.Count != 0)
        {
            if (transform.position == que[0])
            {
                que.RemoveAt(0);
            }
            Debug.Log(que.Count);
        }

    }

    void AddPositionToQue(Vector3 newPosition)
    {
        newPosition.y = transform.position.y;
        que.Add(newPosition);
    }

    void ClearLog() //you can copy/paste this code to the bottom of your script
    {
        var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }
}
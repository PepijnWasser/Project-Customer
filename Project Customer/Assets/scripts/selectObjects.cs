using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class selectObjects : MonoBehaviour
{
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            ClearLog();
            Debug.Log("Mouse is down");

            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit)
            {
                Debug.Log("Hit " + hitInfo.transform.gameObject.name);
                if (hitInfo.transform.gameObject.tag == "Boat")
                {
                    Debug.Log("It's working!");
                    SelectBoat(hitInfo.transform.gameObject);                       
                }
                else
                {
                    DeselectAll();
                    Debug.Log("nopz");
                }
            }
            else
            {
                Debug.Log("No hit");
            }
            Debug.Log("Mouse is down");
        }
    }

    void SelectBoat(GameObject boat)
    {
        if (boat.GetComponent<BoatSelected>() != null)
        {
            boat.GetComponent<BoatSelected>().selected = true;
        }
        else
        {
            Debug.Log("boat has no boatselected script");
        }
    }

    void DeselectAll()
    {
        GameObject[] boats;
        boats = GameObject.FindGameObjectsWithTag("Boat");
        foreach (GameObject boat in boats)
        {
            if (boat.GetComponent<BoatSelected>() != null)
            {
                boat.GetComponent<BoatSelected>().selected = false;
            }
        }
    }

    void ClearLog() //you can copy/paste this code to the bottom of your script
    {
        var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteNode : MonoBehaviour
{
    bool selected;
    public Transform objectCreatedFor;
    
    void Update()
    {
        selected = GetComponent<Selected>().selected;
        
        if(selected == true)
        {
            if (Input.GetKey(KeyCode.Delete) || Input.GetKey(KeyCode.Backspace))
            {               
                objectCreatedFor.GetComponent<MovementQue>().RemoveCoordinateFromQue(transform.position);
                GameObject selectionManager = GameObject.FindGameObjectWithTag("LevelManager");
                selectionManager.GetComponent<SelectionManager>().selectedObjects.Remove(gameObject);
            }
        }        
    }

    
}

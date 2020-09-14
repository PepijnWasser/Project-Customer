using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using UnityEngine.UIElements;

public class MovementQue : MonoBehaviour
{
    public bool smallWater;
    bool selected;
    private List<GameObject> selectedObjects = new List<GameObject>();
    public List<Vector3> que = new List<Vector3>();
    private List<Vector3> coordinatesToRemove = new List<Vector3>();
    private Dictionary<Vector3, int> positionsToAdd = new Dictionary<Vector3, int>();


    void Update()
    {
        selectedObjects = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<SelectionManager>().selectedObjects;
        if (transform.GetComponent<Selected>() != null)
        {
            selected = transform.GetComponent<Selected>().selected;
        }
        CheckForQueChange();
    }

    void CheckForQueChange()
    {
<<<<<<< HEAD
        if (selected == true && GameObject.FindGameObjectWithTag("Camera Pivot").GetComponent<ChangeCamera>().camMode == ChangeCamera.CamMode.tilted)
=======
        if (selected == true)
>>>>>>> parent of 607d604... Revert "proj luc"
        {
            if (Input.GetMouseButtonDown(1))
            {
                RaycastHit hitInfo = new RaycastHit();
                bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
                if (hit)
                {
                    if (hitInfo.transform.gameObject.tag == "Water" || (smallWater && hitInfo.transform.gameObject.tag == "River"))
                    {
                        GameObject myNode = null;
                        foreach (GameObject mObject in selectedObjects)
                        {
                            if (mObject.tag == "Node")
                            {
                                if (mObject.GetComponent<DeleteNode>().objectCreatedFor == transform)
                                {
                                    myNode = mObject;
                                }
                            }
                        }
                        if (myNode != null)
                        {
                            AddPositionToAddList(hitInfo.point, que.IndexOf(myNode.transform.position) + 1);
                        }
                        else
                        {
                            if (que == null || que.Count == 0)
                            {
                                AddPositionToAddList(hitInfo.point, 0);
                            }
                            else
                            {
                                AddPositionToAddList(hitInfo.point, que.Count);
                            }
                        }
                    }
                }
            }
        }
    }

    void AddPositionToAddList(Vector3 coordinate, int indexnumber)
    {
        coordinate.y = transform.position.y;
        positionsToAdd.Add(coordinate, indexnumber);
    }

    void RemovePositionToRemoveList(Vector3 coordinate)
    {
        coordinatesToRemove.Add(coordinate);
    }

    public void RemoveCoordinateFromQue(Vector3 input)
    {
        foreach(Vector3 coordinate in que)
        {
            if(coordinate == input)
            {
                RemovePositionToRemoveList(coordinate);
            }
        }
    }

    private void LateUpdate()
    {
        UpdateQue();
    }

    void UpdateQue()
    {
        foreach (KeyValuePair<Vector3, int> keyValue in positionsToAdd)
        {
            que.Insert(keyValue.Value, keyValue.Key);
        }
        foreach (Vector3 coordinate in coordinatesToRemove)
        {
            que.Remove(coordinate);
        }
        coordinatesToRemove.Clear();
        positionsToAdd.Clear();
    }
}
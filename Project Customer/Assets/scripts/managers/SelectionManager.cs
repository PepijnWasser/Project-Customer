using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    [HideInInspector]
    public List<GameObject> selectedObjects = new List<GameObject>();
    Image canvasImage;
    ChangeCamera cam;

    void Start()
    {
        GameObject tempObject = GameObject.Find("sellAndBuyMenuImage");
        if (tempObject != null)
        {
            canvasImage = tempObject.GetComponent<Image>();
            if (canvasImage == null)
            {
                Debug.Log("Could not locate Image component on " + tempObject.name);
            }
        }
    }

    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Camera Pivot").GetComponent<ChangeCamera>() != null)
        {
            cam = GameObject.FindGameObjectWithTag("Camera Pivot").GetComponent<ChangeCamera>();
        }
        else
        {
            Debug.Log("cannot locate cam in selectionManager");
        }
      

        if(cam != null)
        {
            if (cam.camMode == ChangeCamera.CamMode.tilted)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    // do nothing while on sell menu
                    if (TestForMenus() == false)
                    {
                        RaycastHit hitInfo = new RaycastHit();
                        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
                        if (hit)
                        {
                            GameObject objectHit = hitInfo.transform.gameObject;

                            ///
                            //objects
                            ///
                            if (objectHit.tag == "Boat" || objectHit.tag == "harbor" || objectHit.tag == "wareHouse" || objectHit.tag == "Refinery")
                            {
                                DeselectAll();
                                Select(objectHit);
                                selectedObjects.Add(objectHit);
                            }
                            ///
                            //nodes
                            ///
                            else if (objectHit.tag == "Node")
                            {
                                if (CheckIfTagSelected("Boat"))
                                {
                                    if (CheckIfBoatIsNodeParent(GetObjectsWithTag("Boat"), objectHit))
                                    {
                                        if (CheckIfTagSelected("Node"))
                                        {
                                            DeselectSpecific("Node");
                                            Select(objectHit);
                                            selectedObjects.Add(objectHit);
                                        }
                                        else
                                        {
                                            Select(objectHit);
                                            selectedObjects.Add(objectHit);
                                        }
                                    }
                                    else
                                    {
                                        DeselectAll();
                                        Select(objectHit);
                                        selectedObjects.Add(objectHit);
                                    }
                                }
                                else
                                {
                                    DeselectAll();
                                    Select(objectHit);
                                    selectedObjects.Add(objectHit);
                                }
                            }
                            ///
                            //else
                            ///
                            else
                            {
                                DeselectAll();
                            }
                        }
                        else
                        {
                            Debug.Log("No hit on the map in selectionManager");
                        }
                    }

                }
            }
        }
    }

    bool TestForMenus()
    {
        if (testMenus())
        {
            //within the box
            if(Input.mousePosition.x < canvasImage.GetComponent<RectTransform>().position.x + canvasImage.GetComponent<RectTransform>().rect.width / 2 &&          Input.mousePosition.y < canvasImage.GetComponent<RectTransform>().position.y + canvasImage.GetComponent<RectTransform>().rect.height / 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    bool testMenus()
    {
        if (CheckIfTagSelected("harbor") || CheckIfTagSelected("Refinery") || CheckIfTagSelected("wareHouse"))
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    bool CheckIfTagSelected(string tag)
    {
        bool objectfound = false;
        foreach(GameObject sObject in selectedObjects)
        {
            if(sObject.tag == (tag))
            {
                objectfound = true;
            }
        }
        return objectfound;
    }

    GameObject GetObjectsWithTag(string tag)
    {
        foreach (GameObject sObject in selectedObjects)
        {
            if (sObject.tag == (tag))
            {
                return sObject;
            }
        }
        return null;
    }

    void Select(GameObject mObject)
    {
        if (mObject.GetComponent<Selected>() != null)
        {
            mObject.GetComponent<Selected>().selected = true;
        }
        else
        {
            Debug.Log("object has no selected script");
        }
    }

    bool CheckIfBoatIsNodeParent(GameObject boat, GameObject node)
    {
        if (node.GetComponent<DeleteNode>().objectCreatedFor == boat.transform)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void DeselectAll()
    {
        DeselectSpecific("Boat");
        DeselectSpecific("Node");
        DeselectSpecific("wareHouse");
        DeselectSpecific("harbor");
        DeselectSpecific("Refinery");
        selectedObjects.Clear();
    }

    void DeselectSpecific(string tag)
    {
        GameObject[] mGameObjects;
        mGameObjects = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject mObject in mGameObjects)
        {
            if (mObject.GetComponent<Selected>() != null)
            {
                mObject.GetComponent<Selected>().selected = false;
            }
        }
    }
}

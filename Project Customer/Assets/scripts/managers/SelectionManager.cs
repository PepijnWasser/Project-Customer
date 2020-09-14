using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    public List<GameObject> selectedObjects = new List<GameObject>();
    Image canvasImage;

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
        if (GameObject.FindGameObjectWithTag("Camera Pivot").GetComponent<ChangeCamera>().camMode == ChangeCamera.CamMode.tilted)
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
                        Debug.Log(objectHit.tag);
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
                                Debug.Log("there is a boat selected");
                                if (CheckIfBoatIsNodeParent(GetObjectsWithTag("Boat"), objectHit))
                                {
                                    Debug.Log("the boat corresponds to the node");
                                    if (CheckIfTagSelected("Node"))
                                    {
                                        Debug.Log("there is another node selected");
                                        DeselectSpecific("Node");
                                        Select(objectHit);
                                        selectedObjects.Add(objectHit);
                                    }
                                    else
                                    {
                                        Debug.Log("there is no other node selected");
                                        Select(objectHit);
                                        selectedObjects.Add(objectHit);
                                    }
                                }
                                else
                                {
                                    Debug.Log("the boat is not corresponding with the node");
                                    DeselectAll();
                                    Select(objectHit);
                                    selectedObjects.Add(objectHit);
                                }
                            }
                            else
                            {
                                Debug.Log("there is no boat selected");
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
                        Debug.Log("No hit");
                    }
                }
            }
        }
    }

    bool TestForMenus()
    {
        if (TestBuyMenu() || TestSellMenuWareHouse() || TestTradeMenuRefinery())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool TestBuyMenu()
    {
        if (CheckIfTagSelected("harbor") && Input.mousePosition.x < canvasImage.rectTransform.rect.width && Input.mousePosition.y > Screen.height - canvasImage.rectTransform.rect.height)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    bool TestSellMenuWareHouse()
    {
        if (CheckIfTagSelected("wareHouse") && Input.mousePosition.x < canvasImage.rectTransform.rect.width && Input.mousePosition.y > Screen.height - canvasImage.rectTransform.rect.height)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    bool TestTradeMenuRefinery()
    {
        if (CheckIfTagSelected("Refinery") && Input.mousePosition.x < canvasImage.rectTransform.rect.width && Input.mousePosition.y > Screen.height - canvasImage.rectTransform.rect.height)
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

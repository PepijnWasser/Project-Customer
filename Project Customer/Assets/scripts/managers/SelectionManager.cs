using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    public List<GameObject> selectedObjects = new List<GameObject>();
    Image canvacanvasImage;

    void Start()
    {
        GameObject tempObject = GameObject.Find("sellMenuImage");
        if (tempObject != null)
        {
            canvacanvasImage = tempObject.GetComponent<Image>();
            if (canvacanvasImage == null)
            {
                Debug.Log("Could not locate Image component on " + tempObject.name);
            }
        }
    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            // do nothing while on sell menu
            if(TestForMenus() == false)
            {
                RaycastHit hitInfo = new RaycastHit();
                bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
                if (hit)
                {
                    GameObject objectHit = hitInfo.transform.gameObject;
                    Debug.Log(objectHit.tag);
                    ///
                    //boats
                    ///
                    if (objectHit.tag == "Boat")
                    {
                        Debug.Log("boat hit");
                        DeselectAll();
                        Select(objectHit);
                        selectedObjects.Add(objectHit);
                    }
                    ///
                    //harbor
                    /// 
                    else if (objectHit.tag == "harbor")
                    {
                        DeselectAll();
                        Select(objectHit);
                        selectedObjects.Add(objectHit);
                    }

                    ///
                    //wareHouse
                    /// 
                    else if (objectHit.tag == "wareHouse")
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

    bool TestForMenus()
    {
        if (TestBuyMenu() || TestSellMenu())
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
        if (CheckIfTagSelected("harbor") && Input.mousePosition.x < canvacanvasImage.rectTransform.rect.width && Input.mousePosition.y > Screen.height - canvacanvasImage.rectTransform.rect.height)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    bool TestSellMenu()
    {
        if (CheckIfTagSelected("wareHouse") && Input.mousePosition.x < canvacanvasImage.rectTransform.rect.width && Input.mousePosition.y > Screen.height - canvacanvasImage.rectTransform.rect.height)
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

using UnityEngine;
using UnityEngine.UI;

public class PlasticCount : MonoBehaviour
{

    Text plasticDisplay;
    Text woodDisplay;
    Text moneyDisplay;
<<<<<<< HEAD
=======
    Text oilDisplay;
>>>>>>> parent of 607d604... Revert "proj luc"

    int woodCount;
    int plasticCount;
    float moneyCount;
<<<<<<< HEAD
=======
    int oilCount;
>>>>>>> parent of 607d604... Revert "proj luc"


    private void Start()
    {
        GetTextElements();
    }

    void Update()
    {
        LinkCountsWithValue();
        UpdateHUD();        
    }

    void LinkCountsWithValue()
    {
        woodCount = GameObject.FindGameObjectWithTag("wareHouse").GetComponent<wareHouse>().woodStored;
        plasticCount = GameObject.FindGameObjectWithTag("wareHouse").GetComponent<wareHouse>().plasticStored;
        moneyCount = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<PlayerInfo>().money;
<<<<<<< HEAD
=======
        oilCount = GameObject.FindGameObjectWithTag("Refinery").GetComponent<Refinery>().oilStored;
>>>>>>> parent of 607d604... Revert "proj luc"
    }

    void GetTextElements()
    {
        GameObject tempObject = GameObject.Find("Plastic count");
        if (tempObject != null)
        {
            plasticDisplay = tempObject.GetComponent<Text>();
            if (plasticDisplay == null)
            {
                Debug.Log("Could not locate Canvas component on " + tempObject.name);

            }
        }
        GameObject tempObject2 = GameObject.Find("Money count");
        if (tempObject2 != null)
        {
            moneyDisplay = tempObject2.GetComponent<Text>();
            if (moneyDisplay == null)
            {
                Debug.Log("Could not locate Canvas component on " + tempObject2.name);

            }
        }
        GameObject tempObject3 = GameObject.Find("Wood count");
        if (tempObject3 != null)
        {
            woodDisplay = tempObject3.GetComponent<Text>();
            if (woodDisplay == null)
            {
                Debug.Log("Could not locate Canvas component on " + tempObject3.name);

            }
        }
<<<<<<< HEAD
=======
        GameObject tempObject4 = GameObject.Find("Oil count");
        if (tempObject4 != null)
        {
            oilDisplay = tempObject4.GetComponent<Text>();
            if (oilDisplay == null)
            {
                Debug.Log("Could not locate Canvas component on " + tempObject4.name);

            }
        }
>>>>>>> parent of 607d604... Revert "proj luc"
    }

    void UpdateHUD()
    {
        if (plasticDisplay != null)
        {
            plasticDisplay.text = plasticCount.ToString();
        }
        if (woodDisplay != null)
        {
<<<<<<< HEAD
            woodDisplay.text = ((int)woodCount).ToString();
=======
            woodDisplay.text = woodCount.ToString();
>>>>>>> parent of 607d604... Revert "proj luc"
        }
        if (moneyDisplay != null)
        {
            moneyDisplay.text = ((int)moneyCount).ToString();
        }
<<<<<<< HEAD
=======
        if (oilDisplay != null)
        {
            oilDisplay.text = oilCount.ToString();
        }
>>>>>>> parent of 607d604... Revert "proj luc"
    }
}


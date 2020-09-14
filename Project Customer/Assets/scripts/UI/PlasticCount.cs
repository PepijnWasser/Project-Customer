using UnityEngine;
using UnityEngine.UI;

public class PlasticCount : MonoBehaviour
{

    Text plasticDisplay;
    Text woodDisplay;
    Text moneyDisplay;
    Text oilDisplay;

    int woodCount;
    int plasticCount;
    float moneyCount;
    int oilCount;


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
        oilCount = GameObject.FindGameObjectWithTag("Refinery").GetComponent<Refinery>().oilStored;
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
        GameObject tempObject4 = GameObject.Find("Oil count");
        if (tempObject4 != null)
        {
            oilDisplay = tempObject4.GetComponent<Text>();
            if (oilDisplay == null)
            {
                Debug.Log("Could not locate Canvas component on " + tempObject4.name);

            }
        }
    }

    void UpdateHUD()
    {
        if (plasticDisplay != null)
        {
            plasticDisplay.text = plasticCount.ToString();
        }
        if (woodDisplay != null)
        {
            woodDisplay.text = woodCount.ToString();
        }
        if (moneyDisplay != null)
        {
            moneyDisplay.text = ((int)moneyCount).ToString();
        }
        if (oilDisplay != null)
        {
            oilDisplay.text = oilCount.ToString();
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellResourcesRefinery : MonoBehaviour
{
    Canvas sellMenu;
    SellPriceRefinery sellPriceRefinery;
    WorldData worldData;
    PlayerInfo playerInfo;
    Refinery refinery;

    public int convertionRatio;

    void Start()
    {
        if(GameObject.FindGameObjectWithTag("LevelManager").GetComponent<WorldData>() != null)
        {
            worldData = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<WorldData>();
        }
        else
        {
            Debug.Log("could not locate worldData in sellresourcerefinery");
        }
        if(GameObject.FindGameObjectWithTag("LevelManager").GetComponent<PlayerInfo>() != null)
        {
            playerInfo = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<PlayerInfo>();
        }
        else
        {
            Debug.Log("could not locate playerInfo in sellresourcerefinery");
        }
        if(GetComponent<SellPriceRefinery>() != null)
        {
            sellPriceRefinery = GetComponent<SellPriceRefinery>();
        }
        else
        {
            Debug.Log("could not locate sellpricerefinery in sellresourcerefinery");
        }
        if(GetComponent<Refinery>() != null)
        {
            refinery = GetComponent<Refinery>();
        }
        else
        {
            Debug.Log("could not locate refinery in sellresourcerefinery");
        }

        GameObject tempObject = GameObject.Find("tradeMenuRefinery");
        if (tempObject != null)
        {
            sellMenu = tempObject.GetComponent<Canvas>();
            if (sellMenu == null)
            {
                Debug.Log("Could not locate Canvas component on " + tempObject.name);
            }
        }
    }
    void Update()
    {
        if (GetComponent<Selected>().selected)
        {
            sellMenu.enabled = true;
        }
        else
        {
            sellMenu.enabled = false;
        }
    }

    public void SellOil()
    {
        if(refinery != null && worldData != null)
        {
            if (refinery.oilStored >= worldData.oilVolume)
            {
                playerInfo.AddMoney(sellPriceRefinery.sellPriceOil);
                refinery.RemoveOil();
            }
        }
        else
        {
            Debug.Log("failed to selloil in sellresourcerefinery");
        }
    }

    public void TradeOilToFuel()
    {
        if (refinery != null && worldData != null && playerInfo != null)
        {
            if (refinery.oilStored >= worldData.oilVolume && playerInfo.fuel + worldData.oilVolume < worldData.maxFuel)
            {
                refinery.RemoveOil();
                playerInfo.AddFuel(worldData.oilVolume * convertionRatio);
            }
        }
        else
        {
            Debug.Log("failed to tradeoiltofuel in sellresourcerefinery");
        }
    }
}

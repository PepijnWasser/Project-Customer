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
        worldData = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<WorldData>();
        playerInfo = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<PlayerInfo>();
        sellPriceRefinery = GetComponent<SellPriceRefinery>();
        refinery = GetComponent<Refinery>();

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
        if (refinery.oilStored >= worldData.oilVolume)
        {
            playerInfo.AddMoney(sellPriceRefinery.sellPriceOil);
            refinery.RemoveOil();
        }
    }

    public void TradeOilToFuel()
    {
        if (refinery.oilStored >= worldData.oilVolume && playerInfo.fuel + worldData.oilVolume < worldData.maxFuel)
        {
            refinery.RemoveOil();
            playerInfo.AddFuel(worldData.oilVolume * convertionRatio);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellResources : MonoBehaviour
{
    Canvas sellMenu;
    SellPrices sellPrices;
    WorldData worldData;
    PlayerInfo playerInfo;
    WareHouse wareHouse;

    void Start()
    {
        worldData = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<WorldData>();
        playerInfo = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<PlayerInfo>();
        sellPrices = GetComponent<SellPrices>();
        wareHouse = GetComponent<WareHouse>();

        GameObject tempObject = GameObject.Find("sellMenu");
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

    public void SellWood()
    {
        if (wareHouse.woodStored >= worldData.woodVolume)
        {
            playerInfo.AddMoney(sellPrices.sellPriceWood);
            wareHouse.RemoveWood();
        }
    }

    public void SellPlastic()
    {
        if (wareHouse.plasticStored >= worldData.plasticVolume)
        {
            playerInfo.AddMoney(sellPrices.sellPricePlastic);
            wareHouse.RemovePlastic();
        }
    }

    public void SellOil()
    {
        if (wareHouse.oilStored >= worldData.oilVolume)
        {
            playerInfo.AddMoney(sellPrices.sellPriceOil);
            wareHouse.RemoveOil();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine.UI;
using UnityEngine;

public class sellResources : MonoBehaviour
{
    public Canvas sellMenu;
    SellPrices sellPrices;
    worldData worldData;
    playerInfo playerInfo;
    wareHouse wareHouse;

    void Start()
    {
        worldData = GameObject.FindGameObjectWithTag("worldData").GetComponent<worldData>();
        playerInfo = GameObject.FindGameObjectWithTag("playerInfo").GetComponent<playerInfo>();
        sellPrices = GetComponent<SellPrices>();
        wareHouse = GetComponent<wareHouse>();

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
        if (wareHouse.woodStored >= worldData.woodVolume)
        {
            playerInfo.AddMoney(sellPrices.sellPricePlastic);
            wareHouse.RemoveWood();
        }
    }

    public void SellOil()
    {
        if (wareHouse.woodStored >= worldData.woodVolume)
        {
            playerInfo.AddMoney(sellPrices.sellPriceOil);
            wareHouse.RemoveWood();
        }
    }
}

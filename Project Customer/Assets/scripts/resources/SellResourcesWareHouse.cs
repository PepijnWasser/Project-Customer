using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellResourcesWareHouse : MonoBehaviour
{
    Canvas sellMenu;
    SellPriceWareHouse sellPriceWareHouse;
    WorldData worldData;
    PlayerInfo playerInfo;
    wareHouse wareHouse;

    void Start()
    {
        worldData = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<WorldData>();
        playerInfo = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<PlayerInfo>();
        sellPriceWareHouse = GetComponent<SellPriceWareHouse>();
        wareHouse = GetComponent<wareHouse>();

        GameObject tempObject = GameObject.Find("sellMenuWareHouse");
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
            playerInfo.AddMoney(sellPriceWareHouse.sellPriceWood);
            wareHouse.RemoveWood();
        }
    }

    public void SellPlastic()
    {
        if (wareHouse.plasticStored >= worldData.plasticVolume)
        {
            playerInfo.AddMoney(sellPriceWareHouse.sellPricePlastic);
            wareHouse.RemovePlastic();
        }
    }
}

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
        if (GameObject.FindGameObjectWithTag("LevelManager").GetComponent<WorldData>() != null)
        {
            worldData = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<WorldData>();
        }
        else
        {
            Debug.Log("could not locate worldData in sellresourcerewarehouse");
        }
        if (GameObject.FindGameObjectWithTag("LevelManager").GetComponent<PlayerInfo>() != null)
        {
            playerInfo = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<PlayerInfo>();
        }
        else
        {
            Debug.Log("could not locate playerInfo in sellresourcerewarehouse");
        }
        if (GetComponent<SellPriceWareHouse>() != null)
        {
            sellPriceWareHouse = GetComponent<SellPriceWareHouse>();
        }
        else
        {
            Debug.Log("could not locate sellpricewarehouse in sellresourcewarehouse");
        }
        if (GetComponent<wareHouse>() != null)
        {
            wareHouse = GetComponent<wareHouse>();
        }
        else
        {
            Debug.Log("could not locate warehouse in sellresourcewarehouse");
        }

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
        if (wareHouse != null && worldData != null)
        {
            if (wareHouse.woodStored >= worldData.woodVolume)
            {
                playerInfo.AddMoney(sellPriceWareHouse.sellPriceWood);
                wareHouse.RemoveWood();
            }
        }
    }

    public void SellPlastic()
    {
        if (wareHouse != null && worldData != null)
        {
            if (wareHouse.plasticStored >= worldData.plasticVolume)
            {
                playerInfo.AddMoney(sellPriceWareHouse.sellPricePlastic);
                wareHouse.RemovePlastic();
            }
        }
    }
}

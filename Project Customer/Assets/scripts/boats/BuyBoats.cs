using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyBoats : MonoBehaviour
{
    public int smallBoatPrice;
    public int mediumBoatPrice;
    public int largeBoatPrice;
    public int hugeBoatPrice;

    public GameObject smallBoat;
    public GameObject mediumBoat;
    public GameObject largeBoat;
    public GameObject hugeBoat;

    Canvas buyMenu;
    PlayerInfo playerInfo;

    void Start()
    {
        playerInfo = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<PlayerInfo>();
        GameObject tempObject = GameObject.Find("buyMenu");
        if (tempObject != null)
        {
            buyMenu = tempObject.GetComponent<Canvas>();
            if (buyMenu == null)
            {
                Debug.Log("Could not locate Canvas component on " + tempObject.name);
            }
        }
    }
    void Update()
    {

        if (GetComponent<Selected>().selected)
        {
            buyMenu.enabled = true;
        }
        else
        {
            buyMenu.enabled = false;
        }
    }

    public void BuySmallBoat()
    {
        if(playerInfo.money >= smallBoatPrice)
        {
            playerInfo.RemoveMoney(smallBoatPrice);
            GameObject newBoat = Instantiate(smallBoat, transform.position + new Vector3(5, 0, 0), Quaternion.identity); 
        }
    }

    public void BuyMediumBoat()
    {
        if (playerInfo.money >= mediumBoatPrice)
        {
            playerInfo.RemoveMoney(mediumBoatPrice);
            GameObject newBoat = Instantiate(mediumBoat, transform.position + new Vector3(5, 0, 0), Quaternion.identity);
        }
    }

    public void BuyLargeBoat()
    {
        if (playerInfo.money >= largeBoatPrice)
        {
            playerInfo.RemoveMoney(largeBoatPrice);
            GameObject newBoat = Instantiate(largeBoat, transform.position + new Vector3(5, 0, 0), Quaternion.identity);
        }
    }

    public void BuyHugeBoat()
    {
        if (playerInfo.money >= hugeBoatPrice)
        {
            playerInfo.RemoveMoney(hugeBoatPrice);
            GameObject newBoat = Instantiate(hugeBoat, transform.position + new Vector3(5, 0, 0), Quaternion.identity);
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Fuel : MonoBehaviour
{
    public int amountOfFuelUsed;
    PlayerInfo playerInfo;

    float secondCounter;

    void Start()
    {
        if (GameObject.FindGameObjectWithTag("LevelManager").GetComponent<PlayerInfo>() != null)
        {
            playerInfo = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<PlayerInfo>();
        }
        else
        {
            Debug.Log("could not locate playerinfo component in fuel");
        }
    }

    void Update()
    {
        if(playerInfo != null)
        {
            secondCounter += Time.deltaTime;
            if (secondCounter > 5)
            {
                secondCounter = 0;
                playerInfo.RemoveFuel(amountOfFuelUsed);
            }
        }
        else
        {
            Debug.Log("playerinfo could not be found in fuel");
        }
       
    }
}

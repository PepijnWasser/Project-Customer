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
        playerInfo = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<PlayerInfo>();
    }

    void Update()
    {
        secondCounter += Time.deltaTime;
        if (secondCounter > 5)
        {
            secondCounter = 0;
            playerInfo.RemoveFuel(amountOfFuelUsed);
        }
    }
}

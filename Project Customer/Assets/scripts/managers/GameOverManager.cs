using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public int maxGarbage;
    PlayerInfo playerInfo;

    private void Start()
    {
        playerInfo = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<PlayerInfo>();    
    }

    private void Update()
    {
        TestForTooMuchGarbage();
        TestForTooFewFuel();
    }

    void TestForTooMuchGarbage()
    {
        int amountOfOil = GameObject.FindGameObjectsWithTag("oil").Count();
        int amountOfPlastic = GameObject.FindGameObjectsWithTag("plastic").Count();
        int amountOfWood = GameObject.FindGameObjectsWithTag("wood").Count();

        int amountOfGarbage = amountOfOil + amountOfPlastic + amountOfWood;

        if (amountOfGarbage > maxGarbage)
        {
            //switch screens
        }
    }

    void TestForTooFewFuel()
    {
        int amountOfFuel = playerInfo.fuel;

        if(amountOfFuel <= 0)
        {
            //switch screen
        }
    }
}

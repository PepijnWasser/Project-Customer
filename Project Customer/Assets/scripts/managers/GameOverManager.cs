using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public int maxGarbage;

    private void Update()
    {
        int amountOfOil = GameObject.FindGameObjectsWithTag("oil").Count();
        int amountOfPlastic = GameObject.FindGameObjectsWithTag("plastic").Count();
        int amountOfWood = GameObject.FindGameObjectsWithTag("wood").Count();

        int amountOfGarbage = amountOfOil + amountOfPlastic + amountOfWood;

        if(amountOfGarbage > maxGarbage)
        {
            //switch screens
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class NumberOfGarbagePieces : MonoBehaviour
{
    Text garbageDisplay;

    private void Start()
    {
        garbageDisplay = GetComponent<Text>();
    }


    private void Update()
    {
        string message = "don't let the amount of garbage get over 200! \n\n amount of garbage: ";
        garbageDisplay.text = message + GetNumberOfGarbagePieces().ToString();
    }

    int GetNumberOfGarbagePieces()
    {
        int amountOfOil = GameObject.FindGameObjectsWithTag("oil").Count();
        int amountOfPlastic = GameObject.FindGameObjectsWithTag("plastic").Count();
        int amountOfWood = GameObject.FindGameObjectsWithTag("wood").Count();

        int amountOfGarbage = amountOfOil + amountOfPlastic + amountOfWood;

        return amountOfGarbage;
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
<<<<<<< HEAD
using UnityEngine.SceneManagement;
=======
>>>>>>> parent of 607d604... Revert "proj luc"

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
<<<<<<< HEAD
            SceneManager.LoadScene("end menu");
=======
            //switch screens
>>>>>>> parent of 607d604... Revert "proj luc"
        }
    }

    void TestForTooFewFuel()
    {
        int amountOfFuel = playerInfo.fuel;

        if(amountOfFuel <= 0)
        {
<<<<<<< HEAD
            SceneManager.LoadScene("RestartScreen");
=======
            //switch screen
>>>>>>> parent of 607d604... Revert "proj luc"
        }
    }
}

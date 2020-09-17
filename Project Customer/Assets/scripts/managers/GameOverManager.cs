using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public int maxGarbage;
    public int minGarbage;
    PlayerInfo playerInfo;

    private void Start()
    {
        if(GameObject.FindGameObjectWithTag("LevelManager").GetComponent<PlayerInfo>() != null)
        {
            playerInfo = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<PlayerInfo>();
        } 
    }

    private void Update()
    {
        TestForTooMuchGarbage();
        TestForTooFewFuel();
        TestForTooFewGarbage();
    }

    void TestForTooMuchGarbage()
    {
        int amountOfOil = GameObject.FindGameObjectsWithTag("oil").Count();
        int amountOfPlastic = GameObject.FindGameObjectsWithTag("plastic").Count();
        int amountOfWood = GameObject.FindGameObjectsWithTag("wood").Count();

        int amountOfGarbage = amountOfOil + amountOfPlastic + amountOfWood;

        if (amountOfGarbage > maxGarbage)
        {
            SceneManager.LoadScene("RestartScreen");
        }
    }

    void TestForTooFewFuel()
    {
        int amountOfFuel = playerInfo.fuel;

        if(amountOfFuel <= 0)
        {
            SceneManager.LoadScene("RestartScreen");
        }
    }

    void TestForTooFewGarbage()
    {
        int amountOfOil = GameObject.FindGameObjectsWithTag("oil").Count();
        int amountOfPlastic = GameObject.FindGameObjectsWithTag("plastic").Count();
        int amountOfWood = GameObject.FindGameObjectsWithTag("wood").Count();

        int amountOfGarbage = amountOfOil + amountOfPlastic + amountOfWood;

        if (amountOfGarbage < minGarbage)
        {
            SceneManager.LoadScene("win menu");
        }
    }
}

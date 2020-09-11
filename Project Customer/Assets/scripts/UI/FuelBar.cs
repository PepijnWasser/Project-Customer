using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{
    int maximumOilStored;
    int fuel;

    public Image mask;

    void Start()
    {
        fuel = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<PlayerInfo>().fuel;
        maximumOilStored = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<WorldData>().maxFuel;
    }

    void Update()
    {
        GetCurrentFill();
    }
    void GetCurrentFill()
    {
        mask.fillAmount = fuel / maximumOilStored;
    }
}

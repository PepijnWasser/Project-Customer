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
        maximumOilStored = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<WorldData>().maxFuel;
    }

    void Update()
    {
        GetCurrentFill();
    }
    void GetCurrentFill()
    {
        fuel = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<PlayerInfo>().fuel;
        mask.fillAmount = (float)fuel / (float)maximumOilStored;
    }
}

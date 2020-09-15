using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{
    int maximumOilStored;
    int fuel;

    public Image mask;
    PlayerInfo playerInfo;

    void Start()
    {
        maximumOilStored = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<WorldData>().maxFuel;
        playerInfo = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<PlayerInfo>();
    }

    void Update()
    {
        GetCurrentFill();
    }
    void GetCurrentFill()
    {
        fuel = playerInfo.fuel;
        mask.fillAmount = (float)fuel / (float)maximumOilStored;
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int inventorySpace;

    private int plasticVolume;
    private int oilVolume;
    private int woodVolume;

    public int maxPlastic;
    public int maxOil;
    public int maxWood;

    [HideInInspector]
    public int plasticStored;
    [HideInInspector]
    public int oilStored;
    [HideInInspector]
    public int woodStored;

    void Start()
    {
        plasticVolume = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<WorldData>().plasticVolume;
        woodVolume = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<WorldData>().woodVolume;
        oilVolume = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<WorldData>().oilVolume;
    }

    public void AddPlastic()
    {
        plasticStored += plasticVolume;
    }

    public void AddOil()
    {
        oilStored += oilVolume;
    }

    public void AddWood()
    {
        woodStored += woodVolume;
    }

    public void RemovePlastic()
    {
        plasticStored -= plasticVolume;
    }

    public void RemoveOil()
    {
        oilStored -= oilVolume;
    }

    public void RemoveWood()
    {
        woodStored -= woodVolume;
    }
}

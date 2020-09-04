using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wareHouse : MonoBehaviour
{
    private List<GameObject> boats = new List<GameObject>();
    public int wareHousePickupRange;

    private int plasticVolume;
    private int oilVolume;
    private int woodVolume;

    public int wareHouseInventorySpace;
    public int wareHouseMaxPlastic;
    public int wareHouseMaxWood;
    public int wareHouseMaxOil;

    public int plasticStored;
    public int oilStored;
    public int woodStored;

    void Start()
    {
        plasticVolume = GameObject.FindGameObjectWithTag("worldData").GetComponent<worldData>().plasticVolume;
        woodVolume = GameObject.FindGameObjectWithTag("worldData").GetComponent<worldData>().woodVolume;
        oilVolume = GameObject.FindGameObjectWithTag("worldData").GetComponent<worldData>().oilVolume;
    }

    void Update()
    {
        foreach(GameObject boat in GameObject.FindGameObjectsWithTag("Boat"))
        {
            boats.Add(boat);
        }
        foreach(GameObject boat in boats)
        {
            if(Vector3.Distance(transform.position, boat.transform.position) <= wareHousePickupRange)
            {
                Inventory boatInventory = boat.GetComponent<Inventory>();
                while(boatInventory.oilStored >= oilVolume)
                {
                    boatInventory.RemoveOil();
                    AddOil();
                }
                while (boatInventory.woodStored >= woodVolume)
                {
                    boatInventory.RemoveWood();
                    AddWood();
                }
                while (boatInventory.plasticStored >= plasticVolume)
                {
                    boatInventory.RemovePlastic();
                    AddPlastic();
                }
            }
        }
    }

    void AddPlastic()
    {
        plasticStored += plasticVolume;
    }

    void AddOil()
    {
        oilStored += oilVolume;
    }

    void AddWood()
    {
        woodStored += woodVolume;
    }

    public void RemovePlastic()
    {
        plasticStored += plasticVolume;
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

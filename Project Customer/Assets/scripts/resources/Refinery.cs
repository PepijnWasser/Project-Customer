using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refinery : MonoBehaviour
{
    private List<GameObject> boats = new List<GameObject>();
    public int wareHousePickupRange;

    private int oilVolume;

    public int wareHouseMaxOil;

    [HideInInspector]
    public int oilStored;


    void Start()
    {
        oilVolume = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<WorldData>().oilVolume;
    }

    void Update()
    {
        foreach (GameObject boat in GameObject.FindGameObjectsWithTag("Boat"))
        {
            if (boats.Contains(boat) == false)
            {
                boats.Add(boat);
            }
        }

        foreach (GameObject boat in boats)
        {
            if (Vector3.Distance(transform.position, boat.transform.position) <= wareHousePickupRange)
            {
                Inventory boatInventory = boat.GetComponent<Inventory>();
                if (boatInventory != null)
                {
                    while (boatInventory.oilStored >= oilVolume)
                    {
                        boatInventory.RemoveOil();
                        AddOil();
                    }
                }
            }
        }
    }

    void AddOil()
    {
        oilStored += oilVolume;
    }

    public void RemoveOil()
    {
        oilStored -= oilVolume;
    }

}

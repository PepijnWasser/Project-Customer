using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wareHouse : MonoBehaviour
{
    private List<GameObject> boats = new List<GameObject>();
    public int wareHousePickupRange;

    private int plasticVolume;
    private int woodVolume;

    public int wareHouseInventorySpace;
    public int wareHouseMaxPlastic;
    public int wareHouseMaxWood;

    //[HideInInspector]
    public int plasticStored;
    //[HideInInspector]
    public int woodStored;

    void Start()
    {
        plasticVolume = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<WorldData>().plasticVolume;
        woodVolume = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<WorldData>().woodVolume;
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
                    while (boatInventory.woodStored >= woodVolume && woodStored + plasticStored + woodVolume <= wareHouseInventorySpace && woodStored + woodVolume < wareHouseMaxWood)
                    {
                        boatInventory.RemoveWood();
                        AddWood();
                    }
                    while (boatInventory.plasticStored >= plasticVolume && woodStored + plasticStored + plasticVolume <= wareHouseInventorySpace && plasticStored + plasticVolume < wareHouseMaxPlastic)
                    {
                        boatInventory.RemovePlastic();
                        AddPlastic();
                    }
                }
            }
        }
    }

    void AddPlastic()
    {
        plasticStored += plasticVolume;
    }

    void AddWood()
    {
        woodStored += woodVolume;
    }

    public void RemovePlastic()
    {
        plasticStored -= plasticVolume;
    }

    public void RemoveWood()
    {
        woodStored -= woodVolume;
    }
}

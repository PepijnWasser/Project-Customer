using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class garbagePickup : MonoBehaviour
{
    private List<GameObject> garbage = new List<GameObject>();
    private List<GameObject> piecesToRemove = new List<GameObject>();

    public float pickupRange;

    void Update()
    {
        UpdateGarbage();
        TestPickup();
    }

    void UpdateGarbage()
    {
        foreach (GameObject woodPiece in GameObject.FindGameObjectsWithTag("wood"))
        {
            garbage.Add(woodPiece);
        }
        foreach (GameObject plasticPiece in GameObject.FindGameObjectsWithTag("plastic"))
        {
            garbage.Add(plasticPiece);
        }
        foreach (GameObject Oildrop in GameObject.FindGameObjectsWithTag("oil"))
        {
            garbage.Add(Oildrop);
        }
    }

    void TestPickup()
    {
        foreach (GameObject piece in garbage)
        {
            if (Vector3.Distance(transform.position, piece.transform.position) < pickupRange)
            {
                int plasticStored = 0;
                int maxPlastic = 0;
                int woodStored = 0;
                int maxWood = 0;
                int oilStored = 0;
                int maxOil = 0;
                int inventorySpace = 0;
                if (GetComponent<Inventory>() != null)
                {
                    plasticStored = GetComponent<Inventory>().plasticStored;
                    maxPlastic = GetComponent<Inventory>().maxPlastic;
                    woodStored = GetComponent<Inventory>().woodStored;
                    maxWood = GetComponent<Inventory>().maxWood;
                    oilStored = GetComponent<Inventory>().oilStored;
                    maxOil = GetComponent<Inventory>().maxOil;
                    inventorySpace = GetComponent<Inventory>().inventorySpace;
                }
                else
                {
                    Debug.Log("could not locate inventory component in garbagepickup");
                }

                int plasticVolume = 0;
                int woodVolume = 0;
                int oilVolume = 0;
                if (GameObject.FindGameObjectWithTag("LevelManager").GetComponent<WorldData>() != null)
                {
                    plasticVolume = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<WorldData>().plasticVolume;
                    woodVolume = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<WorldData>().woodVolume;
                    oilVolume = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<WorldData>().oilVolume;
                }
                else
                {
                    Debug.Log("could not locate worldData component in garbagepickup");
                }
               
                if (piece.tag == "wood")
                {
                    if (woodStored + woodVolume <= maxWood && woodStored + oilStored + plasticStored + woodVolume < inventorySpace)
                    {
                        GetComponent<Inventory>().AddWood();
                        piecesToRemove.Add(piece);
                    }
                }
                if (piece.tag == "plastic")
                {
                    if (plasticStored + plasticVolume <= maxPlastic && woodStored + oilStored + plasticStored + plasticVolume < inventorySpace)
                    {
                        GetComponent<Inventory>().AddPlastic();
                        piecesToRemove.Add(piece);
                    }
                }
                if (piece.tag == "oil")
                {
                    if (oilStored + oilVolume <= maxOil && woodStored + oilStored + plasticStored + oilVolume < inventorySpace)
                    {
                        GetComponent<Inventory>().AddOil();
                        piecesToRemove.Add(piece);
                    }
                }
            }
        }
    }

    private void LateUpdate()
    {
        foreach (GameObject piece in piecesToRemove)
        {
            Destroy(piece);
        }
        garbage.Clear();
        piecesToRemove.Clear();
    }
}

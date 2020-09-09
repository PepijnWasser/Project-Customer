using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbagePickup : MonoBehaviour
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
                int plasticStored = GetComponent<Inventory>().plasticStored;
                int plasticVolume = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<WorldData>().plasticVolume;
                int maxPlastic = GetComponent<Inventory>().maxPlastic;
                int woodStored = GetComponent<Inventory>().woodStored;
                int woodVolume = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<WorldData>().woodVolume;
                int maxWood = GetComponent<Inventory>().maxWood;
                int oilStored = GetComponent<Inventory>().oilStored;
                int oilVolume = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<WorldData>().oilVolume;
                int maxOil = GetComponent<Inventory>().maxOil;
                int inventorySpace = GetComponent<Inventory>().inventorySpace;

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

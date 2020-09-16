using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageManager : MonoBehaviour
{
    public GameObject oil;
    public GameObject plastic;
    public GameObject wood;

    public int oilSpawnTime;
    public int plasticSpawnTime;
    public int woodSpawnTime;

    float oilSecondCounter;
    float plasticSecondCounter;
    float woodSecondCounter;

    int randomDelayOil;
    int randomDelayPlastic;
    int randomDelayWood;

    int worldSize;

    private void Start()
    {
        worldSize = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<WorldData>().mapSize;
    }

    void Update()
    {
        oilSecondCounter += Time.deltaTime;
        if (oilSecondCounter > oilSpawnTime + randomDelayOil)
        {
            oilSecondCounter = 0;
            randomDelayOil = Random.Range(-5, 5);
            SpawnOil();
        }

        plasticSecondCounter += Time.deltaTime;
        if (plasticSecondCounter > plasticSpawnTime + randomDelayPlastic)
        {
            plasticSecondCounter = 0;
            randomDelayPlastic = Random.Range(-5, 5);
            SpawnPlastic();
        }

        woodSecondCounter += Time.deltaTime;
        if (woodSecondCounter > woodSpawnTime + randomDelayWood)
        {
            woodSecondCounter = 0;
            randomDelayWood = Random.Range(-5, 5);
            SpawnWood();
        }
    }

    void SpawnOil()
    {
        Instantiate(oil, GetLocation(), Quaternion.identity);
    }

    void SpawnPlastic()
    {
        Instantiate(plastic, GetLocation(), Quaternion.identity);
    }

    void SpawnWood()
    {
        Instantiate(wood, GetLocation(), Quaternion.identity);
    }

    Vector3 GetLocation()
    {
        Vector3 spawnposition;

        int ranX = Random.Range(-worldSize / 2, worldSize / 2);
        int ranZ = Random.Range(-worldSize / 2, worldSize / 2);

        RaycastHit RayInfo = new RaycastHit();
        
        if(Physics.Raycast(new Vector3(ranX, 500, ranZ), Vector3.down, out RayInfo, 1000))
        {
            if(RayInfo.transform.gameObject.tag == "Water")
            {
                return (new Vector3(ranX, RayInfo.transform.gameObject.transform.position.y, ranZ));
            }
            else
            {
                Vector3 newVec = GetLocation();
                return newVec;
            }
        }
        else
        {
            return new Vector3(0, 0, 0);
        }
    }

    public void DecreaseWoodSpawnTime()
    {
        woodSpawnTime += 1;
    }

    public void DecreaseOilSpawnTime()
    {
        oilSpawnTime += 1;
    }

    public void DecreasePlasticSpawnTime()
    {
        plasticSpawnTime += 1;
    }
}

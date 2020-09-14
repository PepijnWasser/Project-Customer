using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldData : MonoBehaviour
{
    [Min(1)]
    public int woodVolume = 1;
    [Min(1)]
    public int plasticVolume = 1;
    [Min(1)]
    public int oilVolume = 1;
    [Min(10)]
    public int mapSize = 10;
    [Min(10)]
    public int maxFuel = 100;
}
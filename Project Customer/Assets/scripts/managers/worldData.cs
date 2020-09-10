using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldData : MonoBehaviour
{
    [Min(1)]
    public int woodVolume;
    [Min(1)]
    public int plasticVolume;
    [Min(1)]
    public int oilVolume;
    [Min(10)]
    public int mapSize;
}

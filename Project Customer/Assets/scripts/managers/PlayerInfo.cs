using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public float money = 0;
    public int fuel;

    public void AddMoney(float amount)
    {
        money += amount;
    }

    public void RemoveMoney(float amount)
    {
        money -= amount;
    }

    public void AddFuel(int amount)
    {
        fuel += amount;
    }

    public void RemoveFuel(int amount)
    {
        fuel -= amount;
    }
}

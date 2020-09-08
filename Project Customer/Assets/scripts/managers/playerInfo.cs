using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
public class playerInfo : MonoBehaviour
=======
public class PlayerInfo : MonoBehaviour
>>>>>>> master
{
    public float money = 0;

    public void AddMoney(float amount)
    {
        money += amount;
    }

    public void RemoveMoney(float amount)
    {
        money -= amount;
    }
}

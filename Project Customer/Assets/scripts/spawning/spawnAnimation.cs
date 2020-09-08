using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
public class spawnAnimation : MonoBehaviour
=======
public class SpawnAnimation : MonoBehaviour
>>>>>>> master
{
    [Min(0)]
    public float spawnDuration;

    float timer = 0;

    private void Awake()
    {
        transform.localScale = new Vector3(0, 0, 0);
    }

    private void Update()
    {
        if(timer < spawnDuration)
        {
            timer += Time.deltaTime;
            transform.localScale = new Vector3(1, 1, 1) * (timer / spawnDuration);
        }
    }
}

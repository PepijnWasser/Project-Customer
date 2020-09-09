using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnAnimation : MonoBehaviour
{
    [Min(0)]
    public float spawnDuration;

    Vector3 originalScale;

    float timer = 0;

    private void Awake()
    {
        originalScale = transform.localScale;
        transform.localScale = new Vector3(0, 0, 0);
    }

    private void Update()
    {
        if (timer < spawnDuration)
        {
            timer += Time.deltaTime;
            transform.localScale = originalScale * (timer / spawnDuration);
        }
    }
}

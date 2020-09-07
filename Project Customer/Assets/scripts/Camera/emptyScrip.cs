using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emptyScrip : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed;

    int worldSize;

    private void Start()
    {
        worldSize = GameObject.FindGameObjectWithTag("worldData").GetComponent<worldData>().MapSize;
    }

    private void Update()
    {
        Controls();
        Rotate();
    }


    void Controls()
    {
        Vector3 moveVec = new Vector3(Input.GetAxis("Vertical"), 0, -Input.GetAxis("Horizontal"));
        transform.Translate(moveVec * moveSpeed * Time.deltaTime);
        float newX = Mathf.Clamp(transform.position.x, -worldSize / 2, worldSize / 2);
        float newZ = Mathf.Clamp(transform.position.z, -worldSize / 2, worldSize / 2);
        transform.position = new Vector3(newX, transform.position.y, newZ);
     
    }

    void Rotate()
    {
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }
    }
}

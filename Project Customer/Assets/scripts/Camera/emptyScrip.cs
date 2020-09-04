using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emptyScrip : MonoBehaviour
{
    public float moveSpeed;
    public float rotationSpeed;

    private void Update()
    {
        Controls();
        Rotate();
    }


    void Controls()
    {
        Vector3 moveVec = new Vector3(Input.GetAxis("Vertical"), 0, -Input.GetAxis("Horizontal"));
        transform.Translate(moveVec * moveSpeed * Time.deltaTime);
     
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

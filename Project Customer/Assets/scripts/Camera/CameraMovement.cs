using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed;
    public float boostSpeed;
    public float rotationSpeed;

    public int worldUpperBorder = -120;
    public int worldLowerBorder = 200;
    public int worldLeftBorder = -200;
    public int worldRightBorder = 200;

    private void Update()
    {
        Controls();
        Rotate();
    }


    void Controls()
    {
        Vector3 moveVec = new Vector3(Input.GetAxis("Vertical"), 0, -Input.GetAxis("Horizontal")).normalized;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(moveVec * boostSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(moveVec * moveSpeed * Time.deltaTime);
        }
        float newX = Mathf.Clamp(transform.position.x, worldUpperBorder, worldLowerBorder);
        float newZ = Mathf.Clamp(transform.position.z, worldLeftBorder, worldRightBorder);
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

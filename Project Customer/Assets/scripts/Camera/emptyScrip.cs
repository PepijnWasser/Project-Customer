using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
public class emptyScrip : MonoBehaviour
{
    public float moveSpeed;
=======
public class EmptyScrip : MonoBehaviour
{
    public float moveSpeed;
    public float boostSpeed;
>>>>>>> master
    public float rotationSpeed;

    int worldSize;

    private void Start()
    {
<<<<<<< HEAD
        worldSize = GameObject.FindGameObjectWithTag("worldData").GetComponent<worldData>().MapSize;
=======
        worldSize = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<WorldData>().mapSize;
>>>>>>> master
    }

    private void Update()
    {
        Controls();
        Rotate();
    }


    void Controls()
    {
        Vector3 moveVec = new Vector3(Input.GetAxis("Vertical"), 0, -Input.GetAxis("Horizontal"));
<<<<<<< HEAD
        transform.Translate(moveVec * moveSpeed * Time.deltaTime);
=======
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(moveVec * boostSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(moveVec * moveSpeed * Time.deltaTime);
        }
>>>>>>> master
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

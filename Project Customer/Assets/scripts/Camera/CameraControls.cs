using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public float zoomSpeed;
    public float moveSpeed;
    public float turnSpeed;

    public int leftBoundry;
    public int rightBoundry;
    public int topBoundry;
    public int bottomBoundry;

    public float minZoom;
    public float maxZoom;

    void Update()
    {
        Movement();
        Zoom();
        Rotate();
    }

    void Rotate()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            Ray ray = new Ray(transform.position, transform.forward);

            RaycastHit hitPoint;

            Vector3 targetPoint = new Vector3(0, 0, 0);
            if (Physics.Raycast(ray, out hitPoint, 100000.0f))
            {               
                targetPoint = hitPoint.point;
            }
            if (targetPoint != null)
            {
                transform.RotateAround(targetPoint, new Vector3(0, 1, 0), turnSpeed * Time.deltaTime);
            }   
        }

        if (Input.GetKey(KeyCode.E))
        {
            Ray ray = new Ray(transform.position, transform.forward);

            RaycastHit hitPoint;

            Vector3 targetPoint = new Vector3(0, 0, 0);
            if (Physics.Raycast(ray, out hitPoint, 100000.0f))
            {
                targetPoint = hitPoint.point;
            }
            if (targetPoint != null)
            {
                transform.RotateAround(targetPoint, new Vector3(0, -1, 0), turnSpeed * Time.deltaTime);
            }
        }

    }

    void Zoom()
    {
        float oldFOV;
        float FOVChanged;
        oldFOV = GetComponent<Camera>().fieldOfView;
        if(Input.mouseScrollDelta.y > 0)
        {
            FOVChanged = oldFOV - zoomSpeed;
        }
        else if (Input.mouseScrollDelta.y < 0)
        {
            FOVChanged = oldFOV + zoomSpeed;
        }
        else
        {
            FOVChanged = oldFOV;
        }
        GetComponent<Camera>().fieldOfView = ClampFOV(FOVChanged);
    }

    void Movement()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.Translate(transform.right * moveSpeed * Time.deltaTime);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.Translate(-transform.right * moveSpeed * Time.deltaTime);
        }
        // Vector3 moveVec = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * moveSpeed * Time.deltaTime;
        // Debug.Log(moveVec);
        //transform.Translate(moveVec, Space.World);
        ClampCamera();
    }

    void ClampCamera()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomBoundry, topBoundry), transform.position.y, Mathf.Clamp(transform.position.z, leftBoundry, rightBoundry));
    }

    float ClampFOV(float FOV)
    {
        return Mathf.Clamp(FOV, maxZoom, minZoom);
    }
}

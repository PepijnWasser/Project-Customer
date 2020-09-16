using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCamera : MonoBehaviour
{
    public float zoomSpeed;
    [Min(10)]
    public float minZoom;
    [Min(10)]
    public float maxZoom;

    private void Update()
    {
        Zoom();
    }

    void Zoom()
    {
        if(GetComponent<Camera>() != null)
        {
            float oldFOV;
            float FOVChanged;
            oldFOV = GetComponent<Camera>().fieldOfView;

            if (Input.mouseScrollDelta.y > 0)
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
        else
        {
            Debug.Log("There is no camera component attached on the object ZoomCamera is on");
        }
      
    }

    float ClampFOV(float FOV)
    {
        return Mathf.Clamp(FOV, maxZoom, minZoom);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
public class zoomCamera : MonoBehaviour
=======
public class ZoomCamera : MonoBehaviour
>>>>>>> master
{
    public float zoomSpeed;
    public float minZoom;
    public float maxZoom;

    private void Update()
    {
        Zoom();
    }

    void Zoom()
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

    float ClampFOV(float FOV)
    {
        return Mathf.Clamp(FOV, maxZoom, minZoom);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCompassRotation : MonoBehaviour
{
    public Transform tiltedCameraTransform;
    public Transform topDownCameraTransform;
    Vector3 dir;

    ChangeCamera cam;

    void Update()
    {
        cam = GameObject.FindGameObjectWithTag("Camera Pivot").GetComponent<ChangeCamera>();
        if (cam != null)
        {
            if (cam.camMode == ChangeCamera.CamMode.tilted)
            {
                dir.z = tiltedCameraTransform.eulerAngles.y + 270;
                transform.localEulerAngles = dir;
            }
            else
            {
                dir.z = topDownCameraTransform.eulerAngles.y + 270;
                transform.localEulerAngles = dir;
            }
        }    
    }
}

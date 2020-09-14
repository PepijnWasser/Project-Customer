﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCompassRotation : MonoBehaviour
{
    public Transform tiltedCameraTransform;
    public Transform topDownCameraTransform;
    Vector3 dir;

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Camera Pivot").GetComponent<ChangeCamera>().camMode == ChangeCamera.CamMode.tilted)
        {
            dir.z = tiltedCameraTransform.eulerAngles.y + 90;
            transform.localEulerAngles = dir;
        }
        else
        {
            dir.z = topDownCameraTransform.eulerAngles.y + 90;
            transform.localEulerAngles = dir;
        }
    }
}

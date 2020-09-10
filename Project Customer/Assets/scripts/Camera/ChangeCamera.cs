using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public enum CamMode
    {
        tilted,
        topDown
    };

    public CamMode camMode = CamMode.tilted;
    public Camera topDown;
    public Camera tilted;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if(camMode == CamMode.tilted)
            {
                camMode = CamMode.topDown;
            }
            else
            {
                camMode = CamMode.tilted;
            }
        }

        if(camMode == CamMode.tilted)
        {
            tilted.enabled = false;
            topDown.enabled = true;
        }
        if(camMode == CamMode.topDown)
        {
            tilted.enabled = true;
            topDown.enabled = false;
        }
    }
}

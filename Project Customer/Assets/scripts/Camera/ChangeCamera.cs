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

    Camera topDown;
    Camera tilted;

    private void Start()
    {
        tilted = GameObject.Find("tilted").GetComponent<Camera>();
        topDown = GameObject.Find("top down").GetComponent<Camera>();
    }

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
            tilted.enabled = true;
            topDown.enabled = false;
        }
        if(camMode == CamMode.topDown)
        {
            tilted.enabled = false;
            topDown.enabled = true;

        }
    }
}

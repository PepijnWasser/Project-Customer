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
        if(GameObject.Find("tilted").GetComponent<Camera>()  != null)
        {
            tilted = GameObject.Find("tilted").GetComponent<Camera>();
        }
        else
        {
            Debug.Log("no tilted camera found");
        }
        if(GameObject.Find("top down").GetComponent<Camera>() != null)
        {
            topDown = GameObject.Find("top down").GetComponent<Camera>();
        }
        else
        {
            Debug.Log("no topDown camera found");
        }
    }

    void Update()
    {
        if(tilted != null && topDown != null)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                if (camMode == CamMode.tilted)
                {
                    camMode = CamMode.topDown;
                }
                else
                {
                    camMode = CamMode.tilted;
                }
            }

            if (camMode == CamMode.tilted)
            {
                tilted.enabled = true;
                topDown.enabled = false;
            }
            if (camMode == CamMode.topDown)
            {
                tilted.enabled = false;
                topDown.enabled = true;

            }
        }     
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selected : MonoBehaviour
{
    [HideInInspector]
    public bool selected = false;
    public Material selectedMaterial;
    public Material notSelectedMaterial;

    MeshRenderer meshRenderer;

    void Start()
    {
        if(GetComponent<MeshRenderer>() != null)
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }
        else
        {
            Debug.Log("meshrenderer could not be located in selected");
        }
    }

    void Update()
    {
        if (meshRenderer != null)
        {
            if (selected == true)
            {

                meshRenderer.material = selectedMaterial;
            }
            else
            {
                meshRenderer.material = notSelectedMaterial;
            }
        }
        else
        {
            Debug.Log("no meshrenderer found in selected");
        }
    }
}

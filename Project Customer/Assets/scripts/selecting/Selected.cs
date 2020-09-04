using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selected : MonoBehaviour
{
    public bool selected = false;
    public Material selectedMaterial;
    public Material notSelectedMaterial;

    MeshRenderer meshRenderer;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material = notSelectedMaterial;
    }

    void Update()
    {
        //Debug.Log(selected);
        if(selected == true)
        {
            meshRenderer.material = selectedMaterial;
        }
        else
        {
            meshRenderer.material = notSelectedMaterial;
        }
    }
}

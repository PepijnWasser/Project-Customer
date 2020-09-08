﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterphysics : MonoBehaviour
{
    
    // Scroll the main texture based on time

    public float scrollSpeed = 0.5f;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        float offset = Time.time * scrollSpeed;
        rend.material.mainTextureOffset = new Vector2(-offset, offset);
    }
}

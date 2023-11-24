using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeColor : MonoBehaviour
{
    public Color baseColor;
    public Color baseEmissionColor;
    public int type;
    
    private Renderer cubeRenderer;
    private bool isSwitched;

    private void Start()
    {
        cubeRenderer = GetComponent<Renderer>();
        isSwitched = false;

        // Set the initial colors
        cubeRenderer.material.color = baseColor;
        cubeRenderer.material.SetColor("_EmissionColor", baseEmissionColor);
    }

}

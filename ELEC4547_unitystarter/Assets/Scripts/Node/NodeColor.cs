using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeColor : MonoBehaviour
{
    private Renderer cubeRenderer;
    private bool isSwitched;
    private int Line;

    private void Start()
    {
        float xPos = transform.position.x;
        Line = PositionUtility.CalculatePositionValue(xPos);
        cubeRenderer = GetComponent<Renderer>();
        // Set the initial colors based on the type
        SetColors();
    }

    private void SetColors()
    {
        Color baseColor;
        Color baseEmissionColor;

        // Assign colors based on type
        switch (Line)
        {
            case 1: // Red
                baseColor = Color.red;
                baseEmissionColor = new Color(1f, 0.2f, 0.2f);
                break;
            case 2: // Yellow
                baseColor = Color.yellow;
                baseEmissionColor = new Color(1f, 1f, 0.2f);
                break;
            case 3: // Green
                baseColor = Color.green;
                baseEmissionColor = new Color(0.2f, 1f, 0.2f);
                break;
            case 4: // Blue
                baseColor = new Color(0f, 0.6f, 1f);
                baseEmissionColor = new Color(0f, 0.6f, 1f);
                break;
            case 5: // Purple
                baseColor = new Color(0.6f, 0.2f, 1f);
                baseEmissionColor = new Color(0.6f, 0.2f, 1f);
                break;
            default: // Default color if type is invalid
                baseColor = Color.white;
                baseEmissionColor = Color.white;
                break;
        }

        // Set the colors
        cubeRenderer.material.color = baseColor;
        cubeRenderer.material.SetColor("_EmissionColor", baseEmissionColor);
    }
}

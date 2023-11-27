using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public Color baseColor;
    public Color switchColor;
    public Color baseEmissionColor;
    public Color switchEmissionColor;
    public KeyCode switchKey;

    private Renderer cubeRenderer;
    private bool isSwitched;
    private int Line;

    private void Start()
    {
        float xPos = transform.position.x;
        Line = PositionUtility.CalculatePositionValue(xPos);

        cubeRenderer = GetComponent<Renderer>();
        isSwitched = false;

        // Set the initial colors
        cubeRenderer.material.color = baseColor;
        cubeRenderer.material.SetColor("_EmissionColor", baseEmissionColor);
    }

    private void Update()
    {
        if (Input.GetKey(switchKey))
        {
            if (!isSwitched)
            {
                cubeRenderer.material.color = switchColor;
                cubeRenderer.material.SetColor("_EmissionColor", switchEmissionColor);
                isSwitched = true;
            }
        }
        else if (Input.GetKeyUp(switchKey))
        {
            if (isSwitched)
            {
                cubeRenderer.material.color = baseColor;
                cubeRenderer.material.SetColor("_EmissionColor", baseEmissionColor);
                isSwitched = false;
            }
        }
    }

    public void HandHitButton()
    {
        GameManager.instance.HandPress(Line);
        cubeRenderer.material.color = switchColor;
        cubeRenderer.material.SetColor("_EmissionColor", switchEmissionColor);
        isSwitched = true;
    }

    public void HandReleaseButton()
    {
        GameManager.instance.HandRelease(Line);
        cubeRenderer.material.color = baseColor;
        cubeRenderer.material.SetColor("_EmissionColor", baseEmissionColor);
        isSwitched = false;
    }

}

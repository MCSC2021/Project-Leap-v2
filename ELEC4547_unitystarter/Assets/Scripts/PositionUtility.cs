using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PositionUtility
{
    public static int CalculatePositionValue(float xPos)
    {
        if (xPos < -0.1f)
            return 1;
        else if (xPos < 0f)
            return 2;
        else if (xPos < 0.1f)
            return 3;
        else if (xPos < 0.2f)
            return 4;
        else
            return 5;
    }
}

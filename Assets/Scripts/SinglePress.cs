using UnityEngine;
using System.Collections;

public class SinglePress {
    private bool press = false;
    public float converter (float axis)
    {
        if (axis < -0.5f && press == false)
        {
            press = true;
            return -1.0f;
        }
        else if(axis > 0.5f && press == false)
        {
            press = true;
            return 1.0f;
        }
        else if (axis <= 0.5f && axis >= 0.5f) { press = false; return 0;  }
        else { return 0.0f; }
    }

}

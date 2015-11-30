using UnityEngine;
using System.Collections;

public class Gamepad {
    public bool x_isAxisInUse = false;
    public bool y_isAxisInUse = false;

    public string xAxis;
    public string yAxis;

    public string xDpadAxis;
    public string yDpadAxis;

    public string xKey;
    public string yKey;

    public string aKey;
    public string bKey;

    public string LBKey;
    public string RBKey;
    public string LTrigger;
    public string RTrigger;

    public string TargetKey;
    public Gamepad()
    {

    }
    public Gamepad(int ID)
    {
        switch (ID)
        {
            case 0:
                xAxis = "P1Horizontal";
                yAxis = "P1Vertical";

                xDpadAxis = "P1HorizontalDpad";
                yDpadAxis = "P1VerticalDpad";

                xKey = "P1HorizontalKey";
                yKey = "P1VerticalKey";

                aKey = "P1aKey";
                bKey = "P1bKey";

                LBKey = "P1LBKey";
                RBKey = "P1RBKey";
                LTrigger = "P1LTrigKey";
                RTrigger = "P1RTrigKey";

                TargetKey = "P1TargetKey";
                break;
            case 1:
                xAxis = "P2Horizontal";
                yAxis = "P2Vertical";

                xDpadAxis = "P2HorizontalDpad";
                yDpadAxis = "P2VerticalDpad";

                xKey = "P2HorizontalKey";
                yKey = "P2VerticalKey";

                aKey = "P2aKey";
                bKey = "P2bKey";

                LBKey = "P2LBKey";
                RBKey = "P2RBKey";
                LTrigger = "P2LTrigKey";
                RTrigger = "P2RTrigKey";

                TargetKey = "P2TargetKey";
                break;
            case 2:
                xAxis = "P3Horizontal";
                yAxis = "P3Vertical";

                xDpadAxis = "P3HorizontalDpad";
                yDpadAxis = "P3VerticalDpad";

                xKey = "P3HorizontalKey";
                yKey = "P3VerticalKey";

                aKey = "P3aKey";
                bKey = "P3bKey";

                LBKey = "P3LBKey";
                RBKey = "P3RBKey";
                LTrigger = "P3LTrigKey";
                RTrigger = "P3RTrigKey";

                TargetKey = "P3TargetKey";
                break;
            case 3:
                xAxis = "P4Horizontal";
                yAxis = "P4Vertical";

                xDpadAxis = "P4HorizontalDpad";
                yDpadAxis = "P4VerticalDpad";

                xKey = "P4HorizontalKey";
                yKey = "P4VerticalKey";

                aKey = "P4aKey";
                bKey = "P4bKey";

                LBKey = "P4LBKey";
                RBKey = "P4RBKey";
                LTrigger = "P4LTrigKey";
                RTrigger = "P4RTrigKey";

                TargetKey = "P4TargetKey";
                break;
            default:
                throw new MissingComponentException();
        }
    }
}

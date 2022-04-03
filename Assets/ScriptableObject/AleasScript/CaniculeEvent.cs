using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaniculeEvent : AleaScript
{
    public override void OnEnd()
    {
        CameraScript.Instance.HeatVolumeTargetWeight = 0;
        ClimateScript.Instance.DrynessRate /= 2;
    }

    public override void OnTrigger()
    {
        CameraScript.Instance.HeatVolumeTargetWeight = 1;
        ClimateScript.Instance.DrynessRate *= 2;
    }
}

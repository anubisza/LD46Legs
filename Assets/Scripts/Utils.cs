using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
  
    public static float DistanceTo(this Vector3 v, Vector3 target) {
        var to = target - v;
        return to.magnitude;
    }

    public static float DistanceToSqr(this Vector3 v, Vector3 target) {
        var to = target - v;
        return to.sqrMagnitude;
    }

    public static Vector3 DirectionTo(this Vector3 v, Vector3 target) {
        var to = target - v;
        to.Normalize();
        return to;
    }
}

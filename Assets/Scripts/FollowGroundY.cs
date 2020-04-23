using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGroundY : MonoBehaviour
{
    private void Update()
    {
        // This is a simple script which assumes the ground is always at y = 0.
        // You could do a raycast here to get the actual ground position.
        var pos = transform.position;
        pos.y = 0;

        transform.position = pos;
    }
}

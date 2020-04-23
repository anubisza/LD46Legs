using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTargetSmoothDamp : MonoBehaviour
{
    [Header("Setup")]
    public Transform _target;
    [Space]
    public float _smoothTime = 0.5f;
    [Space]
    public bool _followPosition = true;
    public bool _followRotation = true;
    [Space]
    public Vector3 _offset;

    private Vector3 _velocityPosition;
    private Vector3 _velocityRotation;

    private void Update() {
        if (_target == null) return;

        if (_followPosition) {
            var pos = transform.position;

            pos = Vector3.SmoothDamp(pos, _target.position + _offset, ref _velocityPosition, _smoothTime);

            transform.position = pos;
        }
    }
}

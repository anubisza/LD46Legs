using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Foot : MonoBehaviour
{
    [Header("Setup")]
    public Transform _body;
    public Transform _target;
    [Space]
    public Vector3 _groundOffset;
    [Space]
    public float _moveIfFartherThan = 1;
    [Space]
    public float _minMoveTime = 0.1f;
    [Space]
    public float _stepTime = 0.2f;
    public float _stepHeight = 0.5f;
    private bool _isMoving;
    [Space]
    public Foot _alternameWith;

    public event System.Action<Foot> _onStep;

    // State.
    private Vector3 _lastGroundedPosition;
    private float _nextAllowedMoveTime = 0;
    private float _moveDistSqr;
    private Vector3 _vel;
    private float _maxDistanceFromBody;
    private float _maxDistanceFromBodySqr;

    private void Start() {
        transform.parent = null;

        _moveDistSqr = _moveIfFartherThan * 1.3f;
        _moveDistSqr *= _moveDistSqr;


        _maxDistanceFromBody = _body.position.DistanceTo(_target.position);
        _maxDistanceFromBodySqr = _maxDistanceFromBody * _maxDistanceFromBody;
    }

    private void Update() {
        if (_target == null) return;

        // Let DOTween handle movement.
        if (_isMoving) return;

        float distFromTargetSqr = transform.position.DistanceToSqr(_target.position);

        // Close enough to target, no need to move.
        if (distFromTargetSqr < _moveDistSqr) {
            return;
        }

        // Alternating leg is moving...
        if (_alternameWith != null && _alternameWith._isMoving) {
            // This leg is too far from body, pull it closer.
            if (distFromTargetSqr > _maxDistanceFromBodySqr) {
                transform.position = _body.position + _body.position.DirectionTo(transform.position) * _maxDistanceFromBody * 0.5f;
            }
            return;
        }


        // Need to move...

        // Can't move this soon.
        if (Time.time < _nextAllowedMoveTime) return;

        _lastGroundedPosition = _target.position + _groundOffset + (_target.forward * _moveIfFartherThan);

        _isMoving = true;
        _nextAllowedMoveTime = Time.time + _minMoveTime;

        transform.DOJump(_lastGroundedPosition, _stepHeight, 1, _stepTime)
                .OnComplete(OnFootMoveComplete);
    }

    private void OnFootMoveComplete() {
        _isMoving = false;

        // Play effects here...
    }
}

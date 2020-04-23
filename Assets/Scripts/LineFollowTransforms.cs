using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[ExecuteInEditMode]
public class LineFollowTransforms : MonoBehaviour
{
    [Header("Setup")]
    [SerializeField] private Transform[] _points = new Transform[0];

    [Header("Bind")]
    private LineRenderer _lr;

    private void OnValidate() {
        Setup();
    }

    private void OnEnable() {
        Update();
    }

    private void Update() {
        if (_lr == null) {
            Setup();
        }

        if (_points == null) return;
        if (_points.Length == 0) return;

        for (int i = 0; i < _points.Length; i++) {
            _lr.SetPosition(i, _points[i].position);
        }
    }

    private void Setup() {
        _lr = GetComponent<LineRenderer>();
        _lr.useWorldSpace = true;
        _lr.positionCount = _points.Length;
    }
}

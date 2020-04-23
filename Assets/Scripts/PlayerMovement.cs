using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float _moveUnitsPerSecond = 1;
    public float _rotateDegreesPerSecond = 10;

    private Vector3 _move;

    void Update() {
        float hz = Input.GetAxis("Horizontal") * _moveUnitsPerSecond * Time.deltaTime;
        float vt = Input.GetAxis("Vertical") * _moveUnitsPerSecond * Time.deltaTime;

        if (hz == 0 && vt == 0) return;

        _move = new Vector3(hz, 0, vt);

        transform.position += _move;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(_move), _rotateDegreesPerSecond * Time.deltaTime);
    }
}

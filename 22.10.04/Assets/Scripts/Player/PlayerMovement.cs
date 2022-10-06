using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput _input;
    [SerializeField] PlayerData _robotData;

    private float _moveSpeed;
    private float _rotationSpeed;

    private void Start()
    {
        _input = GetComponentInParent<PlayerInput>();

        _moveSpeed = _robotData.MoveSpeed;
        _rotationSpeed = _robotData.RotateSpeed;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        transform.parent.Translate(new Vector3(_input.moveX, 0f, _input.moveZ).normalized * _moveSpeed * Time.deltaTime);

        transform.parent.Rotate(0f, _input.rotateX * _rotationSpeed, 0f, Space.World);
    }
}
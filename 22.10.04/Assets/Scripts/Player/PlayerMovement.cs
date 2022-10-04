using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput _input;

    [SerializeField] float _moveSpeed = 5f;
    [SerializeField] float _rotationSpeed = 3f;

    private void Start()
    {
        _input = GetComponent<PlayerInput>();
    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(_input.moveX, 0f, _input.moveZ).normalized * _moveSpeed * Time.deltaTime);

        transform.Rotate(0f, _input.rotateX * _rotationSpeed, 0f, Space.World);
    }
}
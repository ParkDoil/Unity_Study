using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput _input;

    [SerializeField]
    private float _moveSpeed = 5f;

    void Start()
    {
        _input = GetComponent<PlayerInput>();
    }

    void FixedUpdate()
    {
        transform.Translate(new Vector3(_input.moveX, 0f, _input.moveZ).normalized * _moveSpeed * Time.deltaTime);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float moveX { get; private set; }
    public float moveZ { get; private set; }

    public GameObject Head { get; private set; }

    private void Start()
    {
        Head = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        moveX = moveZ = 0f;

        if (Head.activeSelf == true)
        {
            if (Input.GetKey(KeyCode.A))
            {
                moveX -= 1f;
            }

            if (Input.GetKey(KeyCode.D))
            {
                moveX += 1f;
            }

            if (Input.GetKey(KeyCode.W))
            {
                moveZ += 1f;
            }

            if (Input.GetKey(KeyCode.S))
            {
                moveZ -= 1f;
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float moveX { get; private set; }
    public float moveZ { get; private set; }

    void FixedUpdate()
    {
        moveX = moveZ = 0f;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveX -= 1f;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveX += 1f;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveZ += 1f;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveZ -= 1f;
        }
    }
}

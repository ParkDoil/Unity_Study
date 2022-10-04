using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(-Input.GetAxis("Mouse Y") * 1.5f, 0f, 0f);
    }
}

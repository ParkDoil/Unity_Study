using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotManager : MonoBehaviour
{
    [SerializeField] GameObject[] _heads;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _heads[0].SetActive(true);
            _heads[1].SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _heads[0].SetActive(false);
            _heads[1].SetActive(true);
        }
    }
}

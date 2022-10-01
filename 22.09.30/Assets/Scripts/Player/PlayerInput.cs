using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private UIManager _uiManager;
    void Start()
    {
        _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _uiManager.ChangeStatus((int)State.FIRE_MAGIC);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            _uiManager.ChangeStatus((int)State.POSION_MAGIC);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            _uiManager.ChangeStatus((int)State.CURSE_MAGIC);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            _uiManager.ChangeStatus((int)State.NORMAL_FIST);
        }
    }
}

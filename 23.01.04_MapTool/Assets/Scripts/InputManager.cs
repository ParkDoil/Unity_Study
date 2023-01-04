using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public enum NowSelect
    {
        EMPTY,
        BUSH,
        RIVER,
        WALL
    }

    public NowSelect _nowSelect { get; private set; }

    private void Update()
    {
        #region 현재 선택한 큐브
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _nowSelect = NowSelect.EMPTY;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _nowSelect = NowSelect.BUSH;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _nowSelect = NowSelect.RIVER;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            _nowSelect = NowSelect.WALL;
        }
        #endregion
    }
}

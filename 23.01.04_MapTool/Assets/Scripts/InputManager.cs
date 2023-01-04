using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

    public UnityEvent<NowSelect> ChangeSelect = new UnityEvent<NowSelect>();

    private void Update()
    {
        #region 현재 선택한 큐브
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _nowSelect = NowSelect.EMPTY;
            ChangeSelect.Invoke(_nowSelect);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _nowSelect = NowSelect.BUSH;
            ChangeSelect.Invoke(_nowSelect);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _nowSelect = NowSelect.RIVER;
            ChangeSelect.Invoke(_nowSelect);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            _nowSelect = NowSelect.WALL;
            ChangeSelect.Invoke(_nowSelect);
        }
        #endregion
    }
}

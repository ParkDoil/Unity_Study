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

    [SerializeField] GameObject _map;
    private MapData _data;

    private void Awake()
    {
        _data = new MapData();
        _data.SetCube = new Queue<GameObject>();
        _data.AlreadyExsit = false;
    }

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

        if (Input.GetKeyDown(KeyCode.P))
        {
            GameManager.Instance.StartGame();
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            _data.AlreadyExsit = true;

            for (int i = 0; i < _map.transform.childCount; ++i)
            {
                _data.SetCube.Enqueue(_map.transform.GetChild(i).gameObject);
            }

            DataManager.Instance.SaveMap(_data);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            _data = DataManager.Instance.LoadMap();
            
            if (_data.AlreadyExsit != true)
            {
                return;
            }
            else
            {
                _map = _data.NowMap;
                GameObject _loadGameObject;

                while(_data.SetCube.Count != 0)
                {
                    _loadGameObject = _data.SetCube.Dequeue();
                    _loadGameObject.transform.SetParent(_map.transform);
                }

            }
        }
    }
}

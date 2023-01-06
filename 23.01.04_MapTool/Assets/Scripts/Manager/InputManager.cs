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

    private CubeSpawnClick _setCubeScripts;
    private CubeObjectPool _objPool;

    private void Awake()
    {

        _setCubeScripts = GetComponent<CubeSpawnClick>();
        _objPool = GetComponent<CubeObjectPool>();
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
            _data = new MapData();

            _data.AlreadyExist = true;

            for (int i = 0; i < _map.transform.childCount; ++i)
            {
                _data.ObjPosition.Add(_map.transform.GetChild(i).position);
                _data.Type.Add(_map.transform.GetChild(i).tag);
            }

            DataManager.Instance.SaveMap(_data);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            _data = DataManager.Instance.LoadMap();
            
            if (_data.AlreadyExist != true)
            {
                return;
            }
            else
            {
                GameObject _cube;

                for (int i = 0; i < _data.Type.Count; ++i)
                {
                    _cube = _objPool.GetCube();
                    _cube.transform.position = _data.ObjPosition[i];

                    switch(_data.Type[i])
                    {
                        case "Bush":
                            _cube.GetComponent<MeshRenderer>().material = _setCubeScripts.CubeMat[1];
                            _cube.tag = _data.Type[i];
                            break;

                        case "River":
                            _cube.GetComponent<MeshRenderer>().material = _setCubeScripts.CubeMat[2];
                            _cube.tag = _data.Type[i];
                            break;

                        case "Wall":
                            _cube.GetComponent<MeshRenderer>().material = _setCubeScripts.CubeMat[3];
                            _cube.tag = _data.Type[i];
                            break;
                    }

                    _cube.transform.SetParent(_map.transform);
                    _cube.SetActive(true);
                }
            }
        }
    }
}

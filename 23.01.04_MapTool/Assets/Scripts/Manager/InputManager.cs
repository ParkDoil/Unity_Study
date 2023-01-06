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
        _data = new MapData();

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

            for (int i = 0; i < _map.transform.childCount; ++i)
            {
                _data.X.Add(_map.transform.GetChild(i).position.x);
                _data.Y.Add(_map.transform.GetChild(i).position.y);
                _data.Z.Add(_map.transform.GetChild(i).position.z);
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

                for (int i = 0; i < _data.X.Count; ++i)
                {
                    _cube = _objPool.GetCube();
                    _cube.transform.position = new Vector3(_data.X[i], _data.Y[i], _data.Z[i]);

                    switch(_data.Type[i])
                    {
                        case "Bush":
                            _cube.GetComponent<MeshRenderer>().material = _setCubeScripts.CubeMat[1];
                            break;

                        case "River":
                            _cube.GetComponent<MeshRenderer>().material = _setCubeScripts.CubeMat[2];
                            break;

                        case "Wall":
                            _cube.GetComponent<MeshRenderer>().material = _setCubeScripts.CubeMat[3];
                            break;
                    }

                    _cube.transform.SetParent(_map.transform);
                }
            }
        }
    }
}

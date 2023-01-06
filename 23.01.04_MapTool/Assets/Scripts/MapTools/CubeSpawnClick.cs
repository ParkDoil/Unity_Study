using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawnClick : MonoBehaviour
{

    [field: SerializeField] public Material[] CubeMat { get; private set; }

    [SerializeField] private Transform _setCubeObject;

    private InputManager _input;
    private CubeObjectPool _cubes;

    private Vector3 _spawnPosition;
    private int _nowSelectCube;

    private Material _prevMaterial;

    private const string _bush = "Bush";
    private const string _river = "River";
    private const string _wall = "Wall";

    private void Start()
    {
        _cubes = GetComponent<CubeObjectPool>();
        _input = GetComponent<InputManager>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Map"))
                {
                    CheckPosition(hit.point);
                    SpawnCube();
                }
                #region 이미 큐브가 생성된 위치라면 변경시키는 코드
                else if (hit.transform.CompareTag(_bush))
                {
                    if(_input._nowSelect == InputManager.NowSelect.BUSH)
                    {
                        return;
                    }

                    else
                    {
                        ChangeCube(hit);
                    }
                }
                else if (hit.transform.CompareTag(_river))
                {
                    if (_input._nowSelect == InputManager.NowSelect.RIVER)
                    {
                        return;
                    }

                    else
                    {
                        ChangeCube(hit);
                    }
                }
                else if(hit.transform.CompareTag(_wall))
                {
                    if (_input._nowSelect == InputManager.NowSelect.WALL)
                    {
                        return;
                    }

                    else
                    {
                        ChangeCube(hit);
                    }
                }
                #endregion
            }
        }
    }

    private void ChangeCube(RaycastHit hit)
    {
        if(_input._nowSelect == InputManager.NowSelect.EMPTY)
        {
            hit.transform.gameObject.GetComponent<MeshRenderer>().material = CubeMat[0];
            hit.transform.gameObject.tag = "Untagged";
            _cubes.ReturnCube(hit.transform.gameObject);
        }
        else if (_input._nowSelect == InputManager.NowSelect.BUSH)
        {
            hit.transform.gameObject.GetComponent<MeshRenderer>().material = CubeMat[1];
            hit.transform.gameObject.tag = _bush;
        }
        else if (_input._nowSelect == InputManager.NowSelect.RIVER)
        {
            hit.transform.gameObject.GetComponent<MeshRenderer>().material = CubeMat[2];
            hit.transform.gameObject.tag = _river;
        }
        else if(_input._nowSelect == InputManager.NowSelect.WALL)
        {
            hit.transform.gameObject.GetComponent<MeshRenderer>().material = CubeMat[3];
            hit.transform.gameObject.tag = _wall;
        }
    }

    private void CheckPosition(Vector3 _position)
    {
        #region X좌표 계산 구역
        if (_position.x < -9)
        {
            _spawnPosition.x = -9;
        }

        else if (_position.x > 10)
        {
            _spawnPosition.x = 10;
        }

        else
        {
            _spawnPosition.x = Mathf.Round(_position.x);
        }
        #endregion
        #region Z좌표 계산 구역
        if (_position.z < -9)
        {
            _spawnPosition.z = -9;
        }

        else if (_position.z > 10)
        {
            _spawnPosition.z = 10;
        }

        else
        {
            _spawnPosition.z = Mathf.Round(_position.z);
        }
        #endregion
        _spawnPosition.y = _position.y;
    }

    private void SpawnCube()
    {
        GameObject _spawnCube = _cubes.GetCube();

        switch (_input._nowSelect)
        {
            case InputManager.NowSelect.EMPTY:
                break;

            case InputManager.NowSelect.BUSH:
                SettingCube(_spawnCube, _bush, 1);
                break;

            case InputManager.NowSelect.RIVER:
                SettingCube(_spawnCube, _river, 2);
                break;

            case InputManager.NowSelect.WALL:
                SettingCube(_spawnCube, _wall, 3);
                break;
        }

    }

    private void SettingCube(GameObject _spawnedCube, string _type, int _matIndex)
    {
        _spawnedCube.transform.SetParent(_setCubeObject);
        _spawnedCube.tag = _type;
        _spawnedCube.transform.position = _spawnPosition;
        _spawnedCube.GetComponent<MeshRenderer>().material = CubeMat[_matIndex];
        _spawnedCube.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawnClick : MonoBehaviour
{
    public enum NowSelect
    {
        EMPTY,
        BUSH,
        RIVER,
        WALL
    }

    [SerializeField] private Material[] _cubeMat;
    [SerializeField] private CubeObjectPool _cubes;

    private Vector3 _spawnPosition;
    private int _nowSelectCube;

    private Material _prevMaterial;

    private void Start()
    {
        _cubes = GetComponent<CubeObjectPool>();
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
                    Debug.Log(hit.point);
                    CheckPosition(hit.point);
                    SpawnCube();
                }
                #region 이미 큐브가 생성된 위치라면 변경시키는 코드
                else if (hit.transform.CompareTag("Bush"))
                {
                    if(_nowSelectCube == (int)NowSelect.BUSH)
                    {
                        return;
                    }

                    else
                    {
                        ChangeCube(hit);
                    }
                }
                else if (hit.transform.CompareTag("River"))
                {
                    if (_nowSelectCube == (int)NowSelect.RIVER)
                    {
                        return;
                    }

                    else
                    {
                        ChangeCube(hit);
                    }
                }
                else if(hit.transform.CompareTag("Wall"))
                {
                    if (_nowSelectCube == (int)NowSelect.WALL)
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

        #region 현재 선택한 큐브
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _nowSelectCube = (int)NowSelect.EMPTY;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _nowSelectCube = (int)NowSelect.BUSH;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _nowSelectCube = (int)NowSelect.RIVER;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            _nowSelectCube = (int)NowSelect.WALL;
        }
        #endregion
    }

    private void ChangeCube(RaycastHit hit)
    {
        if(_nowSelectCube == (int)NowSelect.EMPTY)
        {
            hit.transform.gameObject.GetComponent<MeshRenderer>().material = _cubeMat[0];
            hit.transform.gameObject.tag = "Untagged";
            _cubes.ReturnCube(hit.transform.gameObject);
        }
        else if (_nowSelectCube == (int)NowSelect.BUSH)
        {
            hit.transform.gameObject.GetComponent<MeshRenderer>().material = _cubeMat[1];
            hit.transform.gameObject.tag = "Bush";
        }
        else if (_nowSelectCube == (int)NowSelect.RIVER)
        {
            hit.transform.gameObject.GetComponent<MeshRenderer>().material = _cubeMat[2];
            hit.transform.gameObject.tag = "River";
        }
        else if(_nowSelectCube == (int)NowSelect.WALL)
        {
            hit.transform.gameObject.GetComponent<MeshRenderer>().material = _cubeMat[3];
            hit.transform.gameObject.tag = "Wall";
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
        switch (_nowSelectCube)
        {
            case (int)NowSelect.EMPTY   :
                break;
            case (int)NowSelect.BUSH    :
                _spawnCube.tag = "Bush";
                _spawnCube.transform.position = _spawnPosition;
                _spawnCube.GetComponent<MeshRenderer>().material = _cubeMat[1];
                _spawnCube.SetActive(true);
                break;
            case (int)NowSelect.RIVER:
                _spawnCube.tag = "River";
                _spawnCube.transform.position = _spawnPosition;
                _spawnCube.GetComponent<MeshRenderer>().material = _cubeMat[2];
                _spawnCube.SetActive(true);
                break;
            case (int)NowSelect.WALL:
                _spawnCube.tag = "Wall";
                _spawnCube.transform.position = _spawnPosition;
                _spawnCube.GetComponent<MeshRenderer>().material = _cubeMat[3];
                _spawnCube.SetActive(true);
                break;
        }

    }
}

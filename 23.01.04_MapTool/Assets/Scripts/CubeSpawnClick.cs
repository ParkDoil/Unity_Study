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

    private Vector3 _spawnPosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))  // ���콺�� Ŭ�� �Ǹ�
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Map"))
                {
                    Debug.Log(hit.point);
                    CheckPosition(hit.point);
                }
            }
        }
    }

    private void CheckPosition(Vector3 _position)
    {
        #region X��ǥ ��� ����
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
        #region Z��ǥ ��� ����
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
        
    }
}

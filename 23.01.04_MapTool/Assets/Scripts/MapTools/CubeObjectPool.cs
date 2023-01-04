using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _cube;
    [SerializeField] private GameObject _parentObject;

    private Queue<GameObject> CubesGroup = new Queue<GameObject>();

    private void Awake()
    {
        for (int i = 0; i < 400; i++)
        {
            CubesGroup.Enqueue(CreateCube());
        }
    }

    private GameObject CreateCube()
    {
        GameObject _object = Instantiate(_cube);
        _object.transform.SetParent(_parentObject.transform);
        _object.SetActive(false);
        return _object;
    }

    public GameObject GetCube()
    {
        if (CubesGroup.Count > 0)
        {
            GameObject _popCube = CubesGroup.Dequeue();
            return _popCube;
        }
        else
        {
            GameObject _newCube = CreateCube();
            return _newCube;
        }

    }

    public void ReturnCube(GameObject _returnedCube)
    {
        _returnedCube.SetActive(false);
        _returnedCube.transform.SetParent(_parentObject.transform);
        CubesGroup.Enqueue(_returnedCube);
    }

}

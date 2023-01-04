using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _cube;
    [SerializeField] private GameObject _parentObject;

    public GameObject[] ObjectPool; //{ get; set; }

    private void Awake()
    {
        ObjectPool = new GameObject[400];

        for (int i = 0; i < 400; i++)
        {
            ObjectPool[i] = Instantiate(_cube);
            ObjectPool[i].transform.parent = _parentObject.transform;
            ObjectPool[i].transform.position = _parentObject.transform.position;
            ObjectPool[i].SetActive(false);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;

    void Start()
    {
        for (int i = 0; i < 5000; ++i)
        {
            float x = Random.Range(-100f, 100f);
            float z = Random.Range(-100f, 100f);
            GameObject Enemy = Instantiate(_enemyPrefab);

            Vector3 StartPosition = new Vector3(x, 0f, z);
            Enemy.transform.position = StartPosition;
        }
    }
}

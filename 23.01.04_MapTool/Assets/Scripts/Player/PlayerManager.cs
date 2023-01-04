using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    private void Awake()
    {
       _player = transform.GetChild(0).gameObject;
        _player.SetActive(false);
    }

    private void OnEnable()
    {
        GameManager.Instance.PlayerSpawn.AddListener(SpawnPlayer);
    }

    private void SpawnPlayer()
    {
        _player.SetActive(true);
    }

    private void OnDisable()
    {
        GameManager.Instance.PlayerSpawn.RemoveListener(SpawnPlayer);
    }
}

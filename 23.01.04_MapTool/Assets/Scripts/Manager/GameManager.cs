using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : SingletonBehaviour<GameManager>
{

    public UnityEvent PlayerSpawn = new UnityEvent();

    [SerializeField] private GameObject _spawningCube;
    [SerializeField] private GameObject _ui;

    public void StartGame()
    {
        _spawningCube.SetActive(false);
        _ui.SetActive(false);
        PlayerSpawn.Invoke();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    #region ΩÃ±€≈Ê ∫Ø∞Ê
    public static GameManager Instance = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (Instance != this)
                Destroy(this.gameObject);
        }
    }
    #endregion

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int Damage { get; private set; }
    public float MoveSpeed { get; private set; }
    public float RotateSpeed { get; private set; }

    private void Awake()
    {
        Damage = Random.Range(10, 51);
        MoveSpeed = Random.Range(3f, 5f);
        RotateSpeed = Random.Range(3f, 5f);
    }
}

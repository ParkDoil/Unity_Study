using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponStatus
{
    FIST,
    WHIRLWIND,
    FLAMETHROWER,
    ROCKET
}

public class PlayerAttack : MonoBehaviour
{
    private PlayerInput _input;
    private GameObject _weapon;
    private int _robotDamage;

    [SerializeField] PlayerData _robotData;
    [SerializeField] Fist _fist;
    [SerializeField] Framethrower _framethrower;
    [SerializeField] Whirlwind _whirlwind;
    [SerializeField] Rocket _rocket;

    public bool _canAttack { get; private set; }

    void Start()
    {
        _input = GetComponent<PlayerInput>();
        _canAttack = true;
        _robotDamage = _robotData.Damage;
    }

    void Update()
    {
        if (_input.Head.activeSelf == true)
        {
            if (_canAttack == true)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    _canAttack = false;
                    _weapon = transform.GetChild(2).GetChild(0).GetChild(0).gameObject;
                    Attack(_weapon.tag);
                }

                if (Input.GetMouseButtonDown(1))
                {
                    _canAttack = false;
                    _weapon = transform.GetChild(2).GetChild(1).GetChild(0).gameObject;
                    Attack(_weapon.tag);
                }
            }
        }
    }

    private void Attack(string _weaponTag)
    {
        if (_weaponTag == WeaponStatus.FIST.ToString())
        {
            _fist.Attack(_robotDamage);
        }

        if (_weaponTag == WeaponStatus.WHIRLWIND.ToString())
        {
            _whirlwind.Attack(_robotDamage);
        }

        if (_weaponTag == WeaponStatus.FLAMETHROWER.ToString())
        {
            _framethrower.Attack(_robotDamage);
        }

        if (_weaponTag == WeaponStatus.ROCKET.ToString())
        {
            _rocket.Attack(_robotDamage);
        }
    }

    public void AttackFinish()
    {
        _canAttack = true;
    }
}
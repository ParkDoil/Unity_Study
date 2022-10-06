using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour, IAttackable
{
    private bool _isCooldown = false;
    private PlayerAttack _attack;

    private void Start()
    {
        _attack = transform.GetComponentInParent<Transform>().GetComponentInParent<Transform>().GetComponentInParent<PlayerAttack>();
    }

    public void Attack(int damage)
    {
        if (_isCooldown == false)
        {
            _isCooldown = true;
            StartCoroutine(RocketAttack(damage));
        }
        else
        {
            _attack.AttackFinish();
        }
    }

    IEnumerator RocketAttack(int damage)
    {
        Debug.Log("로켓발사 빵야");

        _attack.AttackFinish();

        Debug.Log(_attack.name);
        yield return new WaitForSeconds(5f);
        _isCooldown = false;
    }
}
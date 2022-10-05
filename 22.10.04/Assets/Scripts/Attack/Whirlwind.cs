using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whirlwind : MonoBehaviour, IAttackable
{
    private bool _isCooldown = false;
    private PlayerAttack _attack;

    private void Start()
    {
        _attack = transform.GetComponentInParent<Transform>().GetComponentInParent<Transform>().GetComponentInParent<PlayerAttack>();
    }

    public void Attack()
    {
        if (_isCooldown == false)
        {
            _isCooldown = true;
            StartCoroutine(WhirlwindAttack());
        }
        else
        {
            _attack.AttackFinish();
        }
    }

    IEnumerator WhirlwindAttack()
    {
        Debug.Log("휠윈드다! 오라오라");
        yield return new WaitForSeconds(2f);

        _attack.AttackFinish();

        Debug.Log(_attack.name);
        yield return new WaitForSeconds(1f);
        _isCooldown = false;
    }
}

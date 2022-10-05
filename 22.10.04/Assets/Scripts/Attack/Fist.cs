using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackable
{
    public void Attack();
}

public class Fist : MonoBehaviour, IAttackable
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
            StartCoroutine(FistAttack());
        }
        else
        {
            _attack.AttackFinish();
        }
    }

    IEnumerator FistAttack()
    {
        Debug.Log("ÁÖ¸Ô°ø°Ý ¶Ñ»þ¶Ñ»þ");

        _attack.AttackFinish();
        yield return new WaitForSeconds(1f);
        _isCooldown = false;
    }
}

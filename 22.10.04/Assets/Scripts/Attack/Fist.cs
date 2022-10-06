using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackable
{
    public void Attack(int damage);
}

public class Fist : MonoBehaviour, IAttackable
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
            StartCoroutine(FistAttack(damage));
        }
        else
        {
            _attack.AttackFinish();
        }
    }

    IEnumerator FistAttack(int damage)
    {
        Debug.Log("�ָ԰��� �ѻ��ѻ�");

        _attack.AttackFinish();
        yield return new WaitForSeconds(1f);
        _isCooldown = false;
    }
}

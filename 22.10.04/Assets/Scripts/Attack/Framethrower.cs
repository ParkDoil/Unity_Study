using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Framethrower : MonoBehaviour, IAttackable
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
            StartCoroutine(FramethrowerAttack(damage));
        }
        else
        {
            _attack.AttackFinish();
        }
    }

    IEnumerator FramethrowerAttack(int damage)
    {
        int tick = 0;
        Debug.Log("ȭ����� ���� �ο;Ɲ�");

        while (tick < 10)
        {
            Debug.Log("ȭ������");
            ++tick;
            yield return new WaitForSeconds(0.1f);
        }

        _attack.AttackFinish();

        Debug.Log(_attack.name);
        yield return new WaitForSeconds(1f);
        _isCooldown = false;
    }
}
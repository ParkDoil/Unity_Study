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
    public void Attack()
    {
        if (_isCooldown == false)
        {
            _isCooldown = true;
            StartCoroutine(FramethrowerAttack());
        }
        else
        {
            _attack.AttackFinish();
        }
    }

    IEnumerator FramethrowerAttack()
    {
        float _elapsedTime = 0.0f;
        int _tickDamage = 0;
        Debug.Log("화염방사 공격 부와아앜");

        while (_tickDamage < 5)
        {
            _elapsedTime += Time.deltaTime;
            if(_elapsedTime >= 0.5f)
            {
                Debug.Log("화르르르르륵");
                _elapsedTime = 0.0f;
                ++_tickDamage;
            }
        }

        _attack.AttackFinish();

        Debug.Log(_attack.name);
        yield return new WaitForSeconds(1f);
        _isCooldown = false;
    }
}
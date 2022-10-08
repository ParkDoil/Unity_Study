using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] GameObject[] _robotArms;

    private GameObject[] _weapons;
    private int _childrenCount;
    private bool[] _isSelect;

    private void Awake()
    {
        _childrenCount = transform.childCount;
        _weapons = new GameObject[_childrenCount];
        _isSelect = new bool[_childrenCount];

        for (int i = 0; i < _childrenCount; ++i)
        {
            _weapons[i] = transform.GetChild(i).gameObject;
            _isSelect[i] = false;
        }

        for (int i = 0; i < _robotArms.Length;)
        {
            int _randomnum = Random.Range(0, _childrenCount);

            if (_isSelect[_randomnum] == false)
            {
                _isSelect[_randomnum] = true;
                _weapons[_randomnum].transform.SetParent(_robotArms[i].transform);
                _weapons[_randomnum].transform.position = _robotArms[i].transform.position;
                ++i;
            }
        }
    }
}

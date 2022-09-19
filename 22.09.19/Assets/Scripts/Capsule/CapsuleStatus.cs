using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleStatus : MonoBehaviour
{
    [SerializeField]
    Material _basic;
    [SerializeField]
    Material _closest;

    GameObject _player;

    private MeshRenderer _myRenderer;

    private float _distance;

    void Start()
    {
        _myRenderer = GetComponent<MeshRenderer>();
        _myRenderer.material = _basic;
        _player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        _distance = Vector3.Distance(_player.transform.position, this.transform.position);

        if (_distance <= 5.0f)
        {
            ObjectManager.Instance.AddList(this.gameObject);
        }
        else
        {
            ObjectManager.Instance.RemoveList(this.gameObject);
        }
    }
    public void SetNormal()
    {
        _myRenderer.material = _basic;
    }
    public void ChangeColor()
    {
        _myRenderer.material = _closest;
    }
}

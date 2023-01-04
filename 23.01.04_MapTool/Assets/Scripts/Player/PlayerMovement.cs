using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const float _firstmoveSpeed = 3f;
    [SerializeField] private float _nowSpeed;

    private const string _bush = "Bush";
    private const string _river = "River";
    private const string _wall = "Wall";

    [SerializeField] private Material[] _playerMat;

    private Color _inBushColor;
    private Color _normalColor;

    private Transform _prevTransform;

    private void Start()
    {
        _inBushColor = new Color(255f, 0f, 0f, 0.5f);
        _normalColor = new Color(255f, 0f, 0f, 1f);
        _nowSpeed = _firstmoveSpeed;
    }

    private void Update()
    {
        _prevTransform = transform;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(_nowSpeed * Time.deltaTime * Vector3.forward);
        }

        if(Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(_nowSpeed * Time.deltaTime * Vector3.back);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(_nowSpeed * Time.deltaTime * Vector3.left);
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(_nowSpeed * Time.deltaTime * Vector3.right);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == _bush)
        {
            gameObject.GetComponent<MeshRenderer>().material = _playerMat[1];
        }

        if(other.transform.tag == _river)
        {
            _nowSpeed = _firstmoveSpeed / 2;
        }

        if (other.transform.tag == _wall)
        {
            other.GetComponent<BoxCollider>().isTrigger = false;
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == _bush)
        {
            Debug.Log("부쉬 나감");
            gameObject.GetComponent<MeshRenderer>().material = _playerMat[0];
        }

        if (other.transform.tag == _river)
        {
            _nowSpeed = _firstmoveSpeed;
        }

        if (other.transform.tag == _wall)
        {
            other.GetComponent<BoxCollider>().isTrigger = true;
        }


    }
}

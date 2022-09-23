using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Status : MonoBehaviour
{
    public bool IsLookRight { get; private set; }
    public bool IsWalkRight { get; private set; }
    public bool IsLookLeft { get; private set; }
    public bool IsWalkLeft { get; private set; }
    public bool IsPressShift { get;private set; }
    public bool IsPressDown { get; private set; }

    private TextMeshProUGUI _ui;

    private void Awake()
    {
        _ui = GetComponent<TextMeshProUGUI>();

        IsLookRight = true;
        IsWalkRight = false;
        IsLookLeft = false;
        IsWalkLeft = false;
        IsPressDown = false;
        IsPressShift = false;
    }

    // ������ Shift�� ��������
    private void Update()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            IsLookRight = IsWalkRight = IsLookLeft = false;
            IsWalkLeft = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            IsLookRight = IsWalkRight = IsWalkLeft = false;
            IsLookLeft = true;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            IsLookRight = IsWalkLeft = IsLookLeft = false;
            IsWalkRight = true;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            IsLookLeft = IsWalkRight = IsWalkLeft = false;
            IsLookRight = true;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            IsPressShift = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            IsPressShift = false;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            IsPressDown = true;
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            IsPressDown = false;
        }

        Show();
    }

    private void Show()
    {
        if (IsPressDown == true)
        {
            if (IsLookLeft == true)
            {
                _ui.text = "������ ���� ����� �ִ�.";
            }

            if (IsLookRight == true)
            {
                _ui.text = "�������� ���� ����� �ִ�.";
            }

            if (IsWalkLeft == true)
            {
                _ui.text = "�������� ���� �ִ�.";
            }

            if(IsWalkRight == true)
            {
                _ui.text = "���������� ���� �ִ�.";
            }
        }
        else
        {
            if (IsLookLeft == true)
            {
                _ui.text = "������ ���� �ִ�.";
            }

            if (IsLookRight == true)
            {
                _ui.text = "�������� ���� �ִ�.";
            }

            if (IsWalkLeft == true)
            {
                if (IsPressShift == true)
                {
                    _ui.text = "�������� �ٰ� �ִ�.";
                }
                else
                {
                    _ui.text = "�������� �Ȱ� �ִ�.";
                }
            }

            if (IsWalkRight == true)
            {
                if(IsPressShift == true)
                {
                    _ui.text = "���������� �ٰ� �ִ�.";
                }
                else
                {
                    _ui.text = "���������� �Ȱ� �ִ�.";
                }
            }
        }
    }
}

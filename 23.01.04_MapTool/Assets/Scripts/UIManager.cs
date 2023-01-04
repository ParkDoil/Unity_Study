using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private InputManager _input;

    [SerializeField] private TextMeshProUGUI _selectText;
    [SerializeField] private Image _image;

    private Color _wall = new Color(0f, 0f, 0f);
    private Color _bush = new Color(0f, 255f, 0f);
    private Color _river = new Color(0f, 0f, 255f);
    private Color _empty = new Color(255f, 255f, 255f, 0f);

    private void OnEnable()
    {
        _input.ChangeSelect.AddListener(ChangeUI);
    }

    private void ChangeUI(InputManager.NowSelect _nowSelect)
    {
        switch (_nowSelect)
        {
            case InputManager.NowSelect.EMPTY   :
                _image.color = _empty;
                _selectText.text = $"Empty";
                break;

            case InputManager.NowSelect.BUSH    :
                _image.color = _bush;
                _selectText.text = $"Bush";
                break;

            case InputManager.NowSelect.RIVER   :
                _image.color = _river;
                _selectText.text = $"River";
                break;

            case InputManager.NowSelect.WALL    :
                _image.color = _wall;
                _selectText.text = $"Wall";

                break;
        }

    }



    private void OnDisable()
    {
        _input.ChangeSelect.RemoveListener(ChangeUI);
    }
}

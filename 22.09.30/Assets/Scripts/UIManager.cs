using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _uiText;

    private void Awake()
    {

    }

    public void ChangeStatus(int status)
    {
        switch (status)
        {
            case (int)State.FIRE_MAGIC:
                _uiText.text = "Now Status : Burn";
                break;

            case (int)State.POSION_MAGIC:
                _uiText.text = "Now Status : Posion";
                break;

            case (int)State.CURSE_MAGIC:
                _uiText.text = "Now Status : Curse";
                break;

            case (int)State.NORMAL_FIST:
                _uiText.text = "Now Status : Fist";
                break;

        }
    }
}

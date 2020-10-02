using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class SetPlayerName : MonoBehaviour
{
    // PUBLIC VARS
    public Text _playerNameText = null;

    // PRIVATE VARS
    [SerializeField, ReadOnly] private bool _nameSet = false;


    void Start()
    {
        if (GetComponent<Text>() != null)
            _playerNameText = GetComponent<Text>();
    }

    void FixedUpdate()
    {
        if (!_nameSet)
        {
            if (GameSettings._instance != null && _playerNameText != null)
            {
                _playerNameText.text = GameSettings._instance._playerName;
                _nameSet = true;
            }
        }
    }
}

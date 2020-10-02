using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class SetPlayerEXP : MonoBehaviour
{
    // PUBLIC VARS
    public Text _playerEXPText = null;

    // PRIVATE VARS
    [SerializeField, ReadOnly] private bool _fieldSet = false;

    void Start()
    {
        if (GetComponent<Text>() != null)
            _playerEXPText = GetComponent<Text>();
        
        if (PlayerData._instance == null)
            Debug.Log("um, wat?");
    }

    void FixedUpdate()
    {
        if (!_fieldSet)
        {
            if (PlayerData._instance != null && _playerEXPText != null)
            {
                _playerEXPText.text = "EXP " + PlayerData._instance._playerEXP.ToString();
                _fieldSet = true;      
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatureContainer : MonoBehaviour
{
    [Header("Creature Data")]
    public CreatureData _cData = null;
    public CreatureInfoPopup _popUpMenu = null;

    // void Awake() {}

    void Start()
    {
        if (_cData != null)
        {
            InitCreatureData();
            FillOutPopupInfo();
        }
    }

    // void Update() {}
    // void FixedUpdate() {}

    void InitCreatureData()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.sprite = _cData.CreatureImage;
        gameObject.name = _cData.CreatureName;

        BoxCollider2D bc = GetComponent<BoxCollider2D>();
        bc.size = _cData.ColliderSize;
    }

    void FillOutPopupInfo()
    {
        if (_popUpMenu != null)
        {
            _popUpMenu._displayName.text = _cData.CreatureName;
            for (int i = 0; i < 6; i++)
            {
                _popUpMenu._stats[i].text += _cData.CreatureStats[i].ToString();
            }
        }
    }
}

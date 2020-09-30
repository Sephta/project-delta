using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatureInfoPopup : MonoBehaviour
{
    [Header("Creature Displayable Stats")]
    public Text _displayName = null;
    [SerializeField] public List<Text> _stats = new List<Text>();
}

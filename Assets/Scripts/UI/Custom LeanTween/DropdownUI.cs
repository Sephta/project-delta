using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownUI : MonoBehaviour
{
    public bool _startState = false;
    public LeanTweenType _easeIn;
    public LeanTweenType _easeOut;
    public GameObject _tweenObject = null;
    public Vector2 _originalPos = Vector2.zero;
    public Vector3 _originalScale = Vector3.zero;
    public Vector2 _newPos = Vector2.zero;
    public Vector3 _newScale = Vector3.zero;
    public float _timeToTween = 0f;
    public float _delayTime = 0f;


    void Awake()
    {
        gameObject.SetActive(_startState);
    }

    void OnEnable()
    {
        LeanTween.move(_tweenObject.GetComponent<RectTransform>(), _newPos, _timeToTween).setDelay(_delayTime).setEase(_easeIn);
        LeanTween.scale(_tweenObject, _newScale, _timeToTween).setDelay(_delayTime).setEase(_easeIn);
    }

    // void OnDisable()
    // {
    //     LeanTween.moveY(_tweenObject.GetComponent<RectTransform>(), _originalPos.y, _timeToTween).setDelay(_delayTime).setEase(_easeIn);
    //     LeanTween.scale(_tweenObject, _originalScale, _timeToTween).setDelay(_delayTime).setEase(_easeIn);
    // }

    // void Start() {}
    // void Update() {}
    // void FixedUpdate() {}

    private void InitObject()
    {
        GetComponent<RectTransform>().localScale = _newScale;
        GetComponent<RectTransform>().position = _newPos;
    }

    private void ToggleObjectActiveState()
    {
        if (!_startState)
            InitObject();

        gameObject.SetActive(!gameObject.activeSelf);
    }

    private void CollapseMenu()
    {
        LeanTween.move(_tweenObject.GetComponent<RectTransform>(), _originalPos, _timeToTween).setDelay(_delayTime).setEase(_easeIn);
        LeanTween.scale(_tweenObject, _originalScale, _timeToTween).setDelay(_delayTime).setEase(_easeIn).setOnComplete(ToggleObjectActiveState);
    }

    public void ToggleMenuCollapse()
    {
        if (!gameObject.activeSelf)
            ToggleObjectActiveState();
        else
            CollapseMenu();
    }
}

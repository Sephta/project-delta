using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindEventCamera : MonoBehaviour
{

    public Canvas _canvas = null;

    void Awake()
    {
        if (GetComponent<Canvas>() != null)
            _canvas = GetComponent<Canvas>();
    }

    void Start()
    {
        if (_canvas != null)
            _canvas.worldCamera = GameObject.Find("Game Camera").GetComponent<Camera>();
    }

    // void Update() {}
    // void FixedUpdate() {}
}

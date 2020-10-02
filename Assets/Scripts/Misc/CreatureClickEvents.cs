using UnityEngine;

public class CreatureClickEvents : MonoBehaviour
{

    public CreatureInfoPopup _popUpMenu = null;

    [Header("Tooltip Settings")]
    [SerializeField, Range(0f, 2f)] public float MaxTime = 0.5f;
    [SerializeField, ReadOnly] private float _timer = 0f;

    void Start()
    {
        _timer = MaxTime;
    }

    void OnMouseEnter() {}

    void OnMouseExit()
    {
        _popUpMenu.gameObject.SetActive(false);
        _timer = MaxTime;
    }

    // void OnMouseDown() {}
    // void OnMouseUp() {}
    // void OnMouseDrag() {}

    void OnMouseOver()
    {
        DecrementTimer();

        if (_timer <= 0)
            _popUpMenu.gameObject.SetActive(true);
    }

    private void DecrementTimer()
    {
        _timer -= Time.deltaTime;
        _timer = Mathf.Clamp(_timer, 0, MaxTime);
    }
}

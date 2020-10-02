using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehavior : StateMachineBehaviour
{
    // PUBLIC VARS
    [ReadOnly] public Vector2 currDestination = Vector2.zero;
    public float moveSpeedMax = 0f;
    public float moveSpeedMin = 0f;
    [SerializeField, ReadOnly] private float currSpeed = 0f;
    [Range(0, 1)] public float t_accel = 0f;
    [SerializeField, ReadOnly] private float t = 0f;
    // public float xRange = 0f;
    // public float yRange = 0f;

    [Range(0, 5)] public float distThreshold = 0f;

    // PRIVATE VARS
    [SerializeField, ReadOnly] private Vector2 currDirection = Vector2.zero;
    private Rigidbody2D _crb = null;

    [SerializeField, ReadOnly] private Vector2 mousePos = Vector2.zero;
    [SerializeField, Range(1f, 8f)] public float MaxTime = 0f;
    [SerializeField, ReadOnly] private float _timer = 0f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.gameObject.GetComponent<Rigidbody2D>() != null)
            _crb = animator.gameObject.GetComponent<Rigidbody2D>();
        else
            Debug.Log("Warning. Creature<" + animator.gameObject.name + ">" + " may not have Rigidbody2D.");

        currDirection = CalculateDirection();
        _timer = Random.Range(0, MaxTime);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // For debugging purposes...
        mousePos = GetMouseWorldPos();
        
        // decrement time till find next travel direction
        DecrementTimer();

        // if 
        if (Vector3.Distance(animator.gameObject.transform.position, GetMouseWorldPos()) < distThreshold)
            animator.SetBool("mouseClose", true);
        else
            animator.SetBool("mouseClose", false);

        if (_timer <= 0)
        {
            currDirection = CalculateDirection();
            _timer = Random.Range(0, MaxTime);
        }

        currSpeed = Mathf.Lerp(moveSpeedMax, moveSpeedMin, t);

        if (animator.GetBool("mouseClose"))
        {
            t += t_accel * Time.deltaTime;
            t = Mathf.Clamp(t, 0, 1);
        }
        else
        {
            t -= t_accel * Time.deltaTime;
            t = Mathf.Clamp(t, 0, 1);
        }

        _crb.AddForce(((currDirection * currSpeed * -1f) - _crb.velocity) * Time.deltaTime, ForceMode2D.Impulse);
    }

    private Vector2 CalculateDirection()
    {
        float clampX = ((float)Random.Range(-100, 101)) / 100;
        float clampY = ((float)Random.Range(-100, 101)) / 100;

        clampX = Mathf.Clamp(clampX, -1f, 1f);
        clampY = Mathf.Clamp(clampY, -1f, 1f);

        Vector2 result = new Vector2(clampX, clampY);

        return result;
    }

    private Vector2 GetMouseWorldPos()
    {
        Vector3 getMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return new Vector2(getMouse.x, getMouse.y);
    }

    private void DecrementTimer()
    {
        _timer -= Time.deltaTime;
        _timer = Mathf.Clamp(_timer, 0, MaxTime);
    }
}

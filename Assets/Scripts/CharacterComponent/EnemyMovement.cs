using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float Speed = 1;
    private float curSpeed;
    [SerializeField] private Animator animator;
    public bool IsTracking = true;

    private void FixedUpdate()
    {
        Aiming aiming = GetComponent<Aiming>();
        curSpeed = Speed;
        if (IsTracking)
        {
            Track();
        }
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = aiming.Direction * Time.fixedDeltaTime * curSpeed;
        animator.SetFloat("Horizontal", aiming.Direction.x);
        animator.SetFloat("Vertical", aiming.Direction.y);
    }

    private void Track()
    {
        Tracking tracking = GetComponentInChildren<Tracking>();
        float skillRange = GetComponentsInChildren<CircleCollider2D>()[1].radius;
        if (tracking.Distance <= skillRange)
        {
            curSpeed = 0;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float Speed = 1;
    private float curSpeed;
    [SerializeField] private Animator animator;
    public bool Distancing = true;

    private void FixedUpdate()
    {
        Aiming aiming = GetComponent<Aiming>();
        curSpeed = Speed;
        if (Distancing)
        {
            DoDistancing();
        }
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = aiming.Direction * Time.fixedDeltaTime * curSpeed;
        animator.SetFloat("Horizontal", aiming.Direction.x);
        animator.SetFloat("Vertical", aiming.Direction.y);
    }

    private void DoDistancing()
    {
        Tracking tracking = GetComponentInChildren<Tracking>();
        float skillRange = GetComponentsInChildren<CircleCollider2D>()[1].radius;
        if (tracking.Distance <= skillRange)
        {
            curSpeed = 0;
        }
        else
        {
            curSpeed = Speed;
        }
    }
}

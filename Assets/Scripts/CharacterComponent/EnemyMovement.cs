using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float Speed = 1;
    private float curSpeed;
    [SerializeField] private Animator animator;
    private Vector2 direction;

    private void FixedUpdate()
    {
        Aiming aiming = GetComponent<Aiming>();
        curSpeed = Speed;
        if (!aiming.Lock)
        {
            Track();
            direction = aiming.Direction;
        }
        transform.Translate(aiming.Direction * Time.fixedDeltaTime * curSpeed);
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

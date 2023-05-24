using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float Speed = 1;
    public bool IsTracking { get; set; } = true;
    public Vector2 Direction { get; set; } = Vector2.zero;
    private Tracking tracking;
    private float skillRange;

    private void Start()
    {
        tracking = GetComponentInChildren<Tracking>();
        CircleCollider2D[] collider = GetComponentsInChildren<CircleCollider2D>();
        skillRange = collider[1].radius;
    }

    private void FixedUpdate()
    {
        if (tracking.HasTarget && IsTracking)
        {
            Track();
        }
        transform.Translate(Direction * Time.fixedDeltaTime * Speed);
    }

    private void Track()
    {
        Transform target = tracking.Target;
        float distance = Vector2.Distance(target.position, transform.position);
        if (distance > skillRange)
        {
            Vector2 movement = target.position - transform.position;
            movement.x = Mathf.Sign(movement.x);
            movement.y = Mathf.Sign(movement.y);
            Direction = movement;
        }
        else
        {
            Direction = Vector2.zero;
        }
    }
}

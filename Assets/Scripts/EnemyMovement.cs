using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float Speed = 1;
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
        if (tracking.HasTarget)
        {
            Track();
        }
    }

    private void Track()
    {
        Transform target = tracking.Target;
        float distance = Vector2.Distance(target.position, transform.position);
        if (distance > skillRange)
        {
            Vector2 movement = target.position - transform.position;
            movement.x /= Mathf.Abs(movement.x);
            movement.y /= Mathf.Abs(movement.y);
            transform.Translate(movement * Time.fixedDeltaTime * Speed);
        }
    }
}

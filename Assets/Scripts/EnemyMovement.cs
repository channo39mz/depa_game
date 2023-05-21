using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private int moveSpeed = 1;
    public int MoveSpeed
    {
        get => moveSpeed;
        set => moveSpeed = value;
    }
    private Transform target;
    private float atkRange;

    private void Start() {
        atkRange = GetComponent<AttackRange>().AtkRange;
    }

    private void FixedUpdate() {
        if (HasTarget()) Move();
    }

    private bool HasTarget()
    {
        if (target != null) return true;
        return false;
    }

    private void Move()
    {
        float distance = Vector2.Distance(target.position, transform.position);
        if (distance > atkRange)
        {
            Vector2 movement = target.position - transform.position;
            movement.x /= Mathf.Abs(movement.x);
            movement.y /= Mathf.Abs(movement.y);
            transform.Translate(movement * Time.fixedDeltaTime * moveSpeed);
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Player")
        {
            target = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player")
        {
            target = null;
        }
    }
}

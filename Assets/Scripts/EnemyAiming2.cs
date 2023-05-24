using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAiming2 : MonoBehaviour
{
    private GameObject target;
    public bool HasTarget { get; private set; }
    private Vector2 direction;
    public Vector2 Direction { get => direction; }

    private void Update()
    {
        if (HasTarget)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            Vector2 lookDir = (Vector2)target.transform.position - rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg / 180 * Mathf.PI;
            direction.x = Mathf.Cos(angle);
            direction.y = Mathf.Sin(angle);
        }
        else
        {
            direction = Vector2.zero;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            target = other.gameObject;
            HasTarget = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            target = null;
            HasTarget = false;
        }
    }
}

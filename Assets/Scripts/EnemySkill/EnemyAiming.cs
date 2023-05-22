using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAiming : MonoBehaviour
{
    private GameObject target;
    public bool HasTarget { get; private set; }
    private void Update()
    {
        if (HasTarget)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            Vector2 lookDir = (Vector2)target.transform.position - rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
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

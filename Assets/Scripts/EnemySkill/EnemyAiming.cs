using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAiming : MonoBehaviour
{
    public bool HasTarget { get; private set; }

    private void Update()
    {
        Aiming aiming = GetComponentInParent<Aiming>();
        float angle = Mathf.Atan2(aiming.Direction.y, aiming.Direction.x) * Mathf.Rad2Deg - 90f;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.rotation = angle;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            HasTarget = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            HasTarget = false;
        }
    }
}

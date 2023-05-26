using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracking : MonoBehaviour
{
    public Transform Target { get; private set; }
    public bool HasTarget { get; private set; }
    public float Distance { get; private set; }

    private void Update()
    {
        if (HasTarget)
        {
            Distance = Vector2.Distance(Target.position, transform.position);
        }
        else
        {
            Distance = float.MaxValue;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Target = other.transform;
            HasTarget = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player")
        {
            Target = null;
            HasTarget = false;
        }
    }
}

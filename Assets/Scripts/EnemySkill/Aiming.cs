using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    [SerializeField] private string targetTag;
    public bool Lock { get; set; } = false;
    public Vector2 Direction { get; private set; }

    private void Update()
    {
        Tracking tracking = GetComponentInChildren<Tracking>();
        if (!Lock && tracking.HasTarget)
        {
            Direction = (tracking.Target.position - transform.position).normalized;
        }
    }
}

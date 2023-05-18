using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRange : MonoBehaviour
{
    [SerializeField] private float atkRange = 1.5f;
    public float AtkRange { get => atkRange; }
    private Dictionary<GameObject, float> targets = new Dictionary<GameObject, float>();

    public GameObject SelectTarget()
    {
        if (targets.Keys.Count == 0) return null;
        List<GameObject> tmp = new List<GameObject>(targets.Keys);
        return tmp[0];
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Player")
        {
            float distance = Vector2.Distance(transform.position, other.transform.position);
            if (distance <= atkRange)
            {
                targets.TryAdd(other.gameObject, distance);
            }
            else
            {
                targets.Remove(other.gameObject);
            }
        }
    }
}

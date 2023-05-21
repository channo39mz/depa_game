using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{   
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private bool hitPlayer = true;
    [SerializeField] private bool hitEnemy = true;
    [HideInInspector] public float damage;

    void Update()
    {
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" && hitPlayer)
        {
            Hit(other);
        }
        else if (other.tag == "Enemy" && hitEnemy)
        {
            Hit(other);
        }
    }

    private void Hit(Collider2D other)
    {
        Destroy(gameObject);
        DamageManager manager = other.gameObject.GetComponent<DamageManager>();
        manager.TakeDamage(damage);
        // GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        // Destroy(effect, 0.5f);
        // Debug.Log("Hit");
    }
}

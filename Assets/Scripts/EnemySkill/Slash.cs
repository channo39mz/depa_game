using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : SkillCD
{
    private GameObject target;
    private bool hasTarget;

    private void Update() {
        if (hasTarget && Ready)
        {
            SlashAttack();
            Use();
        }
    }

    private void SlashAttack()
    {
        DamageManager manager = target.GetComponent<DamageManager>();
        float damage = GetComponentInParent<AttackPower>().Atk;
        manager.TakeDamage(damage);
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Player")
        {
            target = other.gameObject;
            hasTarget = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            target = null;
            hasTarget = false;
        }
    }
}

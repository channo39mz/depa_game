using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : SkillCD
{
    private void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Player" && Ready)
        {
            DamageManager manager = other.GetComponent<DamageManager>();
            float damage = GetComponentInParent<AttackPower>().Atk;
            manager.TakeDamage(damage);
            Use();
        }
    }
}

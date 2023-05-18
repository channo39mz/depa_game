using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{
    private AttackPower power;
    private AttackCoolDown coolDown;
    private AttackRange range;

    private void Start()
    {
        power = GetComponent<AttackPower>();
        coolDown = GetComponent<AttackCoolDown>();
        range = GetComponent<AttackRange>();
    }

    private void Update() {
        if (coolDown.ready && hasTarget())
        {
            Attack();
        }
    }

    public void Attack()
    {
        coolDown.DoAttack();
        GameObject target = range.SelectTarget();
        Damageable targetDamageable = target.GetComponent<Damageable>();
        targetDamageable.TakeDamage(power.Atk);
        Debug.Log("Attack " + target.name + " with Atk " + power.Atk);
    }

    private bool hasTarget()
    {
        GameObject target = range.SelectTarget();
        if (target != null) return true;
        return false;
    }
}

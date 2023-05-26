using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : SkillCD
{
    [SerializeField] private float time = 1;
    [SerializeField] private float speed = 5;
    private bool hasTarget;
    private Aiming aiming;
    private EnemyMovement movement;
    private float tmpSpeed;
    private bool isDashing = false;

    private void Start()
    {
        aiming = GetComponentInParent<Aiming>();
        movement = GetComponentInParent<EnemyMovement>();
        tmpSpeed = movement.Speed;
    }

    private void Update()
    {
        if (Ready && hasTarget)
        {
            DashAttack();
            Use();
        }
    }

    private void DashAttack()
    {
        StartCoroutine(DashForSeconds(time));
    }

    private IEnumerator DashForSeconds(float time)
    {
        movement.IsTracking = false;
        aiming.Lock = true;
        tmpSpeed = movement.Speed;
        movement.Speed = speed;
        isDashing = true;
        yield return new WaitForSeconds(time);
        movement.IsTracking = true;
        aiming.Lock = false;
        movement.Speed = tmpSpeed;
        isDashing = false;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            hasTarget = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            hasTarget = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.tag == "Player" && isDashing)
        {
            float damage = GetComponentInParent<AttackPower>().Atk;
            other.gameObject.GetComponent<DamageManager>().TakeDamage(damage);
            isDashing = false;
        }
    }
}

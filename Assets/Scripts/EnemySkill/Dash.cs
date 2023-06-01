using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : SkillCD
{
    [SerializeField] private float time = 1;
    [SerializeField] private float speed = 5;
    [SerializeField] private float chargingTime = 1;
    private bool hasTarget;
    private Aiming aiming;
    private EnemyMovement movement;
    private Animator animator;
    private bool isDashing;
    public bool IsDashing
    {
        get => isDashing;
        private set
        {
            isDashing = value;
            if (value)
            {
                animator.SetBool("IsDashing", true);
            }
            else
            {
                animator.SetBool("IsDashing", false);
            }
        }
    }
    private bool isCharging;
    public bool IsCharging
    {
        get => isCharging;
        private set
        {
            isCharging = value;
            if (value)
            {
                animator.SetBool("IsCharging", true);
            }
            else
            {
                animator.SetBool("IsCharging", false);
            }
        }
    }

    private void Start()
    {
        aiming = GetComponentInParent<Aiming>();
        movement = GetComponentInParent<EnemyMovement>();
        animator = GetComponentInParent<Animator>();
    }

    private void Update()
    {
        if (Ready && hasTarget)
        {
            DashAttack();
        }
    }

    private void DashAttack()
    {
        StartCoroutine(DashForSeconds());
    }

    private IEnumerator DashForSeconds()
    {
        float tmp = movement.Speed;
        movement.Speed = 0;
        IsCharging = true;
        yield return new WaitForSeconds(chargingTime);
        IsCharging = false;
        Use();
        movement.Distancing = false;
        aiming.Lock = true;
        movement.Speed = speed;
        IsDashing = true;
        yield return new WaitForSeconds(time);
        movement.Distancing = true;
        aiming.Lock = false;
        movement.Speed = tmp;
        IsDashing = false;
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
        
        if (other.gameObject.tag == "Player" && IsDashing)
        {
            float damage = GetComponentInParent<AttackPower>().Atk;
            other.gameObject.GetComponent<DamageManager>().TakeDamage(damage);
            IsDashing = false;
        }
    }
}

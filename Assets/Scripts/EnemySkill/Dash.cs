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

    private void Start()
    {
        aiming = GetComponentInParent<Aiming>();
        movement = GetComponentInParent<EnemyMovement>();
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
        aiming.Lock = true;
        float tmp = movement.Speed;
        movement.Speed = speed;
        yield return new WaitForSeconds(time);
        aiming.Lock = false;
        movement.Speed = tmp;
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
}

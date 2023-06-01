using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roar : SkillCD
{
    [SerializeField] private float time = 5;
    private EnemyMovement movement;
    private Slash slash;
    private SpriteRenderer sprite;
    private Animator animator;
    private bool isRoaring;
    public bool IsRoaring
    {
        get => isRoaring;
        private set
        {
            isRoaring = value;
            if (value)
            {
                animator.SetBool("IsRoaring", true);
            }
            else
            {
                animator.SetBool("IsRoaring", false);
            }
        }
    }

    private void Start() {
        movement = GetComponentInParent<EnemyMovement>();
        slash = GetComponent<Slash>();
        slash.enabled = false;
        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = false;
        animator = GetComponentInParent<Animator>();
    }
    private void Update() {
        if (Ready && slash.hasTarget)
        {
            StartRoar();
            Use();
        }
    }

    private void StartRoar()
    {
        StartCoroutine(RoarForSeconds(time));
    }

    private IEnumerator RoarForSeconds(float waittime)
    {
        float tmp = movement.Speed;
        movement.Speed -= tmp;
        slash.enabled = true;
        sprite.enabled = true;
        IsRoaring = true;
        yield return new WaitForSeconds(waittime);
        movement.Speed += tmp;
        slash.enabled = false;
        sprite.enabled = false;
        IsRoaring = false;
    }
}

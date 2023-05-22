using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roar : SkillCD
{
    [SerializeField] private float time = 5;
    private EnemyMovement movement;
    private Slash slash;
    private SpriteRenderer sprite;

    private void Start() {
        movement = GetComponentInParent<EnemyMovement>();
        slash = GetComponent<Slash>();
        slash.enabled = false;
        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = false;
    }
    private void Update() {
        if (Ready)
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
        float changeSpeed = movement.Speed;
        movement.Speed -= changeSpeed;
        slash.enabled = true;
        sprite.enabled = true;
        yield return new WaitForSeconds(waittime);
        movement.Speed += changeSpeed;
        slash.enabled = false;
        sprite.enabled = false;
    }
}

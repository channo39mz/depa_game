using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : SkillCD
{
    [SerializeField] private float bulletForce = 5;
    private EnemyAiming2 aiming;

    private void Start() {
        aiming = GetComponent<EnemyAiming2>();
    }

    private void Update() {
        if (Ready && aiming.HasTarget)
        {
            Shoot();
            Use();
        }
    }

    private void Shoot()
    {
        Rigidbody2D[] parentrb = GetComponentsInParent<Rigidbody2D>();
        parentrb[1].AddForce(aiming.Direction * bulletForce, ForceMode2D.Impulse);
    }
}

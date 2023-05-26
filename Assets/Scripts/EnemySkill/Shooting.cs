using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : SkillCD
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletForce = 5;

    private void Update()
    {
        EnemyAiming aiming = GetComponent<EnemyAiming>();
        if (Ready && aiming.HasTarget)
        {
            Shoot();
            Use();
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bulletComponent = bullet.GetComponent<Bullet>();
        bulletComponent.damage = GetComponentInParent<AttackPower>().Atk;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletForce = 5;
    private AttackCoolDown coolDown;

    private void Start() {
        coolDown = GetComponentInParent<AttackCoolDown>();
        
    }

    private void Update() {
        EnemyAiming aiming = GetComponent<EnemyAiming>();
        if (coolDown.Ready && aiming.HasTarget)
        {
            Shoot();
            coolDown.DoAttack();
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

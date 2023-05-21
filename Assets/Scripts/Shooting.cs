using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletForce = 20;
    [SerializeField] public bool enable = false;
    private AttackCoolDown coolDown;

    private void Start() {
        coolDown = GetComponent<AttackCoolDown>();
    }

    private void Update() {
        Aiming aiming = GetComponent<Aiming>();
        if (enable && coolDown.Ready && aiming.HasTarget)
        {
            Shoot();
            coolDown.DoAttack();
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bulletComponent = bullet.GetComponent<Bullet>();
        bulletComponent.owner = gameObject;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}

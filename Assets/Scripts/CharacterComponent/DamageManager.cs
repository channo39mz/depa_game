using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    private Health health;

    private void Start()
    {
        health = GetComponent<Health>();
    }

    public void TakeDamage(float amount)
    {
        health.decreaseHP(amount);
    }
}

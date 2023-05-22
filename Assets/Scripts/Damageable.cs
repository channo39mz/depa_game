using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    private Health health;
    // Start is called before the first frame update
    private void Start()
    {
        health = GetComponent<Health>();
    }

    public void TakeDamage(float amount)
    {
        health.decreaseHP(amount);
    }
}

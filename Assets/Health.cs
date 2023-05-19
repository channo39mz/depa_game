using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float MaxHP;
    public float HP { get; private set; }

    private void Start()
    {
        HP = MaxHP;
    }

    public void decreaseHP(float amount)
    {
        float tmpHP = HP;
        tmpHP -= amount;

        if (tmpHP <= 0)
        {
            HP = 0;
            Die();
        }
        else
        {
            HP = tmpHP;
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
        Debug.Log(name + " was died");
    }

    public float getMaxHP(){
        return MaxHP;
    }
}

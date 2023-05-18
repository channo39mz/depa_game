using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int MaxHP = 10;
    public int HP { get; private set; }
    // Start is called before the first frame update
    private void Start()
    {
        HP = MaxHP;
    }

    public void decreaseHP(int amount)
    {
        int tmpHP = HP;
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
}

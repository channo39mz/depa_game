using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float MaxHP;
    public float HP { get; private set; }
    [SerializeField] private GameObject floatingDamage;
    private void Start()
    {
        HP = MaxHP;
    }

    public void decreaseHP(float amount)
    {
        ShowDamage(amount);
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
        Death death = GetComponent<Death>();
        death.Manage();
    }

    public float getMaxHP(){
        return MaxHP;
    }

    private void ShowDamage(float amount){
        if(floatingDamage && amount != 0){
            GameObject prefab = Instantiate(floatingDamage,transform.position,Quaternion.identity);
            prefab.GetComponentInChildren<TextMesh>().text = amount.ToString();
        }
    }

    public void Heal(float amount){
        if(HP + amount < MaxHP){
            HP += amount;
        }
        else{
            HP = MaxHP;
        }
    }
}

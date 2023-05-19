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

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            decreaseHP(5);
        }
    }

    public void decreaseHP(float amount)
    {
        ShowDamage(amount.ToString());
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

    private void ShowDamage(string amount){
        if(floatingDamage){
            GameObject prefab = Instantiate(floatingDamage,transform.position,Quaternion.identity);
            prefab.GetComponentInChildren<TextMesh>().text = amount;
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

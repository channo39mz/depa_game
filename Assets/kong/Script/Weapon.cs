using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float weaponDamage;
    public float cooldown;
    public float manaRegen;
    public Animator weaponAnimate;
    public Mana playerMana;
    public void OnAttack(){
        weaponAnimate.SetTrigger("Attack");
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Enemy"){
            collision.gameObject.GetComponentInParent<Health>().decreaseHP(weaponDamage);
            playerMana.ManaRegenOnHit(manaRegen);
        }
    }
}

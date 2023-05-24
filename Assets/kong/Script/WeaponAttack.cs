using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponAttack : MonoBehaviour
{
    [SerializeField] private Animator weaponAnimate;
    [SerializeField] private Weapon curWeapon;
    [SerializeField] private Mana playerMana;
    private float ManaRegen = 2f;
    private float curWeaponDamage;
    void Awake(){
        curWeaponDamage = curWeapon.weaponDamage;
    }
    public void OnAttack(InputAction.CallbackContext context){
        if(context.phase == InputActionPhase.Performed){
            weaponAnimate.SetTrigger("Attack");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Enemy"){
            collision.gameObject.GetComponentInParent<Health>().decreaseHP(curWeaponDamage);
            playerMana.ManaRegenOnHit(ManaRegen);
        }
    }
}
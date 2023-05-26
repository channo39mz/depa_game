using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponAttack : MonoBehaviour
{
    // [SerializeField] private Animator weaponAnimate;
    // [SerializeField] private float weaponDamage;
    // [SerializeField] private float delay;
    // [SerializeField] private float ManaRegen;
    [SerializeField] private GameObject weapon;
    [SerializeField] private Mana playerMana;
    public GameObject playerWeapon;
    // private float weaponDamage;
    // private float manaRegen;
    private float delay;
    private GameObject cloneWeapon;
    // private Animator weaponAnimate;
    private bool IsCD;
    void Start(){
        IsCD = false;
        delay = weapon.GetComponent<Weapon>().cooldown;
        // manaRegen = weapon.GetComponent<Weapon>().manaRegen;
        // weaponDamage = weapon.GetComponent<Weapon>().weaponDamage;
        // weaponAnimate = weapon.GetComponent<Weapon>().weaponAnimate;
    }
    void Update(){
        if(Input.GetMouseButtonDown(0)){
            OnAttack();
        }
    }
    public void OnAttack(){
        if(!IsCD){
            cloneWeapon = Instantiate(weapon,playerWeapon.transform.position,playerWeapon.transform.rotation);
            cloneWeapon.transform.SetParent(playerWeapon.transform);
            cloneWeapon.GetComponent<Weapon>().playerMana = playerMana;
            cloneWeapon.GetComponent<Weapon>().OnAttack();
            // weaponAnimate.SetTrigger("Attack");
            StartCoroutine(DelayAttack());
        }
        IsCD = true;
    }

    // private void OnTriggerEnter2D(Collider2D collision){
    //     if(collision.gameObject.tag == "Enemy"){
    //         collision.gameObject.GetComponentInParent<Health>().decreaseHP(weaponDamage);
    //         playerMana.ManaRegenOnHit(manaRegen);
    //     }
    // }

    private IEnumerator DelayAttack(){
        yield return new WaitForSeconds(delay);
        Destroy(cloneWeapon);
        IsCD = false;
    }
}
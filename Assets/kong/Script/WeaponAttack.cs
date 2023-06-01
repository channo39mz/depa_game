using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponAttack : MonoBehaviour
{
    [SerializeField] private GameObject weapon;
    [SerializeField] private Mana playerMana;
    [SerializeField] public GameObject playerWeapon;
    private float delay;
    private GameObject cloneWeapon;
    private bool IsCD;
    void Start(){
        IsCD = false;
        delay = weapon.GetComponent<Weapon>().cooldown;
    }
    void Update(){
        if(Input.GetMouseButtonDown(0)){
            OnAttack();
        }
    }
    public void Add(GameObject getWeapon){
        weapon = getWeapon;
        delay = weapon.GetComponent<Weapon>().cooldown;
    }
    //Press Left mouse button
    public void OnAttack(){
        if(!IsCD){
            cloneWeapon = Instantiate(weapon,playerWeapon.transform.position,playerWeapon.transform.rotation);
            cloneWeapon.transform.SetParent(playerWeapon.transform);
            cloneWeapon.GetComponent<Weapon>().playerMana = playerMana;
            cloneWeapon.GetComponent<Weapon>().OnAttack();

            cloneWeapon.GetComponent<AudioSource>().Play();
            StartCoroutine(DelayAttack());
        }
        IsCD = true;
    }

    public GameObject GetCurrentWeapon(){
        return weapon;
    }

    private IEnumerator DelayAttack(){
        yield return new WaitForSeconds(delay);
        Destroy(cloneWeapon);
        IsCD = false;
    }
}
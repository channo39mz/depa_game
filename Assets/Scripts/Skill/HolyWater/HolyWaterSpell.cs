using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyWaterSpell : MonoBehaviour
{
    private float damage;
    void Awake(){
        damage = GetComponentInParent<HolyWater>().damageSkill;
    }
    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag == "Enemy"){
            collider.GetComponent<Health>().decreaseHP(damage);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderSpell : MonoBehaviour
{
    private float damage;
    public Thunder thunder;
    void Start(){
        damage = thunder.damageSkill;
    }
    private void OnTriggerEnter2D(Collider2D collider){
        if(collider.tag == "Enemy"){
            collider.GetComponent<Health>().decreaseHP(damage);
        }
    }
}

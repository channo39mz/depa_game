using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomEffect : MonoBehaviour
{
    public float damageSkill;
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Enemy"){
            collision.GetComponent<Health>().decreaseHP(damageSkill);
        }
    }
}

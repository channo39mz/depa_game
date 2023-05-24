using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxHP;
    public float curHP;
    public float mana;
    public float speed;
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        curHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(!hpIsZero() && collision.gameObject.tag == "Enemy"){
            takedamage(collision);
        }
    }

    private bool hpIsZero(){
        if(curHP <= 0) return true;
        return false;
    }

    private void takedamage(Collision2D collision){
        if(collision.gameObject.TryGetComponent<Enemy>(out Enemy enemyComponent)){
            curHP -= enemyComponent.damage;
        }
    }
}

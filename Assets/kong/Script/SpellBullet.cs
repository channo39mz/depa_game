using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBullet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float damageSkill;
    public float castRange;
    private float Distance;
    private Vector2 firstPos;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        firstPos = new Vector2(transform.position.x,transform.position.y);
    }

    void FixedUpdate(){
        rb.velocity = transform.up * 3;
        DestroyByDistants();
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Enemy"){
            collision.gameObject.GetComponentInParent<Health>().decreaseHP(damageSkill);
            Destroy(gameObject);
        }
    }

    private void DestroyByDistants(){
        Distance = Vector2.Distance(firstPos, this.transform.position) * 2;
        if (Distance > castRange){
            Destroy(gameObject);
        }
    }
}

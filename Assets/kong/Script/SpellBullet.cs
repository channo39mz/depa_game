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
    public GameObject child;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        firstPos = new Vector2(transform.position.x,transform.position.y);
        // child = this.transform.GetChild(0).gameObject;
    }

    void FixedUpdate(){
        rb.velocity = transform.up * 3;
        // DestroyByDistants();
        // child.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Wall"){
            var newChild = Instantiate(child,this.transform.position,this.transform.rotation);
            newChild.GetComponent<BoomEffect>().damageSkill = damageSkill;
            newChild.SetActive(true);
            Destroy(gameObject);
            Destroy(newChild,0.25f);
        }
    }

    private void DestroyByDistants(){
        Distance = Vector2.Distance(firstPos, this.transform.position) * 2;
        if (Distance > castRange){
            Destroy(gameObject);
        }
    }
}

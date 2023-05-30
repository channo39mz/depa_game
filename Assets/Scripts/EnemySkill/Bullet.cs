using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;


public class Bullet : MonoBehaviour
{   
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private bool hitPlayer = true;
    [SerializeField] private bool hitEnemy = true;
    [HideInInspector] public float damage;


    private void Update()
    {
        Destroy(gameObject, 2f);
    }
    private IEnumerator CoolDown(float times , playerMove py)
    {
        py.SetSpeed(0f);
        yield return new WaitForSeconds(times);
        py.SetSpeed(2f);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" && hitPlayer)
        {
            Hit(other);

        }
        else if (other.tag == "Enemy" && hitEnemy)
        {
            Hit(other);
        }
    }

    private void Hit(Collider2D other)
    {
        playerMove py = other.GetComponent<playerMove>();
        //py.setspeed(0f);
        StartCoroutine(CoolDown(1 , py));
        Debug.Log("stop");
        
        DamageManager manager = other.gameObject.GetComponent<DamageManager>();
        manager.TakeDamage(damage);
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        GetComponent<SpriteRenderer>().enabled = false;
    }

   
}

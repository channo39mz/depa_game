using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class boomdamage : MonoBehaviour
{
    private Health hp;
    // Start is called before the first frame update
    void Start()
    {
        hp = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    async void AttackCoolDown(int times)
    {
        await Task.Delay(times);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            collision.GetComponent<Health>().decreaseHP(0.5f);
            AttackCoolDown(2000);
            Debug.Log("boom");
        }
        
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public Health PlayerHP;
    [SerializeField] private float delay;
    private bool IFrame;
    
    void Start()
    {
        delay = 0.5f;
        IFrame = false;
    }

    private void OnCollisionStay2D(Collision2D hitObject){
        if(hitObject.gameObject.tag == "Enemy" && !IFrame){
            PlayerHP.decreaseHP(2);
            StartCoroutine(DelayDamageTaken());
        }
        IFrame = true;
    }

    private IEnumerator DelayDamageTaken(){
        yield return new WaitForSeconds(delay);
        IFrame = false;
    }
}

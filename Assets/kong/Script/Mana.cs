using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    [SerializeField] private float MaxMana;
    public float curMana { get; private set; }
    public float manaRegenAmount;
    private float delay;
    private bool IsCD;
    void Start()
    {
        curMana = MaxMana;
        delay = 1;
        IsCD = false;
    }

    void Update(){
        ManaRegen();
    }

    private void ManaRegen(){
        if(curMana < MaxMana){
            if(!IsCD){
                curMana += manaRegenAmount;
                StartCoroutine(DelayManaRegen());
            }
            IsCD = true;
        }
    }
    public void ManaRegenOnHit(float amount){
        if(amount + curMana < MaxMana){
            curMana += amount;
        }
        else if(amount + curMana > MaxMana){
            curMana = MaxMana;
        }
    }
    public void decreaseMana(float cost){
        if(!IsOutOfMana(cost)){
            curMana -= cost;
        }
    }

    public bool IsOutOfMana(float cost){
        if(curMana - cost < 0){
            
            return true;
        }
        else return false;
    }
    public float GetMaxMana(){
        return MaxMana;
    }
    private IEnumerator DelayManaRegen(){
        yield return new WaitForSeconds(delay);
        IsCD = false;
    }
}
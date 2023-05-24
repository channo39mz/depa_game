using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoins : MonoBehaviour
{
    public float coin {get;private set;}

    public void CoinIncrease(float amount){
        coin += amount;
    }

    public void CoinDecrease(float amount){
        if(CanPaid(amount)){
            coin -= amount;
        }
    }

    public bool CanPaid(float amount){
        if(coin > amount) return true;
        else return false;
    }
}

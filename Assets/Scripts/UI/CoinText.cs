using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinText : MonoBehaviour
{
    private TMP_Text coinText;
    [SerializeField] PlayerCoins playerCoins;

    void Start(){
        coinText = GetComponent<TMP_Text>();
    }

    void Update(){
        coinText.text = string.Format("Coins : {0}",playerCoins.coin);
    }
}

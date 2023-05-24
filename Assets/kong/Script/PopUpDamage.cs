using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpDamage : MonoBehaviour
{
    [SerializeField] private GameObject floatingDamage;
    public void ShowDamage(string amount){
        if(floatingDamage){
            GameObject prefab = Instantiate(floatingDamage,this.transform.position,Quaternion.identity);
            prefab.GetComponentInChildren<TextMesh>().text = amount;
        }
    }
    
}

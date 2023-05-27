using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackButton : MonoBehaviour
{   
    [SerializeField] private GameObject BackpackObject;
    public void OpenInventory(){
        if(!BackpackObject.activeSelf){
            BackpackObject.SetActive(true);
        }
        else{
            BackpackObject.SetActive(false);
        }
    }

    public void pressTab(){
        if(!BackpackObject.activeSelf){
            BackpackObject.SetActive(true);
        }
        else{
            BackpackObject.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackpackButton : MonoBehaviour
{   
    [SerializeField] Image inventoryImage;
    [SerializeField] GameObject itemSlots;
    public void OpenInventory(){
        if(!inventoryImage.enabled){
            inventoryImage.GetComponent<Image>().enabled = true;
            itemSlots.SetActive(true);
        }
        else{
            inventoryImage.GetComponent<Image>().enabled = false;
            itemSlots.SetActive(false);
        }
    }

    public void pressTab(){
        if(!inventoryImage.enabled){
            inventoryImage.GetComponent<Image>().enabled = true;
            itemSlots.SetActive(true);
        }
        else{
            inventoryImage.GetComponent<Image>().enabled = false;
            itemSlots.SetActive(false);
        }
    }
}

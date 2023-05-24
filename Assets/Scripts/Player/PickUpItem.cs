using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    private Item curItem;
    private void OnTriggerEnter2D(Collider2D collision){
        curItem = collision.GetComponent<Item>();
        if(collision.tag == "Item"){
            inventory.AddItems(curItem);
            if(curItem != null){
                curItem.transform.SetParent(inventory.transform.GetChild(1).transform);
                curItem.gameObject.SetActive(false);
            }
        }
        else if(collision.tag == "Coin"){
            GetComponent<PlayerCoins>().CoinIncrease(1);
            Destroy(collision.gameObject);
        }
    }
}
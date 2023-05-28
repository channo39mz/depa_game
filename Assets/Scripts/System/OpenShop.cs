using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenShop : MonoBehaviour
{
    private bool hasCustomer = false;
    private bool windowActive = false;

    private void Update() {
        GameObject windowShop = GetComponentInParent<ShopManager>().Canvas.gameObject;
        if (hasCustomer && Input.GetKeyDown(KeyCode.F))
        {
            if (!windowActive)
            {
                windowShop.SetActive(true);
                windowActive = true;
                Debug.Log("Open Shop");
            }
            else
            {
                windowShop.SetActive(false);
                windowActive = false;
            }
        }
        else if (!hasCustomer)
        {
            windowShop.SetActive(false);
            windowActive = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            hasCustomer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player")
        {
            hasCustomer = false;
        }
    }
}

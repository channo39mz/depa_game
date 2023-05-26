using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomSell : MonoBehaviour
{
    //public GameObject[] listIsell;
    public GameObject sellwindow;
    public Button[] sellitem;
    public Sprite[] image;
    private bool hasCustomer = false;
    private bool windowActive = false;

    public void Start()
    {
        NewOrder();
    }

    private void NewOrder()
    {
        List<int> random = Choose(image.Length, sellitem.Length);
        for (int i = 0; i < sellitem.Length; i++)
        {
            // sellitem[i].image.sprite = image[random[i]];
        }
    }

    private List<int> Choose(int n, int c)
    {
        List<int> order = new List<int>();
        for (int i = 0; i < n; i++)
        {
            order.Add(i);
        }
        List<int> random = new List<int>();
        for (int i = n; i >= (n + 1) - c; i--)
        {
            int choose = Random.Range(0, i);
            random.Add(order[choose]);
            order.RemoveAt(choose);
        }
        return random;
    }

    private void Update() {
        if (hasCustomer && Input.GetKeyDown(KeyCode.F))
        {
            if (!windowActive)
            {
                sellwindow.SetActive(true);
                windowActive = true;
                Debug.Log("IsellU");
            }
            else
            {
                sellwindow.SetActive(false);
                windowActive = false;
            }
        }
        else if (!hasCustomer)
        {
            sellwindow.SetActive(false);
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

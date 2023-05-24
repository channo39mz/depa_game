using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class randomsell : MonoBehaviour
{
    //public GameObject[] listIsell;
    public GameObject player;
    public GameObject sellwindow;
    public Button[] sellitem;
    public Sprite[] image;
    public void Start()
    {
        sellitem[0].image.sprite = image[Random.Range(0, 6)];
        sellitem[1].image.sprite = image[Random.Range(0, 6)];
        sellitem[2].image.sprite = image[Random.Range(0, 6)];
    }
    public void Update()
    {
        if (Mathf.Abs(player.transform.position.x - gameObject.transform.position.x) < 5 &&
            Mathf.Abs(player.transform.position.y - gameObject.transform.position.y) < 5)
        {
            if (Input.GetKey(KeyCode.F))
            {
                sellwindow.SetActive(true);
                Debug.Log("IsellU");
            }
            
        }
    }
   
}

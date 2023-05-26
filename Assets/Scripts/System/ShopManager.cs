using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private GameObject shop;
    [SerializeField] private Button[] buttons = new Button[3];
    [SerializeField] private Ingredients ingredients;

    private void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].image.sprite = shop.GetComponent<Shop>().Order[i].image;
        }
    }

    public void Buy()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        // ingredients = player.GetComponent<>().Ingredients;
        GameObject buttonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        Skill skill = shop.GetComponent<Shop>().BuySkill(buttonRef.GetComponent<ButtonInfo>().Id, ingredients);
        Debug.Log(skill);
        // player.GetComponent<>().Add(skill);
    }
}

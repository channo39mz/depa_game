using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopManager : MonoBehaviour
{
    public Canvas Canvas { get; private set; }
    [SerializeField] private Shop shop;

    private void Start()
    {
        shop.NewOrder(3);
        Canvas = GetComponentInChildren<Canvas>();
        Button[] buttons = Canvas.GetComponentsInChildren<Button>();
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].image.sprite = shop.Order[i].image;
        }
    }

    public void Buy()
    {
        Inventory inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        Ingredients ingredients = inventory.playerIngredients;
        GameObject buttonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        Skill skill = shop.BuySkill(buttonRef.GetComponent<ButtonInfo>().Id, ingredients);
        Debug.Log(skill);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (skill != null)
        {
            if (skill.tag == "Skill")
            {
                player.GetComponent<PlayerSkillCast>().Add(skill.gameObject);
            }
            else if (skill.tag == "Weapon")
            {
                // player.GetComponent<WeaponAttack>()
            }
        }
    }
}

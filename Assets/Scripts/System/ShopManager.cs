using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public Canvas Canvas { get; private set; }
    [SerializeField] private Shop shop;

    private void Start()
    {
        shop.NewOrder(3);
        Canvas = GetComponentInChildren<Canvas>();
        Button[] buttons = Canvas.GetComponentsInChildren<Button>();
        for (int i = 0; i < buttons.Length; i+=2)
        {
            int shopOrder = i/2;
            
            buttons[i].gameObject.GetComponentsInChildren<Image>()[1].sprite = shop.Order[shopOrder].image;
            
            TMP_Text coinText = buttons[i].gameObject.GetComponentsInChildren<Image>()[2].GetComponentInChildren<TMP_Text>();
            coinText.text = string.Format("X {0}",shop.Order[shopOrder].Ingredients.getCoin());
            //Skill info 1
            if(shop.Order[shopOrder].Ingredients.getListItems()[0] != null){
                buttons[i].gameObject.GetComponentsInChildren<Image>()[3].enabled = true;

                TMP_Text ingredientsCount1 = buttons[i].gameObject.GetComponentsInChildren<Image>()[3].GetComponentInChildren<TMP_Text>();

                buttons[i].gameObject.GetComponentsInChildren<Image>()[3].sprite = shop.Order[shopOrder].Ingredients.getListItems()[0].Item.image;
                ingredientsCount1.text = string.Format("X {0}",shop.Order[shopOrder].Ingredients.getListItems()[0].Quantity);
            }
            else{
                buttons[i].gameObject.GetComponentsInChildren<Image>()[3].enabled = false;
            }

            //Skill info 2
            if(shop.Order[shopOrder].Ingredients.getListItems()[1] != null){
                buttons[i].gameObject.GetComponentsInChildren<Image>()[4].enabled = true;

                TMP_Text ingredientsCount1 = buttons[i].gameObject.GetComponentsInChildren<Image>()[4].GetComponentInChildren<TMP_Text>();

                buttons[i].gameObject.GetComponentsInChildren<Image>()[4].sprite = shop.Order[shopOrder].Ingredients.getListItems()[1].Item.image;
                ingredientsCount1.text = string.Format("X {0}",shop.Order[shopOrder].Ingredients.getListItems()[1].Quantity);
            }
            else{
                buttons[i].gameObject.GetComponentsInChildren<Image>()[4].enabled = false;
            }

            //Info Skill
            if(shop.Order[shopOrder].imageInfo != null){
                buttons[i].gameObject.GetComponentsInChildren<Image>()[5].sprite = shop.Order[shopOrder].imageInfo;
            }
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
                player.GetComponent<WeaponAttack>().Add(skill.gameObject);
            }
        }
    }
}

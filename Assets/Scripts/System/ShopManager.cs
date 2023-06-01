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
    [SerializeField] private Button[] buttons;
    private void Start()
    {
        shop.NewOrder(3);
        Canvas = GetComponentInChildren<Canvas>();
        // Button[] buttons = Canvas.GetComponentsInChildren<Button>();
        for (int i = 0; i < buttons.Length; i++)
        {
            // int shopOrder = i/2;
            CraftingSkill skill = shop.Order[i];
            Image icon = buttons[i].gameObject.GetComponentsInChildren<Image>()[1];
            TMP_Text coinText = buttons[i].gameObject.GetComponentsInChildren<Image>()[2].GetComponentInChildren<TMP_Text>();
            Image ingredient1 = buttons[i].gameObject.GetComponentsInChildren<Image>()[3];
            Image ingredient2 = buttons[i].gameObject.GetComponentsInChildren<Image>()[4];
            Image skillInfo =  buttons[i].gameObject.GetComponentsInChildren<Image>()[5];
            Debug.Log(skillInfo.gameObject);

            icon.sprite = shop.Order[i].image;
            
            coinText.text = string.Format("X {0}",skill.Ingredients.getCoin());
            //Skill info 1
            if(skill.Ingredients.getListItems()[0] != null){
                ingredient1.enabled = true;

                TMP_Text ingredientsCount1 = ingredient1.GetComponentInChildren<TMP_Text>();

                ingredient1.sprite = shop.Order[i].Ingredients.getListItems()[0].Item.image;
                ingredientsCount1.text = string.Format("X {0}",skill.Ingredients.getListItems()[0].Quantity);
            }
            else{
                ingredient1.enabled = false;
            }

            //Skill info 2
            if(skill.Ingredients.getListItems()[1] != null){
                ingredient2.enabled = true;

                TMP_Text ingredientsCount2 = ingredient2.GetComponentInChildren<TMP_Text>();

                ingredient2.sprite = shop.Order[i].Ingredients.getListItems()[1].Item.image;
                ingredientsCount2.text = string.Format("X {0}",skill.Ingredients.getListItems()[1].Quantity);
            }
            else{
                ingredient2.enabled = false;
            }

            //Info Skill
            if(shop.Order[i].imageInfo != null){
                skillInfo.sprite = skill.imageInfo;
            }
            skillInfo.gameObject.SetActive(false);
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

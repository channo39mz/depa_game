using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Thunder : CraftingSkill
{
    public float damageSkill;
    public float castRange;
    public float ManaCost;
    private Canvas canvas;
    Vector2 mousePos;
    Camera cam;
    public GameObject thunderSprite;
    public Mana playerMana;
    void Start(){
        canvas = this.transform.GetChild(0).GetComponent<Canvas>();
    }
    void Update(){
        cam = Camera.main;
        
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        canvas.transform.position = new Vector2(mousePos.x,mousePos.y);       

        if(Input.GetMouseButtonDown(1)){
            thunderSprite.transform.position = canvas.gameObject.transform.position;
            thunderSprite.gameObject.SetActive(true);
            thunderSprite.GetComponent<Animator>().SetTrigger("Trigger");
            canvas.gameObject.SetActive(false);
            playerMana.decreaseMana(ManaCost);
            Destroy(this.gameObject,0.5f);
        }

        if(Input.GetKeyDown(KeyCode.Q)){
            Destroy(this.gameObject);
        }
    }
}

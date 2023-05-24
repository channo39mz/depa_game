using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Thunder : MonoBehaviour
{
    public float damageSkill;
    public float castRange;
    public float manaCost;
    private Canvas canvas;
    Vector2 mousePos;
    Camera cam;
    public GameObject thunderSprite;
    void Start(){
        canvas = this.transform.GetChild(0).GetComponent<Canvas>();
    }
    void Update(){
        cam = Camera.main;
        
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        canvas.transform.position = new Vector2(mousePos.x,mousePos.y);       

        if(Input.GetMouseButtonDown(1)){
            thunderSprite.gameObject.SetActive(true);
            Destroy(this.gameObject,0.25f);
        }
    }
}

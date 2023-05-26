using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyWater : MonoBehaviour
{
    public float damageSkill;
    public float ManaCost;
    public Mana playerMana;
    public GameObject horyWaterSprite;
    void Update(){
        // mousePosition = Input.mousePosition;

        // angle = getMouseAngle();
        // this.transform.eulerAngles = new Vector3(0,0,angle);

        if(Input.GetMouseButtonDown(1)){
            horyWaterSprite.gameObject.SetActive(true);
            playerMana.decreaseMana(ManaCost);
            Destroy(this.gameObject,0.25f);
        }

        if(Input.GetKeyDown(KeyCode.Q)){
            Destroy(this.gameObject);
        }
    }
}

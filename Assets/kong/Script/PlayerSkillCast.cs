using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerSkillCast : MonoBehaviour
{
    [SerializeField] private GameObject[] SkillSlot;
    [SerializeField] private TMP_Text SkillText;
    [SerializeField] private GameObject SkillAim;
    public GameObject player;
    private Mana playerMana;
    private GameObject curSkill;
    private int state = 0;
    GameObject newSkill;
    void Start(){
        curSkill = SkillSlot[state];
        playerMana = player.GetComponent<Mana>();
    }
    void Update(){
        curSkill = SkillSlot[state];
        SkillText.text = state.ToString();
        if(Input.GetMouseButtonDown(1)){
            PressRightMouse();
        }
    }

    public void Add(GameObject skill){
        SkillSlot[state] = skill;
    }
    public void PressE(InputAction.CallbackContext context){
        if(context.phase == InputActionPhase.Performed && SkillSlot.Length == 3 && curSkill){
            if(curSkill.name == "HealInstance"){
                if(!playerMana.IsOutOfMana(curSkill.GetComponent<HealInstance>().ManaCost)){
                    curSkill.GetComponent<HealInstance>().Activate(player);
                }
            }
            else if(curSkill.name == "Thunder"){
                if(!playerMana.IsOutOfMana(curSkill.GetComponent<Thunder>().ManaCost) && newSkill == null){
                    newSkill = Instantiate(curSkill, new Vector3(0,0,0), SkillAim.transform.rotation);
                    newSkill.transform.localPosition = SkillAim.transform.position;
                    newSkill.GetComponent<Thunder>().playerMana = player.GetComponent<Mana>(); 
                }
            }
            else if(curSkill.name == "HolyWater"){
                if(!playerMana.IsOutOfMana(curSkill.GetComponent<HolyWater>().ManaCost) && newSkill == null){
                    newSkill = Instantiate(curSkill, SkillAim.transform.position, SkillAim.transform.rotation);
                    newSkill.transform.SetParent(SkillAim.transform);
                    newSkill.GetComponent<HolyWater>().playerMana = player.GetComponent<Mana>();
                }
            }
        }
    }

    private void PressRightMouse(){
        if(curSkill.name == "FireBall"){
            if(!playerMana.IsOutOfMana(curSkill.GetComponent<FireBall>().ManaCost)){
                curSkill.GetComponent<FireBall>().Activate(player,SkillAim.transform);
            }
        }
    }

    public void PressQ(InputAction.CallbackContext context){
        if(context.phase == InputActionPhase.Performed && SkillSlot.Length == 3){
            state = (state + 1) % 3;
            Debug.Log(state);
            curSkill = SkillSlot[state];
        }
    }
}

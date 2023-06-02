using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerSkillCast : MonoBehaviour
{
    [SerializeField] private GameObject[] SkillSlot;
    [SerializeField] private GameObject SkillAim;
    [SerializeField] private SkillSlot UISkillSlots;
    public GameObject player;
    private Mana playerMana;
    private GameObject curSkill;
    private int state = 0;
    private bool isDelay;
    GameObject newSkill;
    void Start(){
        curSkill = SkillSlot[state];
        playerMana = player.GetComponent<Mana>();
        isDelay = false;
    }
    void Update(){
        curSkill = SkillSlot[state];
        // SkillText.text = state.ToString();
        if(Input.GetMouseButtonDown(1)){
            PressRightMouse();
        }
    }

    public void Add(GameObject skill){
        SkillSlot[state] = skill;
        UISkillSlots.RefreshSlots(state);
    }
    public void PressE(InputAction.CallbackContext context){
        if(context.phase == InputActionPhase.Performed && SkillSlot.Length == 3 && curSkill){
            if(curSkill.name == "Thunder"){
                if(!playerMana.IsOutOfMana(curSkill.GetComponent<Thunder>().ManaCost) && newSkill == null){
                    newSkill = Instantiate(curSkill, new Vector3(0,0,0), new Quaternion(0,0,0,0));
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
        else if(curSkill.name == "HealInstance"){
            if(!playerMana.IsOutOfMana(curSkill.GetComponent<HealInstance>().ManaCost)){
                curSkill.GetComponent<HealInstance>().Activate(player);
            }
        }
    }

    public void PressQ(InputAction.CallbackContext context){
        if(context.phase == InputActionPhase.Performed && SkillSlot.Length == 3){
            if(!isDelay){
                state = (state + 1) % 3;
                UISkillSlots.RunAnimation();
                StartCoroutine(DelaySwap(0.25f));
                // UISkillSlots.RefreshSlots(state);
                // curSkill = SkillSlot[state];
            }
            isDelay = true;
        }
    }

    public GameObject[] getSkill(){
        return SkillSlot;
    }

    private IEnumerator DelaySwap(float delay){
        yield return new WaitForSeconds(delay);
        UISkillSlots.RefreshSlots(state);
        curSkill = SkillSlot[state];
        isDelay = false;
    }
}

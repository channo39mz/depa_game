using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSlot : MonoBehaviour
{
    [SerializeField] PlayerSkillCast playerCast;
    [SerializeField] GameObject[] Skillslots;
    [SerializeField] GameObject specialSlot;
    [SerializeField] Animator skillSlotsAnimation;
    void Awake(){
        playerCast = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerSkillCast>();
        RefreshSlots(0);
    }
    public void RunAnimation(){
        skillSlotsAnimation.SetTrigger("Swap");
    }
    public void RefreshSlots(float state){
        GameObject[] playerSkill = playerCast.getSkill();
        if(playerSkill[(int) state] != null){
            specialSlot.SetActive(true);
            specialSlot.GetComponent<Image>().sprite = playerSkill[(int) state].GetComponent<CraftingSkill>().image;
        }
        else{
            specialSlot.SetActive(false);
            specialSlot.GetComponent<Image>().sprite = null;
        }
        for(int i = 0;i < 3;i++){
            if(playerSkill[(i + (int) state) % 3] != null){
                Skillslots[i].GetComponent<Image>().enabled = true;
                Skillslots[i].GetComponent<Image>().sprite = playerSkill[(i + (int) state) % 3].GetComponent<CraftingSkill>().image;
            }
            else{
                Skillslots[i].GetComponent<Image>().enabled = false;
                Skillslots[i].GetComponent<Image>().sprite = null;
            }
        }
    }
}

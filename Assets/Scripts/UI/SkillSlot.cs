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

    void Update(){
    }

    public void RunAnimation(){
        skillSlotsAnimation.SetTrigger("Swap");
    }
    public void RefreshSlots(float state){
        GameObject[] playerSkill = playerCast.getSkill();
        specialSlot.GetComponent<Image>().sprite = playerSkill[(int) state].GetComponent<CraftingSkill>().image;
        for(int i = 0;i < 3;i++){
            Skillslots[i].GetComponent<Image>().sprite = playerSkill[(i + (int) state) % 3].GetComponent<CraftingSkill>().image;
        }
    }
}

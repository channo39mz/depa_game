using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CastSkill : MonoBehaviour
{
    
    [SerializeField] private Skill curSkill;
    [SerializeField] private Skill[] SkillSlot;
    private Mana manaPlayer;
    private Transform shootingPoint;
    private GameObject spellObject;
    private float damage;
    private float manaCost;
    private float castRange;
    void Awake()
    {
        //About Spell
        spellObject = curSkill.GetSpell();
        damage = curSkill.damage;
        manaCost = curSkill.manaCost;
        castRange = curSkill.castRange;

        //Get this transform to prepare casting skill
        shootingPoint = this.transform;

        //Get player mana
        manaPlayer = GetComponentInParent<Mana>();
        
        //Set bullet spell to have damage and castRange
        SpellBullet spellObjectComponent = spellObject.GetComponent<SpellBullet>();
        spellObjectComponent.damageSkill = damage;
        spellObjectComponent.castRange = castRange;
    }
    
    //If press Q bullet spell will be cast
    public void OnCasting(InputAction.CallbackContext context){
        if(context.phase == InputActionPhase.Performed){
            if(!manaPlayer.IsOutOfMana(manaCost)){
                Instantiate(spellObject, shootingPoint.position, transform.rotation);
                manaPlayer.decreaseMana(manaCost);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CastSkill : MonoBehaviour
{
    
    [SerializeField] private Skill curSkill;
    private Transform shootingPoint;
    private GameObject spell;
    private int damage;
    void Awake()
    {
        spell = curSkill.spell;
        damage = curSkill.damage;
        shootingPoint = this.transform;
    }

    
    void Update(){
        
    }

    private void FixedUpdate(){
        
    }

    public void OnCasting(InputAction.CallbackContext context){
        switch(context.phase){
            case InputActionPhase.Performed:
                Instantiate(spell, shootingPoint.position, transform.rotation);
                break;
        }
    }
}

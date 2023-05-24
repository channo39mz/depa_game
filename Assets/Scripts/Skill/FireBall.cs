using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float damage;
    public float ManaCost;
    public float castRange;

    [SerializeField] private GameObject spellObject;
    void Start(){
        SpellBullet bulletProperty = spellObject.GetComponent<SpellBullet>();
        bulletProperty.damageSkill = damage;
        bulletProperty.castRange = castRange;
    }
    public void Activate(GameObject Player,Transform shootingPoint){
        Mana playerMana = Player.GetComponent<Mana>();
        Instantiate(spellObject, shootingPoint.position, shootingPoint.rotation);
        playerMana.decreaseMana(ManaCost);
    }
}

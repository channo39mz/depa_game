using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : CraftingSkill
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
        var newBullet = Instantiate(spellObject, new Vector3(shootingPoint.position.x,shootingPoint.position.y,0), shootingPoint.rotation);
        newBullet.GetComponent<SpellBullet>().damageSkill = damage;
        // newBullet.transform.rotation = new Vector3(0,0,90);
        playerMana.decreaseMana(ManaCost);
    }
}

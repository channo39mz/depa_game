using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealInstance : MonoBehaviour
{
    public float Amount;
    public float ManaCost;
    public void Activate(GameObject Player){
        Health playerHealth = Player.GetComponent<Health>();
        Mana playerMana = Player.GetComponent<Mana>();
        playerHealth.Heal(Amount);
        playerMana.decreaseMana(ManaCost);
    }
}

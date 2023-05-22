using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public float damage;
    public float castRange;
    public float manaCost;
    private GameObject spell;
    void Start(){
        spell = GetComponent<GameObject>();
    }

    public GameObject GetSpell(){
        return spell;
    }
}

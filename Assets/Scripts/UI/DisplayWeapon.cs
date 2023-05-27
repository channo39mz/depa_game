using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayWeapon : MonoBehaviour
{
    private GameObject player;
    private GameObject playerWeapon;

    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
        playerWeapon = player.GetComponent<WeaponAttack>().GetCurrentWeapon();
    }
    void Update(){
        Image thisImage = GetComponent<Image>();
        thisImage.sprite = playerWeapon.GetComponent<SpriteRenderer>().sprite;
    }
}

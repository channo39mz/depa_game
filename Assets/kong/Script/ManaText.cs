using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaText : MonoBehaviour
{
    [SerializeField] private Mana manaPlayer;
    [SerializeField] private Text thisTextMana;
    void Update()
    {
        thisTextMana.text = manaPlayer.curMana.ToString();
    }
}

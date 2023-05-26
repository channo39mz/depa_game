using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicMana : MonoBehaviour
{
    public Mana manaPlayer;
    public Slider slide;
    // Start is called before the first frame update
    void Start()
    {
        slide.minValue = 0;
        slide.maxValue = manaPlayer.GetMaxMana();
    }

    // Update is called once per frame
    void Update()
    {
        slide.value = manaPlayer.curMana;
    }
}

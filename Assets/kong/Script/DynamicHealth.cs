using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicHealth : MonoBehaviour
{
    public Health hpPlayer;
    public Slider slide;
    // Start is called before the first frame update
    void Start()
    {
        slide.minValue = 0;
        slide.maxValue = hpPlayer.getMaxHP();
    }

    // Update is called once per frame
    void Update()
    {
        slide.value = hpPlayer.HP;
    }
}

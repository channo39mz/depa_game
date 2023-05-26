using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour
{
    public Health hpPlayer;
    public Text thisTextHP;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        thisTextHP.text = hpPlayer.HP.ToString();
    }
}

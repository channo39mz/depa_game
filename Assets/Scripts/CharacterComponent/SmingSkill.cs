using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SmingSkills
{
    public GameObject Buff;
    public GameObject Dash;
    public GameObject Roar;
    public GameObject Shooting;
    public GameObject Slash;
    
    public void Disable()
    {
        Dash.SetActive(false);
        Shooting.SetActive(false);
        Buff.SetActive(false);
        Roar.SetActive(false);
        Slash.SetActive(false);
    }
}

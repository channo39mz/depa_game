using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SmingSkills
{
    [SerializeField] private GameObject dash;
    public GameObject Dash { get => dash; }
    [SerializeField] private GameObject gun;
    public GameObject Gun { get => gun; }
    [SerializeField] private GameObject buff;
    public GameObject Buff { get => buff; }
    [SerializeField] private GameObject roar;
    public GameObject Roar { get => roar; }
    [SerializeField] private GameObject melee;
    public GameObject Melee { get => melee; }
    
    public void Disable()
    {
        Dash.SetActive(false);
        Gun.SetActive(false);
        Buff.SetActive(false);
        Roar.SetActive(false);
        Melee.SetActive(false);
    }
}

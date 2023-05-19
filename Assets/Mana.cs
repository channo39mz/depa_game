using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    [SerializeField] private int maxMana;
    public int mana { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        mana = maxMana;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

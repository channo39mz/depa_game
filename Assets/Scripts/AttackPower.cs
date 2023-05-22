using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPower : MonoBehaviour
{
    [SerializeField] private float atk = 1;
    public float Atk
    {   
        get => atk;
        private set => atk = value;
    }

    public void increaseAtk(float amount)
    {
        Atk += amount;
    }
}

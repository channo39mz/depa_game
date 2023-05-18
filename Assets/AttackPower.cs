using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPower : MonoBehaviour
{
    [SerializeField] private int atk = 1;
    public int Atk
    {   get => atk;
        private set => atk = value;
    }

    public void increaseAtk(int amount)
    {
        Atk += amount;
    }
}

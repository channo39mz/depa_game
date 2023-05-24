using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looting : MonoBehaviour
{
    [SerializeField] private DropRate[] dropRate;

    public void Drop()
    {
        int length = dropRate.Length;
        for (int i = 0; i < length; i++)
        {
            Item[] group = dropRate[i].Group;
            float rate = dropRate[i].Rate;
            int quantity = dropRate[i].Quantity;
            DropWithQuantity(group, rate, quantity);
        }
    }

    private void DropWithQuantity(Item[] group, float rate, int quantity)
    {
        for (int i = 0; i < quantity; i++)
        {
            DropWithRate(group, rate);
        }
    }

    private void DropWithRate(Item[] group, float rate)
    {
        bool isSuccess = Random.Range(0.0f, 1.0f) < rate;
        if (isSuccess)
        {
            DropWithGroup(group);
        }
    }

    private void DropWithGroup(Item[] group)
    {
        int random = Random.Range(0, group.Length);
        Instantiate(group[random], transform.position, Quaternion.identity);
    }
}

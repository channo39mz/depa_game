using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : SkillCD
{
    [SerializeField] private float time = 3;
    [SerializeField] private float atkIncrease = 5;
    [SerializeField] private float speedIncrease = 2;

    private void Update()
    {
        if (Ready)
        {
            StartBuff();
            Use();
        }
    }

    private void StartBuff()
    {
        StartCoroutine(BuffForSeconds(time));
    }

    private IEnumerator BuffForSeconds(float waittime)
    {
        AttackPower power = GetComponentInParent<AttackPower>();
        power.Atk += atkIncrease;
        Debug.Log(power.Atk);
        EnemyMovement movement = GetComponentInParent<EnemyMovement>();
        movement.Speed += speedIncrease;
        yield return new WaitForSeconds(waittime);
        power.Atk -= atkIncrease;
        Debug.Log(power.Atk);
        movement.Speed -= speedIncrease;
    }
}

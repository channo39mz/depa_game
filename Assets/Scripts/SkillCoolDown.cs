using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCoolDown : MonoBehaviour
{
    [SerializeField] private float maxCoolDown = 1;
    private float coolDown;
    public bool Ready { get; private set; } = true;

    private void Start()
    {
        coolDown = 0;
    }

    private void Update()
    {
        reduceCoolDown(Time.deltaTime);
    }

    public void reduceCoolDown(float time)
    {
        float tmpCD = coolDown;
        tmpCD -= time;
        if (tmpCD <= 0)
        {
            coolDown = 0;
            Ready = true;
        }
        else
        {
            coolDown = tmpCD;
            Ready = false;
        }
    }

    public void Use()
    {
        if (Ready) 
        {
            coolDown = maxCoolDown;
        }
    }
}

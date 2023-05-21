using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCD : MonoBehaviour
{
    [SerializeField] private float maxCD;
    private float CD;
    protected bool Ready { get; private set; } = true;

    private void Start()
    {
        CD = 0;
    }

    private void FixedUpdate()
    {
        reduceCD(Time.fixedDeltaTime);
    }

    public void reduceCD(float time)
    {
        float tmpCD = CD;
        tmpCD -= time;
        if (tmpCD <= 0)
        {
            CD = 0;
            Ready = true;
        }
        else
        {
            CD = tmpCD;
            Ready = false;
        }
    }

    public void Use()
    {
        if (Ready) 
        {
            CD = maxCD;
            Ready = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCoolDown : MonoBehaviour
{
    [SerializeField] private float AtkCD = 1;
    public float CD { get; private set; }
    public bool ready { get; private set; } = true;

    // Start is called before the first frame update
    void Start()
    {
        CD = 0;
    }

    // Update is called once per frame
    void Update()
    {
        reduceCoolDown(Time.deltaTime);
    }

    public void reduceCoolDown(float time)
    {
        float tmpCD = CD;
        tmpCD -= time;
        if (tmpCD <= 0)
        {
            CD = 0;
            ready = true;
        }
        else
        {
            CD = tmpCD;
            ready = false;
        }
    }

    public void DoAttack()
    {
        if (ready) 
        {
            CD = AtkCD;
            Debug.Log("Cooling Down");
        }
    }
}

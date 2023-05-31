using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotate : MonoBehaviour
{
    private PlayerAim mouseAngle;
    void Start(){
        mouseAngle = GetComponentInParent<PlayerAim>();
    }
    void Update()
    {
        if(transform.childCount == 0){
            transform.eulerAngles = new Vector3(0,0,mouseAngle.getMouseAngle());
        }
    }
}

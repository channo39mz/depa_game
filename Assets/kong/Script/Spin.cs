using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    private PlayerAim mouseAngle;
    void Start(){
        mouseAngle = GetComponentInParent<PlayerAim>();
    }
    void Update()
    {
        transform.eulerAngles = new Vector3(0,0,mouseAngle.getMouseAngle());
    }
}

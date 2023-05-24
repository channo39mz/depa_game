using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteInOneSec : MonoBehaviour
{
    private float DeleteTime = 1f;
    void Start()
    {
        Destroy(gameObject,DeleteTime);
    }
}

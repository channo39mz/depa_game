using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int moveSpeed = 1;

    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
    }
}

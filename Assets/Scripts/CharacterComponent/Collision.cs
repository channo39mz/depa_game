using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Enter");
    }

    private void OnCollisionExit2D(Collision2D other) {
        Debug.Log("Exit");
    }
}

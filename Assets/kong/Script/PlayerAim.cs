using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAim : MonoBehaviour
{
    [SerializeField] private InputActionReference mouse;
    private Vector3 mousePosition;
    void Update(){
        mousePosition = mouse.action.ReadValue<Vector2>();
    }
    public float getMouseAngle(){
        Vector3 mousePos = Input.mousePosition;
        mousePosition.z = Camera.main.nearClipPlane;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 aim = (worldPosition - transform.position).normalized;
        float angle = Mathf.Atan2(aim.y,aim.x) * Mathf.Rad2Deg;
        return angle - 90;
    }
}

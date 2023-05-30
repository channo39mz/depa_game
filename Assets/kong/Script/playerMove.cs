using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private InputActionReference move;
    [SerializeField] GameObject trail;
    [SerializeField] float dashSpeed;
    [SerializeField] float dashLength;
    private float dashCounter;
    private float activeMoveSpeed;
    void Start()
    {
        activeMoveSpeed = speed;
    }

    void Update(){
        // movementInput = move.action.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        Vector2 movementInput = move.action.ReadValue<Vector2>();
        Vector2 moveDirection = new Vector2(movementInput.x, movementInput.y).normalized;
        this.GetComponent<Animator>().SetFloat("Horizental",moveDirection.x);
        this.GetComponent<Animator>().SetFloat("Vertical",moveDirection.y);
        this.GetComponent<Animator>().SetFloat("Speed",moveDirection.sqrMagnitude);
        this.GetComponent<Rigidbody2D>().velocity = moveDirection * activeMoveSpeed;

        if(dashCounter > 0){
            trail.SetActive(true);
            dashCounter -= Time.deltaTime;
            if(dashCounter <= 0){
                trail.SetActive(false);
                activeMoveSpeed = speed;
            }
        }
    }
    public void dash(InputAction.CallbackContext context){
        if(context.phase == InputActionPhase.Performed){
            if(dashCounter <= 0){
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
            }
        }
    }

    public void SetSpeed(float speed)
    {
        activeMoveSpeed = speed;
        // dashSpeed = speed * 1.5f;
    }

    // private IEnumerator DashDelay(float time){
    //     yield return new WaitForSeconds(time);
    //     trail.enabled = false;
    //     dashCD = false;
    // }
}

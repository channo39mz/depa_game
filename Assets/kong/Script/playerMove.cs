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
    private Rigidbody2D rb;
    private Vector2 movementInput;
    private bool IsPressSpace;
    private Vector2 moveDirection;
    public Animator animator;
    
    private float dashCounter;
    
    private float activeMoveSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        activeMoveSpeed = speed;
    }

    void Update(){
        movementInput = move.action.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        moveDirection = new Vector2(movementInput.x, movementInput.y).normalized;
        animator.SetFloat("Horizental",moveDirection.x);
        animator.SetFloat("Vertical",moveDirection.y);
        animator.SetFloat("Speed",moveDirection.sqrMagnitude);
        rb.velocity = moveDirection * activeMoveSpeed;

        // if(Input.GetKeyDown(KeyCode.Space)){
        //     if(dashCounter <= 0){
        //         activeMoveSpeed = dashSpeed;
        //         dashCounter = dashLength;
        //     }
        //     // Vector2 dashPosition = moveDirection * speed;
        //     // trail.enabled = true;
        //     // rb.velocity = new Vector2(dashPosition.x * 10,dashPosition.y * 10);
        //     // StartCoroutine(DashDelay(0.1f));
        //     // // aycastHit2D rayCastHit = Physics2D.Raycast(transform.position,moveDirection,10,);
        //     // IsPressSpace = false;
        // }

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

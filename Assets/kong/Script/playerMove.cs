using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMove : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private InputActionReference move;
    private Rigidbody2D rb;
    private Vector2 movementInput;
    private bool IsPressSpace;
    private Vector2 moveDirection;
    public Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        rb.velocity = moveDirection * speed;

        if(IsPressSpace){
            Vector2 dashPosition = moveDirection * speed;
            rb.velocity = new Vector2(dashPosition.x * 10,dashPosition.y * 10);
            // RaycastHit2D rayCastHit = Physics2D.Raycast(transform.position,moveDirection,10,);
            IsPressSpace = false;
        }
    }
    public void dash(InputAction.CallbackContext context){
        if(context.phase == InputActionPhase.Performed){
            IsPressSpace = true;
        }
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}

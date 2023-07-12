using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player2DController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;
    private bool isCollidingWithBreakable;
    [SerializeField] private float moveSpeed = 10f;

    [SerializeField] private LayerMask whatIsBreakable;

    [SerializeField] private float interactRadius = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        UpdateAnimations();
        DetectBreakable();
    }

    private void FixedUpdate()
    {
        rb.velocity = moveInput * moveSpeed;
    }

    public void OnInteractInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Collider2D col = GetBreakable();
            if (col != null)
            {
                col.gameObject.GetComponent<IBreakable>().Damage();
            }
        }
    }
    
    public void OnMovementInput(InputAction.CallbackContext context )
    {
        moveInput = context.ReadValue<Vector2>();
        moveInput.Normalize();
    }

    private void UpdateAnimations()
    {
        animator.SetFloat("playerSpeed", rb.velocity.sqrMagnitude);
        animator.SetFloat("xInput", moveInput.x);
        animator.SetFloat("yInput", moveInput.y);

        if (moveInput.x == 1f || moveInput.x == -1f || moveInput.y == 1f || moveInput.y == -1f)
        {
            animator.SetFloat("lastXInput", moveInput.x);
            animator.SetFloat("lastYInput", moveInput.y);
        }
    }

    void DetectBreakable()
    {
        isCollidingWithBreakable = Physics2D.OverlapCircle(transform.position, interactRadius, whatIsBreakable);
    }

    Collider2D GetBreakable()
    {
        if (isCollidingWithBreakable) return Physics2D.OverlapCircle(transform.position, interactRadius, whatIsBreakable);
        return null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, interactRadius);
    }
}

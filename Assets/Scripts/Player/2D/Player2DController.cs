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
    [SerializeField] private float moveSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        UpdateAnimations();
    }

    private void FixedUpdate()
    {
        rb.velocity = moveInput * moveSpeed;
    }

    public void OnMovementInput(InputAction.CallbackContext context )
    {
        moveInput = context.ReadValue<Vector2>();
        Debug.Log(moveInput);
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
}

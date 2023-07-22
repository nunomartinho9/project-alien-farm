using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class Player2DController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;
    private bool isCollidingWithBreakable;
    private bool isCollidingWithInteractable;
    [SerializeField] private float moveSpeed = 10f;

    [SerializeField] private LayerMask whatIsBreakable;
    [SerializeField] private LayerMask whatIsInteractable;

    [SerializeField] private float interactRadius = 5f;
    [SerializeField] private Player2DInfo playerInfo;
    private CropManager cropManager;
    
    // Start is called before the first frame update
    void Start()    
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        cropManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<CropManager>();
    }

    private void Update()
    {
        UpdateAnimations();
        DetectBreakable();
        CheckInteractable();
    }

    private void FixedUpdate()
    {
        rb.velocity = moveInput * moveSpeed;
    }

    public void OnInteractInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Collider2D interactable = GetInteractable();
            if (interactable != null) // colliding intractable
            {
                Debug.Log("int no null");
                UpdatePlayerPosition();
                interactable.gameObject.GetComponent<IInteractable>().Interact();
            }
        }
    }
    
    public void OnUseInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Collider2D breakable = GetBreakable();
            if (breakable != null)
            {
                breakable.gameObject.GetComponent<IBreakable>().Damage();
            }

            UpdatePlayerPosition();
            if (cropManager.IsPlowable(playerInfo.Position))
            {
                cropManager.Plow(playerInfo.Position);
            }
            else if (cropManager.CheckIfPlowed(playerInfo.Position))
            {
                cropManager.Seed(playerInfo.Position);
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
    
    void CheckInteractable()
    {
        isCollidingWithInteractable = Physics2D.OverlapCircle(transform.position, interactRadius, whatIsInteractable);
    }

    Collider2D GetInteractable()
    {
        if (isCollidingWithInteractable) return Physics2D.OverlapCircle(transform.position, interactRadius, whatIsInteractable);
        return null;
    }

    private void UpdatePlayerPosition()
    {
        Vector3Int position = new Vector3Int((int)Mathf.Round(transform.position.x), (int)Mathf.Round(transform.position.y), 0);
        playerInfo.UpdatePlayerPosition(position);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, interactRadius);
    }
}

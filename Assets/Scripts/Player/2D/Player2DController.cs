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
    private bool isCollidingWithInteractable;
    [SerializeField] private float moveSpeed = 10f;

    [SerializeField] private LayerMask whatIsBreakable;
    [SerializeField] private LayerMask whatIsInteractable;

    [SerializeField] private float interactRadius = 5f;
    
    //para teste
    public TileManager _tileManager;
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
            Collider2D breakable = GetBreakable();
            Collider2D interactable = GetInteractable();
            if (breakable != null)
            {
                breakable.gameObject.GetComponent<IBreakable>().Damage();
            }
            if (interactable != null) // colliding intractable
            {
                interactable.gameObject.GetComponent<IInteractable>().Interact();
            }
            Vector3Int position = new Vector3Int((int)Mathf.Round(transform.position.x), (int)Mathf.Round(transform.position.y), 0);
            if (_tileManager.IsPlowable(position))
            {
                Debug.Log(Mathf.Round(transform.position.x) + ", "+ Mathf.Round(transform.position.y));
                Debug.Log(position);
                _tileManager.SetInteracted(position);
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

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, interactRadius);
    }
}

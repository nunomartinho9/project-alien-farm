using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(CharacterController))]
public class Player3DController : MonoBehaviour
{
    private CharacterController controller;
    private InputManager inputManager;
    private Transform cameraTransform;

    [SerializeField] private CinemachineVirtualCamera vcam;
    private Vector3 moveDirection;
    private Vector3 playerVelocity;

    [FormerlySerializedAs("horizontalRotationSpeed")]
    [Header("Movement")]
    [SerializeField] private float horizontalAimSpeed = 250.0f;
    [SerializeField] private float verticalAimSpeed = 100.0f;
    [SerializeField] private float walkSpeed = 15.0f;
    [SerializeField] private float sprintSpeed = 22.0f; 
    [SerializeField] private float gravityValue = -9.81f;
    private float playerSpeed;
    
    [Header("Jump")]
    [SerializeField] private float jumpCooldown = 5.0f;
    [SerializeField] private float jumpHeight = 7.0f;
    private bool readyJump;

    [Header("Ground Check")]
    private bool groundedPlayer;

    private MovementState state;
    private enum MovementState
    {
        walking,
        sprinting
    }
    
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        inputManager = InputManager.Instance;

        vcam.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_MaxSpeed = horizontalAimSpeed;
        vcam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_MaxSpeed = verticalAimSpeed;

        cameraTransform = Camera.main.transform;
        
        playerSpeed = walkSpeed;
        readyJump = true;
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        
        StateHandler();
        PlayerMovement();
        PlayerJump();
    }

    private void StateHandler()
    {
        // Sprinting
        if (groundedPlayer && inputManager.PlayerSprint())
        {
            state = MovementState.sprinting;
            playerSpeed = sprintSpeed;
        }
        
        // Walking
        else if (groundedPlayer)
        {
            state = MovementState.walking;
            playerSpeed = walkSpeed;
        }
    }
    
    private void PlayerMovement()
    {
        Vector2 input = inputManager.GetPlayerMovement();
        moveDirection = new Vector3(input.x, 0, input.y);
        moveDirection = cameraTransform.forward * moveDirection.z + cameraTransform.right * moveDirection.x;
        moveDirection.y = 0f;
        controller.Move(moveDirection * (Time.deltaTime * playerSpeed));

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    private void PlayerJump()
    {
        // Changes the height position of the player
        if (inputManager.PlayerJumped() && readyJump && groundedPlayer)
        {
            readyJump = false;
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void ResetJump()
    {
        readyJump = true;
    }
}
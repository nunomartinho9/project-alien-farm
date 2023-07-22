using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(CharacterController))]
public class Player3DController : MonoBehaviour
{
    private CharacterController controller;
    private InputManager inputManager;
    private Camera newCamera;
    
    private Vector3 moveDirection;
    private Vector3 playerVelocity;

    [Header("Movement")]
    [SerializeField] private float walkSpeed = 15f;
    [SerializeField] private float sprintSpeed = 22f; 
    [SerializeField] private float gravityValue = -9.81f;
    private float playerSpeed;

    [Header("Look")]
    [SerializeField] private float xSensivity = 30f;
    [SerializeField] private float ySensivity = 30f;
    private float xRotation = 0f;
    
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
        newCamera = Camera.main;
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
        PlayerLook();
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

    private void PlayerLook()
    {
        float mouseX = inputManager.GetMouseDelta().x;
        float mouseY = inputManager.GetMouseDelta().y;
        // calculate camera rotation
        xRotation -= (mouseY * Time.deltaTime) * ySensivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        // apply to camera transform
        newCamera.transform.localRotation = Quaternion.Euler(xRotation,0,0);
        // rotate player to look left and right
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime * xSensivity));
    }
    
    private void PlayerMovement()
    {
        Vector2 input = inputManager.GetPlayerMovement();
        moveDirection = new Vector3(input.x, 0, input.y);
        moveDirection = newCamera.transform.forward * moveDirection.z + newCamera.transform.right * moveDirection.x;
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
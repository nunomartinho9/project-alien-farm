using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class InputManager : MonoBehaviour
{
    private static InputManager _instance;

    public static InputManager Instance => _instance;

    private PlayerControls _playerControls;
    
    // Start is called before the first frame update
    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        _playerControls = new PlayerControls();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnEnable()
    {
        _playerControls.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }

    public Vector2 GetPlayerMovement()
    {
        return _playerControls.Player.Move.ReadValue<Vector2>();
    }
    
    public Vector2 GetMouseDelta()
    {
        return _playerControls.Player.Look.ReadValue<Vector2>();
    }

    public bool PlayerSprint()
    {
        return _playerControls.Player.Sprint.IsPressed();
    }
    
    public bool PlayerJumped()
    {
        return _playerControls.Player.Jump.triggered;
    }

    public bool PlayerShoot()
    {
        return _playerControls.Player.Shoot.triggered;
    }
    
    public bool PlayerPause()
    {
        return _playerControls.Player.Pause.triggered;
    }
}

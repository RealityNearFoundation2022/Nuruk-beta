using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Click : MonoBehaviour
{
    private PlayerInputs _playerInputs;

    private bool _isLock = false;
    private void Start()
    {
        _playerInputs = GetComponent<PlayerInputs>();
        _playerInputs.Player.LockMouse.performed += LockMouseOnperformed;
    }

    private void LockMouseOnperformed(InputAction.CallbackContext obj)
    {
        if (_isLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            _isLock = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            _isLock = true;
        }
    }
}

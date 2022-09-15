using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Click : MonoBehaviour
{
    private PlayerInputs _playerInputs;

    private ChatManager _chatManager;


    private float _timeChat;

    private bool _isLock = false;
    

    private void Start()
    {
        _chatManager = FindObjectOfType<ChatManager>();
    }

    private void Update()
    {
        // Open mouse
        if (Input.GetKey(KeyCode.Escape))
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
            if (_chatManager.openChat)
                _chatManager.ControlOpenChat();
        }

        // Open chat
        if (Input.GetKey(KeyCode.C) && Time.time > _timeChat && !_chatManager.openChat)
        {
            _chatManager.ControlOpenChat();
            _timeChat = Time.time + 1f;
        }
        
        // Send Message chat

        if (Input.GetKey(KeyCode.Return) && _chatManager.openChat)
        {
            _chatManager.SendMessage();
        }
    }
}


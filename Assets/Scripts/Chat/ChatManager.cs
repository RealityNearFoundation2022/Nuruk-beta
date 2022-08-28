using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChatManager : MonoBehaviour
{
    private bool _openChat = false;

    [SerializeField] private Animator _animatorChat;
    
    public void ControlOpenChat()
    {
        _animatorChat.SetBool("open", !_openChat);
        _openChat = !_openChat;
    }
}

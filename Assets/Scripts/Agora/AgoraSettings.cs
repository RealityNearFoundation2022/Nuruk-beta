using System;
using System.Collections;
using System.Collections.Generic;
using agora_gaming_rtc;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;

public class AgoraSettings : MonoBehaviour
{
    private TestHome _testHome;
    TestHelloUnityVideo app;
   
    private void Start()
    {
        app = new TestHelloUnityVideo(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Host();
    }

    private void OnTriggerExit(Collider other)
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Audience();
    }

    public void Host()
    {
        app.Host();
    }

    public void Audience()
    {
        app.Audience();
    }
}

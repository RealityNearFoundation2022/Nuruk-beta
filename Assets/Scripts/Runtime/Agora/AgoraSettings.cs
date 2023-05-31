using System;
using System.Collections;
using System.Collections.Generic;
using agora_gaming_rtc;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;

public class AgoraSettings : MonoBehaviour
{

    // TestHelloUnityVideo app;

    private void Start()
    {
        // app = new TestHelloUnityVideo(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        Host();
    }

    private void OnTriggerExit(Collider other)
    {
        Audience();
    }

    public void Host()
    {
        // app.Host();
    }

    public void Audience()
    {
        // app.Audience();
    }
}

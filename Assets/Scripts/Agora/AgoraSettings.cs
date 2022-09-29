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
    [SerializeField] GameObject RoleButton;
    TestHelloUnityVideo app;
   
    private void Start()
    {
        app = new TestHelloUnityVideo(); 
    }

    private void OnTriggerEnter(Collider other)
    {
        RoleButton.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void OnTriggerExit(Collider other)
    {
        RoleButton.SetActive(false);
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
        //mRtcEngine.SetClientRole(CLIENT_ROLE_TYPE.CLIENT_ROLE_AUDIENCE);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderChannelAgora : MonoBehaviour
{
    private TestHome _testHome;
    [SerializeField] private string channelName;
    
    void Start()
    {
        _testHome = FindObjectOfType<TestHome>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player") || PlayerPrefs.GetString("CurrentChannel") == channelName) return;
        _testHome.onJoinChannel(channelName,false);
        PlayerPrefs.SetString("CurrentChannel", channelName);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        _testHome.onLeaveChannel();
        PlayerPrefs.DeleteKey("CurrentChannel");
    }

    private void OnDestroy()
    {
        PlayerPrefs.DeleteKey("CurrentChannel");
    }
}

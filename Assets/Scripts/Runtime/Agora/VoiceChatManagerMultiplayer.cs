using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using agora_gaming_rtc;
using Mirror;

public class VoiceChatManagerMultiplayer : MonoBehaviour
{

    public string appID = "";
    public static VoiceChatManagerMultiplayer Instance;

    private IRtcEngine _rtcEngine;
    
    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    
    void Start()
    {
        _rtcEngine = IRtcEngine.GetEngine(appID);
        _rtcEngine.OnJoinChannelSuccess += OnJoinChannelSuccess;
        _rtcEngine.OnLeaveChannel += OnLeaveChannel;
        _rtcEngine.OnError += OnError;
    }

    private void OnJoinChannelSuccess(string channelname, uint uid, int elapsed)
    {
        Debug.Log("Joined channel " + channelname);
    }

    private void OnLeaveChannel(RtcStats stats)
    {
        Debug.Log("Left channel with duration " + stats.duration);
    }

    private void OnError(int error, string msg)
    {
       Debug.LogError("Error with Agora");
       Debug.Log(msg);
    }
    
    // External
    public void JoinChannel()
    {
        _rtcEngine.JoinChannel("Main");
    }
    
    public void LeftChannel()
    {
        _rtcEngine.LeaveChannel();
    }

    private void OnDestroy()
    {
        IRtcEngine.Destroy();
    }
}

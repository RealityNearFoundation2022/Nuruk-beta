using Mirror;
using UnityEngine;
using agora_gaming_rtc;

public class VoiceChatObserver : NetworkBehaviour
{

    private IRtcEngine rtcNgin;

    private string appID = "3547b652b43e4b27b66bb5a076167e9f";

    private VoiceChatObserver Instance;

    private void Awake()
    {

        if(!Instance)
            Instance = this;
        else
            Destroy(this);

    }

    private void Start()
    {
        if(!isLocalPlayer)
            return;

        rtcNgin = IRtcEngine.GetEngine(appID);

        rtcNgin.OnJoinChannelSuccess += OnJoinChannelSuccess;

        rtcNgin.OnLeaveChannel += OnLeaveChannel;

        rtcNgin.OnError += OnError;
    }

    private void OnError(int error, string msg)
    {
        Debug.Log($"Exception: {msg} with exit code: {error}");
    }

    
    private void OnLeaveChannel(RtcStats stats)
    {
        Debug.Log($"Channel: Mar <Leaved>");
    }

    // Indicates if we successfuly connected with a channel.
    private void OnJoinChannelSuccess(string channelName, uint uid, int elapsed)
    {
        Debug.Log("Joined Channel " + channelName);
    }

    // When the object spawns in the server, this functions is called in all the clients. Therefore we need to verify if the function call applies to the local player.
    public override void OnStartClient()
    {
        if(isLocalPlayer && PlayerPrefs.GetString("TestChannel","Mar") != "Mar")
        {
            rtcNgin.JoinChannel("Mar");
            PlayerPrefs.SetString("TestChannel", "Mar");
        }
    }

    /// Called when the server destroys this game object.
    public override void OnStopClient()
    {
        if(isLocalPlayer)
            rtcNgin.LeaveChannel();
    }
}

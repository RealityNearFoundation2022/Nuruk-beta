using UnityEngine;
using agora_gaming_rtc;

public class VoiceChatObserver : MonoBehaviour
{
    private uint uid;

    private float radious = 7f;

    private IRtcEngine rtcNgin;

    private IAudioEffectManager effectManager;

    private string appID = "3547b652b43e4b27b66bb5a076167e9f";

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public uint GetUID()
    {
        Debug.Log($"The UID: {uid}");
        return uid;
    }

    public void InitiateSpatialAudio()
    {
        // Add Component with the constructor.
        gameObject.AddComponent<SpatialSound>().SetEngine(effectManager, radious);
    }

    private void OnGUI()
    {
        if(GUI.Button(new Rect(30,450, 130, 40), "Connect to channel"))
        {

            if(rtcNgin == null)
                Init();

            rtcNgin.JoinChannel("mar");
        }

        if(GUI.Button(new Rect(30,495,130,40), "Disconnect"))
        {
            rtcNgin.LeaveChannel();

            if(rtcNgin != null)
            {
                rtcNgin = null;
                IRtcEngine.Destroy();
            }
        }
    }


    private void Init()
    {

        rtcNgin = IRtcEngine.GetEngine(appID);

        rtcNgin.OnJoinChannelSuccess += OnJoinChannelSuccess;

        rtcNgin.OnLeaveChannel += OnLeaveChannel;

        rtcNgin.OnError += OnError;

        rtcNgin.EnableSoundPositionIndication(true);

        effectManager = rtcNgin.GetAudioEffectManager();
    }


    private void OnError(int error, string msg)
    {
        Debug.Log($"Exception: {msg} with exit code: {error}");
    }


    private void OnLeaveChannel(RtcStats stats)
    {
        // call the command function.
        
    }

    ///<summary>
    /// Pass the uid to all the clients.
    ///</summary>
    private void OnJoinChannelSuccess(string channelName, uint uid, int elapsed)
    {
        // Call the command function.
        Debug.Log($"You have successfuly connected to the Agora Voice Chat Channel {channelName}");

        this.uid = uid;
    }
}
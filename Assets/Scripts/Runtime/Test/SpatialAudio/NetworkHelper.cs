using Mirror;
using UnityEngine;

public class NetworkHelper : NetworkBehaviour
{

    #region Inspector

    [SyncVar]
    public uint channelUID = 0;

    [Space(3)]

    [SerializeField]
    private string  appID = "3547b652b43e4b27b66bb5a076167e9f";

    #endregion

    private AgoraLayer voiceChat;


    [TargetRpc]
    public void StartAgoraConnection()
    {

        voiceChat = new AgoraLayer(in appID);

        voiceChat.IRtcNgin.OnJoinChannelSuccess += OnJoinChannelSuccess;

        voiceChat.ConnectVoice();

    }


    [Command(requiresAuthority=false)]
    private void UpdateVar(uint uid)
    {
        if(channelUID == 0)
        {
            Debug.Log($"Updating the uid {uid}");
            channelUID = uid;
        }
    }


    ///<summary>
    /// Manages the sucess over the Agora Voice Connection.
    ///</summary>
    ///<remarks> It is important to handle the uid data synchronization </remarks>
    private void OnJoinChannelSuccess(string channelName, uint uid, int timeElapsed)
    {

        // Propagate data.
        UpdateVar(uid);

        // Can expand the services  
            // Add Spatial Audio

    }


}
using Mirror;
using UnityEngine;

public class NetworkHelper : NetworkBehaviour
{
    [SyncVar]
    public uint channelUID = 0;

    private uint intermediateUID = 0;

    private VoiceChatObserver voiceChat;


    [ClientRpc]
    public void GetChannelUID()
    {
        if(!isLocalPlayer)
            return;

        voiceChat = FindObjectOfType<VoiceChatObserver>();

        UpdateVar(voiceChat.GetUID());
    }

    public void OnGUI()
    {
        if(GUI.Button(new Rect(30,405,130,40), "Start spatial Audio"))
        {
            voiceChat.InitiateSpatialAudio();
        }
    }

    [Command(requiresAuthority = false)]
    private void UpdateVar(uint uid)
    {
        channelUID = uid;
    }
}
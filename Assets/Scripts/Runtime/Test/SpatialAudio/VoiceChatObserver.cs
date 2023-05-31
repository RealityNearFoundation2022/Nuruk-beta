using UnityEngine;
using agora_gaming_rtc;

public class AgoraLayer
{

    private IRtcEngine rtcNgin;

    public IRtcEngine IRtcNgin {get => rtcNgin;}

    private IAudioEffectManager effectManager;



    public void ConnectVoice()
    {

        rtcNgin.JoinChannel(token:null,"mar", info:"", uid:0,new ChannelMediaOptions(
            _autoSubscribeAudio: true,
            _autoSubscribeVideo:false,
            _publishLocalAudio:true,
            _publishLocalVideo:false
        ));

    }

    /// Creates 
    public AgoraLayer(in string appID)
    {

        rtcNgin = IRtcEngine.GetEngine(appID);

        rtcNgin.EnableAudio();

        rtcNgin.EnableSoundPositionIndication(true);

        rtcNgin.EnableSpatialAudio(true);
    }

}
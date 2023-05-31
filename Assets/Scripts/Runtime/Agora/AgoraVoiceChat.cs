using UnityEngine;
using agora_gaming_rtc;

namespace Nuruk
{
    ///<summary>
    /// Observes all the states of the agora IRtcEngine.
    ///</summary>
    public class AgoraVoiceChat : MonoBehaviour
    {

        private uint uid;

        private IRtcEngine ngin;

        private string  appID = "3547b652b43e4b27b66bb5a076167e9f";

        public uint GetUID()
        {
            Debug.Log($"The UID: {uid}");
            return uid;
        }



        public IRtcEngine GetNgin()
        {
            return ngin;
        }


        // Creates the SDK interface and use it for the default channel connection.
        public void Awake()
        {

            DontDestroyOnLoad(this);

            if(ngin == null)
                Init();

            ngin.JoinChannel(token:null,"Nuruk", info:"", uid:0,new ChannelMediaOptions(
                _autoSubscribeAudio: true,
                _autoSubscribeVideo:false,
                _publishLocalAudio:true,
                _publishLocalVideo:false
            ));
        }

        /// Initiates the IRtcChannel
        private void Init()
        {

            ngin = IRtcEngine.GetEngine(appID);

            ngin.EnableAudio();

            ngin.OnJoinChannelSuccess += OnJoinChannelSuccess;

            ngin.OnLeaveChannel += OnLeaveChannel;

            ngin.OnError += OnError;

            ngin.EnableSoundPositionIndication(true);

            ngin.EnableSpatialAudio(true);

        }


        private void OnError(int error, string msg)
        {
            Debug.Log($"Exception: {msg} with exit code: {error}");

            // Call the event for errors.
        }


        private void OnLeaveChannel(RtcStats stats)
        {
            
        }


        ///<summary>
        /// 
        ///</summary>
        private void OnJoinChannelSuccess(string channelName, uint uid, int elapsed)
        {
            // Call the command function.
            this.uid = uid;
            Debug.Log($"You have successfuly connected with the UID: {this.uid}");
        }
    }
}

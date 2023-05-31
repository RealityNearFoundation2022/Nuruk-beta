using Mirror;
using UnityEngine;

namespace Nuruk
{
    ///<summary>
    /// The proxy between the Agora Spatial Audio and Mirror.
    ///</summary>
    public class AgoraProxy : NetworkBehaviour
    {
        #region Inspector

        [SyncVar]
        public uint channelUID = 0;

        #endregion


        private AgoraVoiceChat voiceChat;


        [ClientRpc]
        public void GetChannelUID()
        {

            if(!isLocalPlayer)
                return;

            // Request the UID and update it.
            if(channelUID == 0)
            {
                voiceChat = FindObjectOfType<AgoraVoiceChat>();
                UpdateVar(voiceChat.GetUID());
            }

            // Add SpatialAudio component
            if(gameObject.GetComponent<SpatialAudio>())
                return;

            gameObject.AddComponent<SpatialAudio>();
        }



        [Command]
        private void UpdateVar(uint uid)
        {
            if(channelUID == 0)
            {
                // adds the player to the 
                Debug.Log($"Updating the uid {uid}");
                channelUID = uid;

            }
        }
    }
}

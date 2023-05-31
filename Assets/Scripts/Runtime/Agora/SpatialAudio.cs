using UnityEngine;
using agora_gaming_rtc;

namespace Nuruk
{
    public class SpatialAudio : MonoBehaviour
    {
        private IRtcEngine rtcNgin;

        ///<summary>
        /// Every frame cycles through all the players
        ///</summary>
        private void Update()
        {
            if(rtcNgin == null)
            {
                // Try to get the AgoraVoiceChat.
                TryGetNgin();
                return;
            }
    

            foreach(GameObject go in GameObject.FindGameObjectsWithTag("Player"))
            {

                if(go == gameObject)
                {
                    continue;
                }

                uint uid = go.GetComponent<AgoraProxy>().channelUID;

                // The distance between the two players translated in volume
                float gain = CalculateGain(go.transform.position);

                // TODO: Create a way to retreive zero if gain equals 1 using math.
                float attenuation = (gain / 50);

                //TODO: Create a way to calculate the azimtuth, elevation and orentation    


                // Calculate the attenuatio with the distance.
                Debug.Log($"Calculating the audio for the player with the uid: {uid}, Attenuation and Gain: {attenuation},{gain}");

                rtcNgin.SetRemoteUserSpatialAudioParams(uid,0 , 0, gain,0,attenuation, false, false);
            }
        }


        ///<summary>
        ///
        ///</summary>
        private void TryGetNgin()
        {
            AgoraVoiceChat v = FindObjectOfType<AgoraVoiceChat>();
            Debug.Log("Calling the UID ");

            if(v.GetUID() == 0)
                return;

            rtcNgin = v.GetNgin();
        }

        ///<summary>
        /// Take the distance between two vectors and clamp it [1,50]
        ///</summary>
        private float CalculateGain(in Vector3 v)
        {
            // The difference between the distance and the v.
            float delta = Vector3.Distance(transform.position, v);

            return Mathf.Clamp(delta, 1,50);
        }

    }
}

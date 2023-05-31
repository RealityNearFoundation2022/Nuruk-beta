using UnityEngine;
using agora_gaming_rtc;

///<summary>
/// Takes its transform to calculate the volumen and laterality of the input audio of the player
///</summary>
public class SpatialSound : MonoBehaviour
{

    private IAudioEffectManager effectNgin;

    private IRtcEngine rtcNgin;

    private float radious = 3f;

    ///<summary>
    /// Every frame cycles through all the players
    ///</summary>
    private void Update()
    {
        if(effectNgin == null)
        {
            Debug.Log("Effect Audio Manager  is null.");
            return;
        }


        foreach(GameObject go in GameObject.FindGameObjectsWithTag("Player"))
        {
            if(go == gameObject)
            {
                // Debug.Log("Cannot calculate audio for the object itself");
                continue;
            }
            uint uid = go.GetComponent<NetworkHelper>().channelUID;

            // The distance between the two players translated in volume
            float gain = CalculateGain(go.transform.position);
            float attenuation = (gain / 50);


            // Calculate the attenuatio with the distance.
            Debug.Log($"Calculating the audio for the player with the uid: {uid}, Attenuation and Gain: {attenuation},{gain}");

            rtcNgin.SetRemoteUserSpatialAudioParams(uid,0 , 0, gain,0,attenuation, false, false);
        }
    }


    ///<summary>
    /// Take the distance between two vectors and 
    ///</summary>
    private float CalculateGain(in Vector3 v)
    {
        // The difference between the distance and the v.
        float delta = Vector3.Distance(transform.position, v);

        return Mathf.Clamp(delta, 1,50);
    }

}
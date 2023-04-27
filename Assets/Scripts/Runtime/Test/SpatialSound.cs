using UnityEngine;
using agora_gaming_rtc;

public class SpatialSound : MonoBehaviour
{

    private IAudioEffectManager ngin;

    private float radious;


    public void SetEngine(in IAudioEffectManager ngin, in float radious)
    {
        this.ngin = ngin;
        this.radious = radious;
    }


    private void LateUpdate()
    {
        if(ngin == null)
            return;

        foreach(GameObject go in GameObject.FindGameObjectsWithTag("Player"))
        {
            // Set the pan and the gain
            uint uid = go.GetComponent<NetworkHelper>().channelUID;

            float gain = CalculateGain(go.transform.position);
            float pan = CalculatePan(go.transform.position);

            //Mean while//
            ngin.SetRemoteVoicePosition(uid, gain, pan);
        }
    }


    /// Total volume
    private float CalculateGain(in Vector3 v)
    {
        // The difference between the distance and the v.
        float delta = Vector3.Distance(transform.position, v);

        return Mathf.Max(1 - (delta / radious), 0) * 100f;
    }


    /// Side of the Pan
    private float CalculatePan(in Vector3 v)
    {

        //Direction between the v and the self position;
        Vector3 delta = v - transform.position;
        delta.Normalize();

        return Vector3.Dot(transform.right, delta);
    }
}

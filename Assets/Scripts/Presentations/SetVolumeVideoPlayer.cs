using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SetVolumeVideoPlayer : MonoBehaviour
{

    public bool playAudio;

    public VideoPlayer video;

    public void OnTriggerEnter(Collider other)
    {
        if (video.isActiveAndEnabled)
        {
            video.SetDirectAudioMute(0, playAudio);
            Debug.Log("entro");
        }
    }
}

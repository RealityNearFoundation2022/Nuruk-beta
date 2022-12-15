using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SetVolumeVideoPlayer : MonoBehaviour
{

    public bool playAudio;

    public VideoPlayer video;
    public AudioSource Audiovideo;

    private void Start()
    {
        Audiovideo.mute = false;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (video.isActiveAndEnabled)
        {
            Audiovideo.mute = playAudio;
            // video.SetDirectAudioMute(0, playAudio);
            Debug.Log("entro");
        }
    }
}

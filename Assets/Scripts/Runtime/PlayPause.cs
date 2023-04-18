using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PlayPause : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] Button pause, play;

    private void Start()
    {
        pause.onClick.AddListener(() => PauseVideo());
        play.onClick.AddListener(() => PlayVideo());
    }

    public void PauseVideo()
    {
        pause.gameObject.SetActive(false);
        play.gameObject.SetActive(true);
        videoPlayer.Pause();
    }

    public void PlayVideo()
    {
        pause.gameObject.SetActive(true);
        play.gameObject.SetActive(false);
        videoPlayer.Play();
    }
}
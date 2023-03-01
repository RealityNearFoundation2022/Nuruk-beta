using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Mirror;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PresentationWithHelpers : NetworkBehaviour
{
    [SerializeField] private GameObject Video;
    [SerializeField] private GameObject playPause;
    [SerializeField] private Sprite[] _diapositive;

    [SerializeField] private SpriteRenderer spriteRendererPresentation;

    [SerializeField] private SpriteRenderer spriteRendererNext;
    [SerializeField] private SpriteRenderer spriteRendererPrev;
    [SerializeField] private VideoPlayer videoPlayer;

    [SyncVar]
    public int currentDiapositive;
    private int _maxDiapositive = 0;

    [SyncVar(hook = nameof(SyncVideo))]
    public bool isPlaying;
    [SyncVar(hook = nameof(SyncTime))]
    public double currentTime;

    void Start()
    {
        videoPlayer = Video.GetComponent<VideoPlayer>();
        spriteRendererPresentation.sprite = _diapositive[currentDiapositive | 0];
        _maxDiapositive = _diapositive.Length;
    }

    [Command(requiresAuthority = false)]
    public void EnableVideoPlayer()
    {
        isPlaying = true;
    }

    [Command(requiresAuthority = false)]
    public void DesableVideoPlayer()
    {
        Video.GetComponent<MeshRenderer>().enabled = false;
        videoPlayer.Stop();
        isPlaying = true;
    }


    [ClientRpc]
    public void NextDiapositive()
    {
        if (currentDiapositive == _maxDiapositive - 1)
        {
            if (playPause != null) playPause.SetActive(true);
            EnableVideoPlayer();
        }
        else
        {
            if (playPause != null) playPause.SetActive(false);
            DesableVideoPlayer();
        }
       
        if (currentDiapositive + 1 < _maxDiapositive)
        {
            currentDiapositive++;
            spriteRendererPresentation.sprite = _diapositive[currentDiapositive];

            SetNextHelper();
            SetPreHelper();
        }
    }


    [ClientRpc]
    public void PrevDiapositive()
    {
        if (currentDiapositive != _maxDiapositive - 1)
        {
            if (playPause != null) playPause.SetActive(false);
            DesableVideoPlayer();
        }

        if (currentDiapositive - 1 >= 0)
        {
            Debug.Log("Change");
            currentDiapositive--;
            spriteRendererPresentation.sprite = _diapositive[currentDiapositive];
            SetNextHelper();
            SetPreHelper();
        }

    }

    [Command(requiresAuthority = false)]
    public void ChangeNext()
    {
        NextDiapositive();
    }


    [Command(requiresAuthority = false)]
    public void ChangePrev()
    {
        PrevDiapositive();
    }

    private void SetNextHelper()
    {
        spriteRendererNext.sprite = currentDiapositive + 1 < _maxDiapositive ? _diapositive[currentDiapositive + 1] : null;
    }

    private void SetPreHelper()
    {
        spriteRendererPrev.sprite = _diapositive[currentDiapositive];
    }

    void Update()
    {
        if (isPlaying)
        {
            SyncTimeClient(videoPlayer.time);
        }
    }

    // Update the video time on the server
    [ServerCallback]
    public void CmdUpdateTime(double time)
    {
       SyncTimeClient(time);
        Debug.Log("Time: " + time);
    }

    public void PlaySyncVideo()
    {
        if (isPlaying)
        {
            videoPlayer.time = currentTime;
            videoPlayer.Play();
        }
    }
    
    [ClientRpc]
    public void SyncTimeClient(double time)
    {
        Debug.Log("Time: " + time);
    }

    void SyncVideo(bool oldState, bool newState)
    {
        if (newState)
        {
            Video.GetComponent<MeshRenderer>().enabled = true;
            videoPlayer.Play();
        }
    }

    // Sync time on the client
    public void SyncTime(double oldState, double newState)
    {
        videoPlayer.time = newState;
    }

    public void PauseSyncVideo()
    {
        videoPlayer.Pause();
    }
}

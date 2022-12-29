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

    void Start()
    {
        videoPlayer = Video.GetComponent<VideoPlayer>();
        spriteRendererPresentation.sprite = _diapositive[currentDiapositive | 0];
        _maxDiapositive = _diapositive.Length;
    }

    public void EnableVideoPlayer()
    {
        Video.GetComponent<MeshRenderer>().enabled = true;
        videoPlayer.Play();
    }
    public void DesableVideoPlayer()
    {
        Video.GetComponent<MeshRenderer>().enabled = false;
        videoPlayer.Stop();
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
}

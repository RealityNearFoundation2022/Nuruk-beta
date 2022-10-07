using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using CustomEvents;
using StarterAssets;
using Mirror;

public class Skills : NetworkBehaviour
{
    [SerializeField] private GameObject player;
    private static readonly int Sit = Animator.StringToHash("Sit");

    [SerializeField] private Collider collider;

    #region Sit Variables

    private bool _isSit = false;
    private Transform sitPosition;
    private GameObject _cameraPlayer;

    #endregion
    
    
    #region Sit
    private void SitPlayerEvent(Sit sitData)
    {
        
        if (!isLocalPlayer)
            return;
        if (sitData.sitPlayer)
        {
            player.GetComponent<ThirdPersonController>().enabled = false;
            player.transform.position = sitData.sitPosition.position;
            //player.GetComponent<ThirdPersonController>().enabled = true;
            player.GetComponent<Animator>().SetBool(Sit, true);
            player.transform.rotation = sitData.sitPosition.rotation;
            if (!_cameraPlayer)
                _cameraPlayer = GameObject.Find("PlayerFollowCamera");
            _cameraPlayer.SetActive(false);
            sitData.cameraToLook.SetActive(true);
        }
        else
        {
            player.GetComponent<ThirdPersonController>().enabled = true;
            _cameraPlayer.SetActive(true);
            sitData.cameraToLook.SetActive(false);
            player.GetComponent<Animator>().SetBool(Sit, false);
        }
        
    }

    #endregion


    private void OnEnable()
    {
        Events.SitPlayer.AddListener(SitPlayerEvent);
    }

    private void OnDisable()
    {
        Events.SitPlayer.RemoveListener(SitPlayerEvent);
    }

    
}

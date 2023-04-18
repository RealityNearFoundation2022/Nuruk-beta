using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncVideo : MonoBehaviour
{
    [SerializeField] private PresentationWithHelpers _presentationWithHelpers;
    
    // on trigger enter play video
    private void OnTriggerEnter(Collider other)
    {
        _presentationWithHelpers.PlaySyncVideo();
    }

    // on trigger exit stop video
    private void OnTriggerExit(Collider other)
    {
        _presentationWithHelpers.PauseSyncVideo();
    }
}

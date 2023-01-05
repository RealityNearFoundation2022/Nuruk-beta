using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class AskAuthority : MonoBehaviour
{
    [SerializeField] private Transform internalComponents = default;
    [SerializeField] private Transform rsg = default;
    
    private void Start()
    {
        internalComponents.GetComponent<RealtimeTransform>().RequestOwnership();
        rsg.GetComponent<RealtimeTransform>().RequestOwnership();
        
    }
}

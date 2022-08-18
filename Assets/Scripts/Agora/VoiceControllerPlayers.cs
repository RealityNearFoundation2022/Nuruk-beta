using System;
using System.Collections;
using System.Collections.Generic;
using City;
using UnityEngine;
using Mirror;

public class VoiceControllerPlayers : NetworkBehaviour
{
    // public override void OnStartClient()
    // {
    //     foreach (var client in NetworkClient.spawned)
    //     {
    //         //client.Value.netId;
    //         NetworkClient.localPlayer.netId
    //     }
    //     
    // }

    
    
    

    public override void OnStopClient()
    {
        // Call agora stop
    }
    
}

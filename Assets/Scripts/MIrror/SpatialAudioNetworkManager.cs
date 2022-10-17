using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


public class SpatialAudioNetworkManager : NetworkManager
{
    public VoiceChatManagerMultiplayer _voiceChatManagerMultiplayer;
    public static Dictionary<Guid, NetworkConnection> playersConnections = new Dictionary<Guid, NetworkConnection>();
    
    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        Debug.Log("Client Enter");
        
        _voiceChatManagerMultiplayer.JoinChannel();
        base.OnServerAddPlayer(conn);
        Debug.Log(playersConnections.Count);
    }

    public override void OnClientConnect()
    {
        playersConnections[System.Guid.NewGuid()] = NetworkClient.connection;
    }

    public override void OnClientDisconnect()
    {
       // playersConnections.Remove(NetworkClient.connection);
    }
}

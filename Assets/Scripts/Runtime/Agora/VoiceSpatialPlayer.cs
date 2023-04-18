using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class VoiceSpatialPlayer : NetworkBehaviour  
{
    [SerializeField] private float radius;
    static Dictionary<NetworkConnection, VoiceSpatialPlayer> spatialFromPlayer = new Dictionary<NetworkConnection, VoiceSpatialPlayer>();
    
    private void Awake()
    {
        
    }

    public override void OnStartClient()
    {
        Debug.Log("Cliente");
        spatialFromPlayer[NetworkClient.connection] = this;
    }
    
    // private void OnDestroy()
    // {
    //     spatialFromPlayer.Remove(NetworkClient.connection);
    // }

    private void Update()
    {
        foreach (var connectionPlayer in SpatialAudioNetworkManager.playersConnections.Values)
        {
            Debug.Log("Local => " + connectionPlayer.identity.netId);
            Debug.Log("Network => " + NetworkClient.connection.identity.netId);
            if (connectionPlayer.identity.netId == NetworkClient.connection.identity.netId)
                continue;
            VoiceSpatialPlayer other = spatialFromPlayer[connectionPlayer];
            float gain = GetGain(other.transform.position);
            float pan = GetPan(other.transform.position);
            Debug.Log("Gain => " + gain);
            Debug.Log("Pan => " + pan);
        }

        Debug.Log(spatialFromPlayer.Count);
    }

    private float GetGain(Vector3 otherPosition)
    {
        var distance = Vector3.Distance(transform.position, otherPosition);
        var gain = Mathf.Max(1 - (distance / radius), 0) * 100f;
        return gain;
    }

    private float GetPan(Vector3 otherPosition)
    {
        Vector3 diretion = otherPosition - transform.position;
        diretion.Normalize();
        float dotProduct = Vector3.Dot(transform.right, diretion);
        return dotProduct;
    }
}

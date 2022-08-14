using System;
using Mirror;
using UnityEngine;

public class StartClient : MonoBehaviour
{
    
    NetworkManager manager;
    private bool _alreadyCall = false;
    
    void Awake()
    {
        manager = GetComponent<NetworkManager>();
    }

    private void Update()
    {
        if (!NetworkClient.isConnected && !NetworkServer.active && !_alreadyCall )
        {
            manager.StartClient();
            _alreadyCall = true;
        }
    }
}

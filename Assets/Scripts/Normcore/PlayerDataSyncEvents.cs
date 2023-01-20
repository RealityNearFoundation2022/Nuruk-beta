using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataSyncEvents : MonoBehaviour
{
    private PlayerDataSync playerDataSync;
    void Start()
    {
        playerDataSync = GetComponent<PlayerDataSync>();
    }

    public void ChangeShirt(string shirtName)
    {
        playerDataSync.ChangeShirt(shirtName);
    }

}

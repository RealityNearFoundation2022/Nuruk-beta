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
    public void ChangeHead(string headName)
    {
        playerDataSync.ChangeHead(headName);
    }
    public void ChangePants(string headName)
    {
        playerDataSync.ChangePants(headName);
    }
    public void ChangeShoes(string shoes)
    {
        playerDataSync.ChangeShoes(shoes);
    }
    public void ChangeExtras(string extras)
    {
        playerDataSync.ChangeExtras(extras);
    }
}

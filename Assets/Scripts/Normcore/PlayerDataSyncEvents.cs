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

    #region CustomClothes
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
    #endregion

    #region  Movements
    public void ChangeSpeed(float speed)
    {
          playerDataSync.ChangeSpeed(speed);
    }
    public void ChangeGrounded(bool grounded)
    {
        playerDataSync.ChangeGrounded(grounded);
    }
    public void ChangeMotionSpeed(float motionSpeed)
    {
        playerDataSync.ChangeMotionSpeed(motionSpeed);
    }
    public void ChangeJump(bool jump)
    {
        playerDataSync.ChangeJump(jump);
    }
    public void ChangeFreeFall(bool freeFall)
    {
        playerDataSync.ChangeFreeFall(freeFall);
    }
    #endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using System;
using PlayerMirror;

public class PlayerDataSync : RealtimeComponent<ModelSync>
{

    private RealtimeView _realtimeView;

    // Player
    private Animator _playerAnimator;

    private SetupCharacter playerSetupCharacter;
    private void Awake()
    {
        // Get a reference to the mesh renderer
        _playerAnimator = GetComponent<Animator>();
        _realtimeView = GetComponent<RealtimeView>();
        playerSetupCharacter = GetComponent<SetupCharacter>();
    }
    protected override void OnRealtimeModelReplaced(ModelSync previousModel, ModelSync currentModel)
    {
        if (previousModel != null)
        {
            previousModel.shirtsDidChange -= ShirtDidChange;
            previousModel.headsDidChange -= HeadsDidChange;
           
        }
        if (currentModel != null)
        {
            // If this is a model that has no data set on it, populate it with the current data
            if (currentModel.isFreshModel)
            {
                currentModel.shirts = "";
                currentModel.heads = "";
            }
            UpdateShirt();

            currentModel.shirtsDidChange += ShirtDidChange;
            currentModel.headsDidChange += HeadsDidChange;
        }
    }

    private void HeadsDidChange(ModelSync model, string value)
    {
        UpdateHead();
    }

    private void ShirtDidChange(ModelSync model, string value)
    {
        UpdateShirt();
    }
    public void UpdateShirt()
    {
        if (!_realtimeView.isOwnedLocallyInHierarchy)
        {
            playerSetupCharacter.ShirtUpdate(model.shirts);
        }
    }
    public void UpdateHead()
    {
        if (!_realtimeView.isOwnedLocallyInHierarchy)
        {
            playerSetupCharacter.HeadUpdate(model.heads);
        }
    }
    public void ChangeShirt(string shirt)
    {
        model.shirts = shirt;
    }
    public void ChangeHead(string head)
    {
        model.heads = head;
    }
}

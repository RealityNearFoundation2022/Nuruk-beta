using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using System;
using PlayerMirror;

public class PlayerDataSync  : RealtimeComponent<ModelSync>
{

    private RealtimeView _realtimeView;

    // Player
    public Animator _playerAnimator;

    public SetupCharacter playerSetupCharacter;
    protected override void OnRealtimeModelReplaced(ModelSync previousModel, ModelSync currentModel)
    {
        if (previousModel != null)
        {
            previousModel.shirtsDidChange -= ShirtDidChange;
        }
        if (currentModel != null)
        {
            // If this is a model that has no data set on it, populate it with the current data
            if (currentModel.isFreshModel)
            {
                currentModel.shirts = "";
            }
            UpdateShirt();

            currentModel.shirtsDidChange += ShirtDidChange;
        }
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
    public void ChangeShirt(string shirt)
    {
        model.shirts = shirt;
    }
}

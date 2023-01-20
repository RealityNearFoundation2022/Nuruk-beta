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
            previousModel.pantsDidChange -= PantsDidChange;
            previousModel.shirtsDidChange -= ShoesDidChange;
            previousModel.extrasDidChange -= ExtrasDidChange;

        }
        if (currentModel != null)
        {
            // If this is a model that has no data set on it, populate it with the current data
            if (currentModel.isFreshModel)
            {
                currentModel.shirts = "";
                currentModel.heads = "";
                currentModel.pants = "";
                currentModel.shoes = "";
                currentModel.extras = "";
            }
            UpdateShirt();

            currentModel.shirtsDidChange += ShirtDidChange;
            currentModel.headsDidChange += HeadsDidChange;
            currentModel.pantsDidChange += PantsDidChange;
            currentModel.shoesDidChange += ShoesDidChange;
            currentModel.extrasDidChange += ExtrasDidChange;
        }
    }

    private void ExtrasDidChange(ModelSync model, string value)
    {
        UpdateExtras();
    }

    private void ShoesDidChange(ModelSync model, string value)
    {
        UpdateShoes();
    }

    private void PantsDidChange(ModelSync model, string value)
    {
        UpdatePant();
    }

    private void HeadsDidChange(ModelSync model, string value)
    {
        UpdateHead();
    }

    private void ShirtDidChange(ModelSync model, string value)
    {
        UpdateShirt();
    }
    public void UpdatePant()
    {
        if (!_realtimeView.isOwnedLocallyInHierarchy)
        {
            playerSetupCharacter.PantsUpdate(model.pants);
        }
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
    public void UpdateShoes()
    {
        if (!_realtimeView.isOwnedLocallyInHierarchy)
        {
            playerSetupCharacter.ShoesUpdate(model.shoes);
        }
    }
    public void UpdateExtras()
    {
        if (!_realtimeView.isOwnedLocallyInHierarchy)
        {
            playerSetupCharacter.ExtrasUpdate(model.extras);
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
    public void ChangePants(string pant)
    {
        model.pants = pant;
    }
    public void ChangeShoes(string shoes)
    {
        model.shoes = shoes;
    }
    public void ChangeExtras(string extras)
    {
        model.extras = extras;
    }
}

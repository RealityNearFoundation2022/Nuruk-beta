using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
using System;
using PlayerMirror;
using StarterAssets;

public class PlayerDataSync : RealtimeComponent<ModelSync>
{

    private RealtimeView _realtimeView;

    // Player
    private Animator _playerAnimator;

    private SetupCharacter playerSetupCharacter;
    private ThirdPersonController _playerController;

    private void Awake()
    {
        // Get a reference to the mesh renderer
        _playerAnimator = GetComponent<Animator>();
        _realtimeView = GetComponent<RealtimeView>();
        playerSetupCharacter = GetComponent<SetupCharacter>();
        _playerController = GetComponent<ThirdPersonController>();
    }
    protected override void OnRealtimeModelReplaced(ModelSync previousModel, ModelSync currentModel)
    {
        if (previousModel != null)
        {   // clothes
            previousModel.shirtsDidChange -= ShirtDidChange;
            previousModel.headsDidChange -= HeadsDidChange;
            previousModel.pantsDidChange -= PantsDidChange;
            previousModel.shirtsDidChange -= ShoesDidChange;
            previousModel.extrasDidChange -= ExtrasDidChange;

            // movements
            previousModel.groundedDidChange -= GroundedDidChange;
            previousModel.speedDidChange -= SpeedDidChange;
            previousModel.motionSpeedDidChange -= MotionSpeedDidChange;
            previousModel.jumpDidChange -= JumpDidChange;
            previousModel.freeFallDidChange -= FreeFallDidChange;
        }
        if (currentModel != null)
        {
            // If this is a model that has no data set on it, populate it with the current data
            if (currentModel.isFreshModel)
            {   //clothes
                currentModel.shirts = "";
                currentModel.heads = "";
                currentModel.pants = "";
                currentModel.shoes = "";
                currentModel.extras = "";
                //movements
                currentModel.grounded = false;
                currentModel.speed = 0;
                currentModel.motionSpeed = 1;
                currentModel.jump = false;
                currentModel.freeFall = false;
            }
            UpdateShirt();
            UpdateHead();
            UpdatePant();
            UpdateShoes();
            UpdateExtras();

            UpdateGrounded();
            UpdateSpeed();
            UpdateMotionSpeed();
            UpdateJump();
            UpdateFreeFall();

            currentModel.shirtsDidChange += ShirtDidChange;
            currentModel.headsDidChange += HeadsDidChange;
            currentModel.pantsDidChange += PantsDidChange;
            currentModel.shoesDidChange += ShoesDidChange;
            currentModel.extrasDidChange += ExtrasDidChange;

            currentModel.groundedDidChange += GroundedDidChange;
            currentModel.speedDidChange += SpeedDidChange;
            currentModel.motionSpeedDidChange += MotionSpeedDidChange;
            currentModel.jumpDidChange += JumpDidChange;
            currentModel.freeFallDidChange += FreeFallDidChange;
        }
    }



    #region Clothes
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
    #endregion

    #region movements
    private void GroundedDidChange(ModelSync model, bool value)
    {
        UpdateGrounded();
    }
    private void SpeedDidChange(ModelSync model, float value)
    {
        UpdateSpeed();
    }
    private void MotionSpeedDidChange(ModelSync model, float value)
    {
        UpdateMotionSpeed();
    }
    private void JumpDidChange(ModelSync model, bool value)
    {
        UpdateJump();
    }
    private void FreeFallDidChange(ModelSync model, bool value)
    {
        UpdateFreeFall();
    }
    private void UpdateSpeed()
    {
        if (!_realtimeView.isOwnedLocallyInHierarchy)
        {
            _playerAnimator.SetFloat(_playerController._animIDSpeed, model.speed);
        }
    }
    private void UpdateGrounded()
    {
        if (!_realtimeView.isOwnedLocallyInHierarchy)
        {
            _playerAnimator.SetBool(_playerController._animIDGrounded, model.grounded);
        }
    }
    private void UpdateMotionSpeed()
    {
        if (!_realtimeView.isOwnedLocallyInHierarchy)
        {
            _playerAnimator.SetFloat(_playerController._animIDMotionSpeed, model.motionSpeed);
        }
    }
    private void UpdateJump()
    {
        if (!_realtimeView.isOwnedLocallyInHierarchy)
        {
            _playerAnimator.SetBool(_playerController._animIDJump, model.jump);
        }
    }
    private void UpdateFreeFall()
    {
        if (!_realtimeView.isOwnedLocallyInHierarchy)
        {
            _playerAnimator.SetBool(_playerController._animIDFreeFall, model.freeFall);
        }
    }
    public void ChangeSpeed(float speed)
    {
        model.speed = speed;
    }
    public void ChangeGrounded(bool grounded)
    {
        model.grounded = grounded;
    }
    public void ChangeMotionSpeed(float motionSpeed)
    {
        model.motionSpeed = motionSpeed;
    }
    public void ChangeJump(bool jump)
    {
        model.jump = jump;
    }
    public void ChangeFreeFall(bool freeFall)
    {
        model.freeFall = freeFall;
    }
    #endregion
}

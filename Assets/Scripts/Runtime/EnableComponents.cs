using Mirror;
using UnityEngine.InputSystem;
using UnityEngine;
using Cinemachine;


namespace StarterAssets
{
   public class EnableComponents : NetworkBehaviour
   {

      public Transform target;

      void Start()
      {
         if (isLocalPlayer)
         {
            CharacterController characterController = GetComponent<CharacterController>();
            characterController.enabled = true;
            ThirdPersonController thirdPersonController = GetComponent<ThirdPersonController>();
            thirdPersonController.enabled = true;
            PlayerInput playerInput = GetComponent<PlayerInput>();
            playerInput.enabled = true;
            GameObject platerFollow = GameObject.Find("PlayerFollowCamera");
            CinemachineVirtualCamera virtualCamera = platerFollow.GetComponent<CinemachineVirtualCamera>();
            virtualCamera.Follow = target;
            virtualCamera.LookAt = target;

         }
      }
   }
}


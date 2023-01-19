//using Mirror;
using Normal.Realtime;
using UnityEngine.InputSystem;
using UnityEngine;
using Cinemachine;


namespace StarterAssets
{
   public class EnableComponents : MonoBehaviour
   {

      public Transform target;
        private RealtimeView _realtimeView;
       // [SerializeField] private Transform _character = default;

        void Awake()
        {
            _realtimeView = GetComponent<RealtimeView>();
        }
        private void Start()
        {
            // Call LocalStart() only if this instance is owned by the local client
            if (_realtimeView.isOwnedLocallyInHierarchy)
                LocalStart();
        }

        private void LocalStart()
        {
            // Request ownership of the Player and the character RealtimeTransforms
       //     GetComponent<RealtimeTransform>().RequestOwnership();
         //   _character.GetComponent<RealtimeTransform>().RequestOwnership();



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

#if UNITY_WEBGL && !UNITY_EDITOR
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
#endif
        }

        //        void Start()
        //      {
        //         if (isLocalPlayer)
        //         {
        //            CharacterController characterController = GetComponent<CharacterController>();
        //            characterController.enabled = true;
        //            ThirdPersonController thirdPersonController = GetComponent<ThirdPersonController>();
        //            thirdPersonController.enabled = true;
        //            PlayerInput playerInput = GetComponent<PlayerInput>();
        //            playerInput.enabled = true;
        //            GameObject platerFollow = GameObject.Find("PlayerFollowCamera");
        //            CinemachineVirtualCamera virtualCamera = platerFollow.GetComponent<CinemachineVirtualCamera>();
        //            virtualCamera.Follow = target;
        //            virtualCamera.LookAt = target;

        //#if UNITY_WEBGL && !UNITY_EDITOR
        //        Cursor.lockState = CursorLockMode.Locked;
        //         Cursor.visible = false;
        //#endif
    //}
     // }
   }
}


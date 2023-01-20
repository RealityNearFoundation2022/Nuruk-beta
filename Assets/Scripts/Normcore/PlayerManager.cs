using Cinemachine;
using UnityEngine;
using Normal.Realtime;
using Normal;
using UnityEngine.Animations;
using PlayerMirror;
using PlayFab;
using PlayFab.ClientModels;
using Classes;
using Player;
using StarterAssets;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject _camera = default;

    // private PuzzleSetupNetworked _puzzleSetupNetworked;
    private Realtime _realtime;
    [SerializeField] private Transform spawnTransform = default;
    string prefabName= "";
    GameObject playerGameObject;

    private void Awake()
    {
        // Get the Realtime component on this game object
        _realtime = GetComponent<Realtime>();

        // Notify us when Realtime successfully connects to the room
        _realtime.didConnectToRoom += DidConnectToRoom;

        // Set puzzle networked
        // _puzzleSetupNetworked = GetComponent<PuzzleSetupNetworked>();
    }

    private void DidConnectToRoom(Realtime realtime)
    {
        // Enabling ropa

        PlayFabClientAPI.GetUserData(new GetUserDataRequest()
        {
            Keys = null
        }, result =>
        {
            Debug.Log("Got user data:");
            if (result.Data == null || !result.Data.ContainsKey("CharacterSetup"))
                Debug.Log("No Character customs");
            else
            {
                CharacterSetup _characterSetup = JsonUtility.FromJson<CharacterSetup>(result.Data["CharacterSetup"].Value);

                if(_characterSetup.type == "Male")
                {
                    prefabName = "PlayerMenNetworkedNormcore";
                }else if (_characterSetup.type == "Female")
                {
                    prefabName = "PlayerWomenNetworkedNormcore";
                }else if (_characterSetup.type == "Monster")
                {
                    prefabName = "PlayerMonsterNetworkedNormcore";
                }

                /* "PlayerNetworkedNormcore"*/
                playerGameObject = Realtime.Instantiate(prefabName: prefabName,  // Prefab name
                      spawnTransform.position,
                      transform.rotation,
                      ownedByClient: true,      // Make sure the RealtimeView on this prefab is owned by this client
                      preventOwnershipTakeover: true,      // Prevent other clients from calling RequestOwnership() on the root RealtimeView.
                      useInstance: realtime); // Use the instance of Realtime that fired the didConnectToRoom event.


                playerGameObject.GetComponent<SetupCharacter>().currentShirt = _characterSetup.shirt;
                playerGameObject.GetComponent<SetupCharacter>().currentHead = _characterSetup.head;
                playerGameObject.GetComponent<SetupCharacter>().currentPants = _characterSetup.pants;
                playerGameObject.GetComponent<SetupCharacter>().currentShoes = _characterSetup.shoes;
                playerGameObject.GetComponent<SetupCharacter>().currentExtra = _characterSetup.extra;

                StartCoroutine(playerGameObject.GetComponent<SetupCharacter>().StartSetup());

                Debug.Log(_characterSetup.type);
            }

            if (result.Data.ContainsKey("Username"))
            {
                Debug.Log(JsonUtility.FromJson<Username>(result.Data["Username"].Value).value);
                PlayerData.username = JsonUtility.FromJson<Username>(result.Data["Username"].Value).value;

            }

            CharacterController characterController = playerGameObject.GetComponent<CharacterController>();
            characterController.enabled = true;
            ThirdPersonController thirdPersonController = playerGameObject.GetComponent<ThirdPersonController>();
            thirdPersonController.enabled = true;
            PlayerInput playerInput = playerGameObject.GetComponent<PlayerInput>();
            playerInput.enabled = true;
            GameObject platerFollow = GameObject.Find("PlayerFollowCamera");
            CinemachineVirtualCamera virtualCamera = platerFollow.GetComponent<CinemachineVirtualCamera>();
            //Transform childTransformCamera = playerGameObject.transform.GetChild(1);
            virtualCamera.Follow = playerGameObject.transform.GetChild(0);
            virtualCamera.LookAt = playerGameObject.transform.GetChild(0);

        }, (error) =>
        {
            Debug.Log("Got error retrieving user data:");
            Debug.Log(error.GenerateErrorReport());
        });

        

    }
}

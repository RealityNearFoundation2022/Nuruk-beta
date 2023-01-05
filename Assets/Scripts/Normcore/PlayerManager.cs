using UnityEngine;
using Normal.Realtime;
using Normal;
using UnityEngine.Animations;


public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject _camera = default;

   // private PuzzleSetupNetworked _puzzleSetupNetworked;
    private Realtime _realtime;
    [SerializeField] private Transform spawnTransform = default;


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
        GameObject playerGameObject = Realtime.Instantiate(prefabName: "PlayerNetworked",  // Prefab name
            spawnTransform.position,
            transform.rotation,
            ownedByClient: true,      // Make sure the RealtimeView on this prefab is owned by this client
            preventOwnershipTakeover: true,      // Prevent other clients from calling RequestOwnership() on the root RealtimeView.
            useInstance: realtime); // Use the instance of Realtime that fired the didConnectToRoom event.

        //// Get child objects
        //Transform childTransformCamera = playerGameObject.transform.GetChild(1);
        //childTransformCamera.GetChild(0).GetComponent<CameraDistanceRaycaster>().cameraTransform = _camera.transform;
        //_camera.transform.SetParent(childTransformCamera.GetChild(0).GetChild(0).transform);

        //// Setting puzzle
        //_puzzleSetupNetworked.SetupNetworked(playerGameObject.GetComponent<AdvancedWalkerController>(),
        //    childTransformCamera.GetChild(0).GetComponent<ThirdPersonCameraController>(), _camera.GetComponent<AdventureKitRaycast>());


    }
}

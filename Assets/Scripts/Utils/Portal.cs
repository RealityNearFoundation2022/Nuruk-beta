using System.Collections;
using StarterAssets;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private Transform Camera;
    [SerializeField] private Transform TargetLookAt;
    [SerializeField] private Transform _destination;
    [SerializeField] private Transform _destinationTemp;
    [SerializeField] private Animator _fadeCanvas;
    GameObject player;
    GameObject cameraRoot;

   void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.CompareTag("Player"))
      {
         player = other.gameObject;
         cameraRoot = player.transform.GetChild(0).gameObject;
          
            Debug.Log(cameraRoot.name);
         StartCoroutine(FinishTeleport(other.gameObject));
      }
   }

   IEnumerator FinishTeleport(GameObject player)
   {
      _fadeCanvas.SetBool("Teleport", true);
      yield return new WaitForSeconds(0.5f);
      player.GetComponent<ThirdPersonController>().enabled = false;
        player.transform.position = _destinationTemp.position;
      yield return new WaitForSeconds(1f);
        cameraRoot.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            
        player.transform.rotation = _destination.rotation;
        player.transform.position = _destination.position;

        // player.transform.GetChild(0).transform.rotation.y = 0f;

        //LookAtPlayer(_destination.name);
        yield return new WaitForSeconds(0.5f);
        player.GetComponent<ThirdPersonController>().enabled = true;
        _fadeCanvas.SetBool("Teleport", false);
   }

    void LookAtPlayer(string destinationName)
    {
        if (destinationName == "ToUniversity")
        {
            Debug.Log(_destination.name);

            // player.transform.GetChild(0).transform.LookAt(TargetLookAt);
          //  Camera.transform.LookAt(TargetLookAt);
         //   player.transform.position = _destination.position;
        }
    }
}

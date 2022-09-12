using System.Collections;
using StarterAssets;
using UnityEngine;

public class Portal : MonoBehaviour
{

   [SerializeField] private Transform _destination;
   [SerializeField] private Transform _destinationTemp;
   [SerializeField] private Animator _fadeCanvas;

   void OnTriggerEnter(Collider other)
   {
      if (other.gameObject.CompareTag("Player"))
      {
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
      player.transform.position = _destination.position;
      yield return new WaitForSeconds(0.5f);
      player.GetComponent<ThirdPersonController>().enabled = true;
      _fadeCanvas.SetBool("Teleport", false);

   }

}

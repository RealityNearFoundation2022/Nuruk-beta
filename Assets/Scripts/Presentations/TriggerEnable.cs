using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnable : MonoBehaviour
{
   [SerializeField] private GameObject canvasController;
   [SerializeField] private GameObject PlayPause;

    void OnTriggerEnter(Collider other)
    {
      canvasController.SetActive(true);
    }

   void OnTriggerExit(Collider other)
   {
      canvasController.SetActive(false);
        if (PlayPause != null)
        {
            PlayPause.SetActive(false);
        }
    }
}

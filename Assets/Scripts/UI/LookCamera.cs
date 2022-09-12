using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookCamera : MonoBehaviour
{
   public Camera ownCamera;

   // Update is called once per frame
   void Update()
   {
      transform.LookAt(transform.position + ownCamera.transform.rotation * Vector3.forward, ownCamera.transform.rotation * Vector3.up);
   }
}

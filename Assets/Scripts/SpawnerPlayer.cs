using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPlayer : MonoBehaviour
{
    public static SpawnerPlayer instance;
    [SerializeField] private Vector3 _destinationTemp;
    private void Awake()
    {
        instance = this;
    }

    public void spawn(Vector3 vector)
    {
        Debug.Log("llego");
        StartCoroutine(FinishTeleport(vector));
        
    }
    
    IEnumerator FinishTeleport(Vector3 playerpos)
    {
        GetComponent<StarterAssets.ThirdPersonController>().enabled = false;
        transform.position = _destinationTemp;
        yield return new WaitForSeconds(1f);
        transform.position = playerpos;
        yield return new WaitForSeconds(0.5f);
        GetComponent<StarterAssets.ThirdPersonController>().enabled = true;
    }

 
}

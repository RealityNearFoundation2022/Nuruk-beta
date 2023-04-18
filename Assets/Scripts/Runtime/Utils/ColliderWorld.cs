using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderWorld : MonoBehaviour
{
    public Transform[] spawners;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collider");
    }
}

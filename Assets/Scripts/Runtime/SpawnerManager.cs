using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField]
    public GameObject[] spawnPoint;
    [SerializeField]
    GameObject mapa;



    private void Start()
    {
      //  spawnPoint = GameObject.FindGameObjectsWithTag("spawnPoint");
    }

    public void SpawnCharacter(int index )
    {
        Debug.Log(index +  "index");
        Vector3 pos = new Vector3(spawnPoint[index].GetComponent<Transform>().position.x, spawnPoint[index].GetComponent<Transform>().position.y, spawnPoint[index].GetComponent<Transform>().position.z);
        SpawnerPlayer.instance.spawn(pos);
    }

    public void closeMap()
    {
        mapa.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        /*if (Input.GetKeyDown("m") && flag)
        {
            Debug.Log("mm");
         //   mapa.SetActive(true);
            SpawnCharacter(0);
            flag = false;
        }*/
        ///open map
        /*if (Input.GetKey(KeyCode.M))
        {
            if (_isMap)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                _isMap = false;
                mapa.SetActive(false);
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                _isMap = true;
                mapa.SetActive(true);
            }
           
        }*/
    }
}

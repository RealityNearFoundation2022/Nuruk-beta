using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomVoiceChannels : MonoBehaviour
{
    private TestHome testHome;
    bool Active = true;
    void Start()
    {
        testHome = FindObjectOfType<TestHome>();
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log(hit.gameObject.name+" entro");
        string nameCol = CustomChannel(hit.gameObject.name);
        string channel = "";
        if (nameCol != "" && Active)
        {
           // nameCol = hit.gameObject.name;
           testHome.onJoinChannel(nameCol,false);
           channel = nameCol;
           Active = false;
           Debug.Log("conecto");
        }
        else if(!Active && (channel != nameCol))
        {
            Active = true;
            testHome.onLeaveButtonClicked();
            Debug.Log("desconecto");
        }
        else
        {
            Debug.Log("sin conexión al canal de audio");
        }
    }

    string CustomChannel(string col)
    {
        if (col.Contains("Plaza_central"))
        {
            return "plazaCentral";
        }
        else if(col.Contains("road_tile"))
        {
            return "calles";
        }
        return "";
    }
}

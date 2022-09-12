using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomVoiceChannels : MonoBehaviour
{
    private TestHome testHome;
    bool plaza = true, calles = true;
    void Start()
    {
        testHome = FindObjectOfType<TestHome>();
    }

    void OnControllerColliderHit(ControllerColliderHit hit) {
      //  Debug.Log(hit.gameObject.name+" entro");
        if (!calles && !hit.gameObject.name.Contains("road_tile"))
        {
            calles = true;
            testHome.onLeaveButtonClicked();
            Debug.Log("desconecto canal calles");

        }
        if (hit.gameObject.name.Contains("Plaza_central") && plaza)
        {
           testHome.onJoinChannel("plazaCentral",false);
           plaza = false;
           Debug.Log("conecto canal plaza");
        }
        else if(!plaza && !hit.gameObject.name.Contains("Plaza_central"))
        {
            plaza = true;
            testHome.onLeaveButtonClicked();
            Debug.Log("desconecto canal plaza");
            if (hit.gameObject.name.Contains("road_tile") && calles)
            {
                testHome.onJoinChannel("calles",false);
                calles = false;
                Debug.Log("conecto canal calles");

            }
        }
    }
}

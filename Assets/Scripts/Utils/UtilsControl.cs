using System.Collections;
using System.Collections.Generic;
using CustomEvents;
using UnityEngine;
using UnityEngine.UI;

public class UtilsControl : MonoBehaviour
{
    public Button[] buttonsUtils;

    void Awake(){
        foreach(Button btn in buttonsUtils)
        {
            if (btn.name == "Bugs")
            {
                btn.onClick.AddListener(ReportBugs);
            }
            Debug.Log(btn.name);
        }
    }
    
    public void ReportBugs()
    {
       // Debug.Log("llego bug");
        Events.ChangeScene.Invoke("Bugs");
    }
}

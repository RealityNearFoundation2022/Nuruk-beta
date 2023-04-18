using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] GameObject MiniTutorial;
    void Start()
    {
        if (MiniTutorial != null)
        {
            if (PlayerPrefs.GetString("MiniTutorial") == "true")
            {
                MiniTutorial.SetActive(true);
                PlayerPrefs.DeleteKey("MiniTutorial");
            }
            else
            {
                MiniTutorial.SetActive(false);
            }
        }
    }
}

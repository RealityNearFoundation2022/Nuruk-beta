using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputTab : MonoBehaviour
{
    public TMP_InputField username;
    public TMP_InputField password;
    public int inputSelected;
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && Input.GetKey(KeyCode.LeftShift))
        {
            inputSelected--;
            if (inputSelected < 0) inputSelected = 2;
            SelectInputField();
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inputSelected++;
            if (inputSelected > 1) inputSelected = 0;
            SelectInputField();
        }

        void SelectInputField()
        {
            switch (inputSelected)
            {
                case 0: username.Select();
                    break;
                case 1: password.Select();
                    break;
            }
        }
    }
    public void UserNameSelected() => inputSelected = 0;
    public void PasswordSelected() => inputSelected = 1;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorkFlow : MonoBehaviour
{

    public void GoTologin()
    {
        SceneManagerControl.Instance.LoadScene("LoginNuruk");
    }
    public void GoToRegister()
    {
        SceneManager.LoadScene("Register");
    }
}

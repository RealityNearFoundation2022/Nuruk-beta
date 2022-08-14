using UnityEngine;
using UnityEngine.SceneManagement;
using CustomEvents;

public class WorkFlow : MonoBehaviour
{

    public void GoTologin()
    {
        //Events.ChangeScene?.Invoke("LoginNuruk");
        SceneManager.LoadScene("LoginNuruk");

    }
    public void GoToRegister()
    {
        SceneManager.LoadScene("Register");
        //Events.ChangeScene?.Invoke("Register");
    }
}

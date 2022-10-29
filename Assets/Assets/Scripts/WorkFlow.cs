using UnityEngine;
using UnityEngine.SceneManagement;
using CustomEvents;

public class WorkFlow : MonoBehaviour
{

    public void GoTologin()
    {
        //SceneManager.LoadScene("LoginNuruk");
        Events.ChangeScene?.Invoke("LoginNuruk");
    }
    public void GoToRegister()
    {
        Events.ChangeScene?.Invoke("Register");
    }
    public void GoToLoginNear()
    {
        Events.ChangeScene?.Invoke("LoginNear");
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;
using CustomEvents;

public class WorkFlow : MonoBehaviour
{
    [DllImport("__Internal")]
    public static extern bool WalletIsSignedIn();
    private void Start()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        if (WalletIsSignedIn())
        {
            GoTologin();
        }
#endif
    }
    public void GoTologin()
    {
        SceneManager.LoadScene("LoginNuruk");
        Debug.Log("login opening");
       // Events.ChangeScene?.Invoke("LoginNuruk");
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

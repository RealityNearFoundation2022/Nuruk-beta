using System.Runtime.InteropServices;
using UnityEngine;
using CustomEvents;
using TMPro;


public class LoginNear : MonoBehaviour
{
    [SerializeField] TMP_InputField userId;
    [SerializeField] GameObject warnignText;
    [DllImport("__Internal")]
    public static extern void Login();
    // [SerializeField] 
    [DllImport("__Internal")]
    private static extern void AccountIdText(string str);

    public void InitLogin()
    {
        // Login();
        warnignText.SetActive(false);

        if (userId.text != "" && userId.text.Contains(".testnet"))
        {
            AccountIdText(userId.text);
        }
        else
        {
            warnignText.SetActive(true);
        }
    }

    public void Register()
    {
        Application.OpenURL("https://wallet.near.org");
    }

    public void GoToNearLogin()
    {
        Events.ChangeScene?.Invoke("UserLoginNear");
    }

}

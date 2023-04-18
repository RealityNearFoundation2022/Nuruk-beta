using System.Collections;
using System.Collections.Generic;
using CustomEvents;
using UnityEngine;
using UnityEngine.UI;
using Proyecto26;
using PlayFab;
using PlayFab.ClientModels;
using Classes;
using TMPro;

public class Register : MonoBehaviour
{
    [SerializeField] TMP_InputField full_name;
    [SerializeField] TMP_InputField email;
    [SerializeField] TMP_InputField password;
    WebNuruk webNuruk;
    DetailError responseErrAuth = new DetailError();
    [SerializeField] Text ErrorMessage;
    bool flag = true;
    void Start()
    {
        webNuruk = gameObject.GetComponent<WebNuruk>();
        ErrorMessage.enabled = false;
    }

    public void RegisterNuruk()
    {
        ErrorMessage.enabled = false;

        if ((full_name.text != "") && (email.text != "") && (password.text != ""))
        {
            webNuruk.Register_Post(full_name.text, email.text, password.text).Then((res) =>
            {
                WebNuruk.User_datos_authRes = res;
                Debug.Log(JsonUtility.ToJson(res));
                PlayerPrefs.SetString("MiniTutorial", "true");
                Log_in();
            }).Catch((err) =>
            {
                Debug.Log("err");
                var error = err as RequestException;
                responseErrAuth = JsonUtility.FromJson<DetailError>(error.Response);
                ErrorMessage.enabled = true;
                ErrorMessage.text = responseErrAuth.detail;
                flag = true;
                full_name.text = "";
                email.text = "";
                password.text = "";
            });
        }
        else
        {
            ErrorMessage.enabled = true;
            ErrorMessage.text = "Fields can't be empty";
        }
    }

    public void Log_in()
    {
        ErrorMessage.enabled = false;

        if ((email.text != "") && (password.text != ""))
        {
            webNuruk.Login_Post(email.text, password.text).Then((res) =>
            {
                WebNuruk.login_Response = res;
                var request = new LoginWithCustomIDRequest { CustomId = email.text, CreateAccount = true };
                PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
            }).Catch((err) =>
            {
                var error = err as RequestException;
                responseErrAuth = JsonUtility.FromJson<DetailError>(error.Response);
                ErrorMessage.enabled = true;
                ErrorMessage.text = responseErrAuth.detail;
            });
        }
        else
        {
            ErrorMessage.enabled = true;
            ErrorMessage.text = "Fields can't be empty";
        }
    }
    
    private void InitializeUser()
    {
        PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                {"CharacterSetup", "{}"},
                {"Tutorial", JsonUtility.ToJson(new TutorialConfig{
                    enable = true
                })},
                {"Configuration", "{}"}
            }
        }, result =>
        {
            Events.ChangeScene.Invoke("CharacterSelect");
        }, error => { });
    }
    
    private void OnLoginSuccess(LoginResult result)
    {
        webNuruk.Login_Post(email.text, password.text).Then((res) =>
        {
            WebNuruk.login_Response = res;
            InitializeUser();
        }).Catch((err) =>
        {
            var error = err as RequestException;
            responseErrAuth = JsonUtility.FromJson<DetailError>(error.Response);
            ErrorMessage.enabled = true;
            ErrorMessage.text = responseErrAuth.detail;
        });
    }

    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogWarning("Something went wrong with your first API call.  :(");
        Debug.LogError("Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Return) && flag)
        {
            if ((email.text != "") && (password.text != "") && (full_name.text != ""))
            {
                 RegisterNuruk();
                flag = false;
            }
        }
    }
}

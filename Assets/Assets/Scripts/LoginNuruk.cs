using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using RSG;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using PlayFab;
using PlayFab.ClientModels;
using CustomEvents;
using Michsky.UI.ModernUIPack;

public class LoginNuruk : MonoBehaviour
{
   [SerializeField] TMP_InputField email;
   [SerializeField] TMP_InputField password;
   DetailError responseErrAuth = new DetailError();
   [SerializeField] Text ErrorMessage;

   [SerializeField] TMP_InputField username;

   public ModalWindowManager modalUsername;

   WebNuruk webNuruk;
   bool _alreadyLogin = false;

   void Start()
   {
      webNuruk = gameObject.GetComponent<WebNuruk>();
      ErrorMessage.enabled = false;
   }

   public void recoveryPass()
   {
      //SceneManager.LoadScene("recoveryPass");
      Events.ChangeScene.Invoke("recoveryPass");
   }

   public void Log_in()
   {
      ErrorMessage.enabled = false;

      if ((email.text != "") && (password.text != ""))
      {
         if (!_alreadyLogin)
         {
            var request = new LoginWithCustomIDRequest { CustomId = email.text };
            PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
            _alreadyLogin = true;
         }
      }
      else
      {
         ErrorMessage.enabled = true;
         ErrorMessage.text = "Fields can't be empty";
      }
   }

   private void OnLoginSuccess(LoginResult result)
   {
      webNuruk.Login_Post(email.text, password.text).Then((res) =>
      {
         WebNuruk.login_Response = res;
         Debug.Log(JsonUtility.ToJson(res));
         
         PlayFabClientAPI.GetUserData(new GetUserDataRequest() {
            Keys = null
            }, result => {
               if (result.Data == null || !result.Data.ContainsKey("Username"))
               {
                  modalUsername.OpenWindow();
               }
               else
               {
               Events.ChangeScene.Invoke("City");
               }
            }, (error) => {
               Debug.Log("Got error retrieving user data:");
               Debug.Log(error.GenerateErrorReport());
            });
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
   
   public void SetUsername()
   {
      //PlayFabClientAPI.UpdateUserTitleDisplayName(new UpdateUserTitleDisplayNameRequest())
      PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest
      {
         Data = new Dictionary<string, string>
         {
            {"Username", string.Format("{{ \"value\": \"{0}\" }}", username.text)},
         }
      }, result =>
      {
         Events.ChangeScene?.Invoke("City");
      }, error => { });
   }
}
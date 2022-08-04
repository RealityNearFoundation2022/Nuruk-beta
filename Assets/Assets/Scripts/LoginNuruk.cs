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
using System;

public class LoginNuruk : MonoBehaviour
{
   [SerializeField] TMP_InputField email;
   [SerializeField] TMP_InputField password;
   DetailError responseErrAuth = new DetailError();
   [SerializeField] Text ErrorMessage;

   WebNuruk webNuruk;
   bool _alreadyLogin = false;

   void Start()
   {
      webNuruk = gameObject.GetComponent<WebNuruk>();
      ErrorMessage.enabled = false;
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
         SceneManagerControl.Instance.LoadScene("City");
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
}

using UnityEngine;
using Proyecto26;
using RSG;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using CustomEvents;

public class RecoveryPassword : MonoBehaviour
{
   [SerializeField] TMP_InputField email;
   DetailError responseErrAuth = new DetailError();
   [SerializeField] Text ErrorMessage;

   private WebNuruk webNuruk;

   void Start()
   {
      webNuruk = gameObject.GetComponent<WebNuruk>();
      ErrorMessage.enabled = false;
   }

   public void GoBack()
   {
      Events.ChangeScene.Invoke("LoginNuruk");
   }

   public void RecoveryPass()
   {
      ErrorMessage.enabled = false;
      if (email.text != "")
      {
         webNuruk.RecoveryPass_Post(email.text).Then((res) =>
         {
            WebNuruk.RecoveryPass_Res = res;
            Debug.Log(JsonUtility.ToJson(res));
            Events.ChangeScene.Invoke("LoginNuruk");
         }).Catch((err) =>
         {
            var error = err as RequestException;
            responseErrAuth = JsonUtility.FromJson<DetailError>(error.Response);
            ErrorMessage.enabled = true;
            ErrorMessage.text = responseErrAuth.detail;
            email.text = "";
         });
      }
      else
      {
         ErrorMessage.enabled = true;
         ErrorMessage.text = "Fields can't be empty";
      }
   }
}
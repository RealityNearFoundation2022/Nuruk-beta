using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using Mirror;
using Classes;

namespace PlayerMirror
{
    public class SetupCharacter : NetworkBehaviour
    {
        private NetworkIdentity nt;
        private CharacterSetup _characterSetup;

        // void sadsa()
        // {
        //     nt.
        // }
        // public override void OnStartClient()
        // {
        //     Debug.Log("Se conecto el personaje");
        //     PlayFabClientAPI.GetUserData(new GetUserDataRequest() {
        //         Keys = null
        //     }, result => {
        //         Debug.Log("Got user data:");
        //         if (result.Data == null || !result.Data.ContainsKey("CharacterSetup"))
        //             Debug.Log("No Character customs");
        //         else _characterSetup = JsonUtility.FromJson<CharacterSetup>(result.Data["CharacterSetup"].Value);
        //     }, (error) => {
        //         Debug.Log("Got error retrieving user data:");
        //         Debug.Log(error.GenerateErrorReport());
        //     });
        // }
        //
        // private void StartSetupPlayer()
        // {
        //     switch (_characterSetup.type)
        //     {
        //         case "Male":
        //             
        //             break;
        //     }
        // }
    }

}

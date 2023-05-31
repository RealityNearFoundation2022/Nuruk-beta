using Player;
using Mirror;
using Nuruk;
using Classes;
using PlayFab;
using UnityEngine;
using PlayerMirror;
using Mirror.Examples.Chat;
using PlayFab.ClientModels;
using System.Collections.Generic;

namespace  City
{
    public class CityNetworkManager : NetworkManager
    {
        [SerializeField]
        private GameObject MenPlayer;
        [Space(3)]
        [SerializeField]
        private GameObject WomenPlayer;

        [Space(3)]
        [SerializeField]
        private GameObject MonsterPlayer;

        [Space(3)]
        // Spawners
        [SerializeField] 
        private Transform[] Spawners;

        private ChatAuthenticator _chatAuthenticator;

        public static List<GameObject> playersConected;
        
        public override void OnStartServer()
        {
            base.OnStartServer();

            NetworkServer.RegisterHandler<CharacterSetup>(OnCreateCharacter);
        }


        public void SetHostname(string hostname) =>
            networkAddress = hostname;

        
        ///<summary>
        /// 
        ///</summary>
        public override void OnClientConnect()
        {
            base.OnClientConnect();

            _chatAuthenticator = GetComponent<ChatAuthenticator>();
            CharacterSetup _characterSetup;

            PlayFabClientAPI.GetUserData(new GetUserDataRequest()
            {
                Keys = null
            }, result => 
            {

                if (result.Data == null || !result.Data.ContainsKey("CharacterSetup"))
                    Debug.Log("No Character customs");
                else
                {
                    _characterSetup = JsonUtility.FromJson<CharacterSetup>(result.Data["CharacterSetup"].Value);

                    NetworkClient.Send(_characterSetup);

                    Debug.Log(_characterSetup.type);
                }

                if (result.Data.ContainsKey("Username"))
                {
                    Debug.Log(JsonUtility.FromJson<Username>(result.Data["Username"].Value).value);

                    PlayerData.username = JsonUtility.FromJson<Username>(result.Data["Username"].Value).value;
                    
                }
            }, (error) =>
                {
                    Debug.Log("Got error retrieving user data:");
                    Debug.Log(error.GenerateErrorReport());
            });
        }

        public override void OnServerDisconnect(NetworkConnectionToClient conn)
        {
            base.OnServerDisconnect(conn);
        }

        private void OnCreateCharacter(NetworkConnectionToClient conn, CharacterSetup message)
        {

            GameObject recipient = null;

            if (message.type == "Male")
            {
                recipient = Instantiate(MenPlayer);

                Debug.Log("Setting player custome");
                if (recipient != null)
                {
                    SetupCharacter setup = recipient.GetComponent<SetupCharacter>();
                    setup.currentShirt = message.shirt;
                    setup.currentHead = message.head;
                    setup.currentPants = message.pants;
                    setup.currentShoes = message.shoes;
                    setup.currentExtra = message.extra;
                    PlayerData.playerCustom = setup;
                    //setup.playerUsername = PlayerData.username;

                }
                Debug.Log("Spawning player Male");
                // call this to use this gameobject as the primary controller
            
            }
            else if (message.type == "Female")
            {
                recipient = Instantiate(WomenPlayer);
            

                Debug.Log("Setting player custome");
                if (recipient != null)
                {
                    SetupCharacter setup = recipient.GetComponent<SetupCharacter>();
                    setup.currentShirt = message.shirt;
                    setup.currentHead = message.head;
                    setup.currentPants = message.pants;
                    setup.currentShoes = message.shoes;
                    setup.currentExtra = message.extra;
                    PlayerData.playerCustom = setup;
                    //setup.playerUsername = PlayerData.username;

                }
                Debug.Log("Spawning player Female");
                // call this to use this gameobject as the primary controller
            
            }
            else if (message.type == "Monster")
            {
                recipient = Instantiate(MonsterPlayer);
            
                Debug.Log("Setting player custome");
                if (recipient != null)
                {
                    SetupCharacter setup = recipient.GetComponent<SetupCharacter>();
                    // setup.currentShirt = message.shirt;
                    // setup.currentHead = message.head;
                    // setup.currentPants = message.pants;
                    // setup.currentShoes = message.shoes;
                    // setup.currentExtra = message.extra;
                    PlayerData.playerCustom = setup;
                    //setup.playerUsername = PlayerData.username;

                }
                Debug.Log("Spawning player Monster");
                // call this to use this gameobject as the primary controller
            }


            recipient.GetComponent<AgoraProxy>().GetChannelUID();
        }
    }
}
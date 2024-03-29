using System.Collections.Generic;
using Classes;
using Mirror;
using Mirror.Examples.Chat;
using PlayerMirror;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using Random = UnityEngine.Random;

namespace  City
{
    public class CityNetworkManager : NetworkManager
    {
        public GameObject MenPlayer;
        public GameObject WomenPlayer;
        public GameObject MonsterPlayer;
        [SerializeField] private GameObject TestPlayer;
        [SerializeField] private bool isTest;
        // Spawners
        [SerializeField] private Transform[] Spawners;

        private ChatAuthenticator _chatAuthenticator;

        public static List<GameObject> playersConected;
        
        public override void OnStartServer()
        {
            base.OnStartServer();
            Debug.Log("Start server");
            //NetworkClient.RegisterPrefab(MenPlayer);
            //NetworkClient.RegisterPrefab(WomenPlayer);
            NetworkServer.RegisterHandler<CharacterSetup>(OnCreateCharacter);
        }
        
        public void SetHostname(string hostname)
        {
            networkAddress = hostname;
        }
        public override void OnClientConnect()
        {
            base.OnClientConnect();
            _chatAuthenticator = GetComponent<ChatAuthenticator>();
            CharacterSetup _characterSetup;
            Debug.Log("Se conecto el personaje");
            PlayFabClientAPI.GetUserData(new GetUserDataRequest() {
                Keys = null
            }, result => {
                Debug.Log("Got user data:");
                if (result.Data == null || !result.Data.ContainsKey("CharacterSetup"))
                    Debug.Log("No Character customs");
                else
                {
                    _chatAuthenticator.SetPlayername("pepitorestrtpo");
                    _characterSetup = JsonUtility.FromJson<CharacterSetup>(result.Data["CharacterSetup"].Value);
                    NetworkClient.Send(_characterSetup);
                    Debug.Log(_characterSetup.type);
                }
            }, (error) => {
                Debug.Log("Got error retrieving user data:");
                Debug.Log(error.GenerateErrorReport());
            });
        }

        public override void OnServerDisconnect(NetworkConnectionToClient conn)
        {
            base.OnServerDisconnect(conn);
        }
        
        void OnCreateCharacter(NetworkConnectionToClient conn, CharacterSetup message)
        {
            GameObject gameobject = Instantiate(playerPrefab);
            
           
            Debug.Log("Setting player custome");
            if (gameobject != null)
            {
                Debug.Log("Vistiendo...");
                SetupCharacter setup = gameobject.GetComponent<SetupCharacter>();
                setup.currentShirt = message.shirt;
                setup.currentHead = message.head;
                setup.currentPants = message.pants;
                setup.currentShoes = message.shoes;
                setup.currentExtra = message.extra;
            }
            Debug.Log("Spawning player");
            // call this to use this gameobject as the primary controller
            NetworkServer.AddPlayerForConnection(conn, gameobject);
        }
    }

}

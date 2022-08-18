using System.Collections.Generic;
using Classes;
using Mirror;
using Mirror.Examples.Chat;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using Random = UnityEngine.Random;

namespace  City
{
    public class CityNetworkManager : NetworkManager
    {

        private bool _alreadyEnter = false;
        [SerializeField] private GameObject MenPlayer;
        [SerializeField] private GameObject WomenPlayer;
        [SerializeField] private GameObject MonsterPlayer;
        [SerializeField] private GameObject TestPlayer;
        [SerializeField] private bool isTest;
        // Spawners
        [SerializeField] private Transform[] Spawners;

        private ChatAuthenticator _chatAuthenticator;

        public static List<GameObject> playersConected;
        
        public override void OnStartServer()
        {
            base.OnStartServer();
            NetworkClient.RegisterPrefab(MenPlayer);
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
            CharacterSetup _characterSetup = new CharacterSetup();
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
            // playerPrefab is the one assigned in the inspector in Network
            // Manager but you can use different prefabs per race for example
            GameObject gameobject = Instantiate(playerPrefab);

            // Apply data from the message however appropriate for your game
            // Typically Player would be a component you write with syncvars or properties
            Debug.Log(message.type);

            // call this to use this gameobject as the primary controller
            NetworkServer.AddPlayerForConnection(conn, gameobject);
            
        }
        
        
        
        
        
        

        
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public struct CreateMMOCharacterMessage : NetworkMessage
{
    public Race race;
    public string name;
    public Color hairColor;
    public Color eyeColor;
}

public enum Race
{
    None,
    Elvish,
    Dwarvish,
    Human
}
public class NetworkSpawn : NetworkManager
{
    public override void OnStartServer()
        {
            base.OnStartServer();
    
            NetworkServer.RegisterHandler<CreateMMOCharacterMessage>(OnCreateCharacter);
        }
    
        public override void OnClientConnect()
        {
            base.OnClientConnect();
    
            // you can send the message here, or wherever else you want
            CreateMMOCharacterMessage characterMessage = new CreateMMOCharacterMessage
            {
                race = Race.Elvish,
                name = "Joe Gaba Gaba",
                hairColor = Color.red,
                eyeColor = Color.green
            };
    
            NetworkClient.Send(characterMessage);
        }
    
        void OnCreateCharacter(NetworkConnectionToClient conn, CreateMMOCharacterMessage message)
        {
            // playerPrefab is the one assigned in the inspector in Network
            // Manager but you can use different prefabs per race for example
            GameObject gameobject = Instantiate(playerPrefab);
    
            // Apply data from the message however appropriate for your game
            // Typically Player would be a component you write with syncvars or properties
            // Player player = gameobject.GetComponent();
            // player.hairColor = message.hairColor;
            // player.eyeColor = message.eyeColor;
            // player.name = message.name;
            // player.race = message.race;
    
            // call this to use this gameobject as the primary controller
            NetworkServer.AddPlayerForConnection(conn, gameobject);
        }
}

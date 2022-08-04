using Mirror;
using UnityEngine;

namespace  City
{
    public class CityNetworkManager : NetworkManager
    {
        [SerializeField] private GameObject MenPlayer;
        [SerializeField] private GameObject WomenPlayer;
        [SerializeField] private GameObject MonsterPlayer;

        // Spawners
        [SerializeField] private Transform[] Spawners;
        
        public override void OnServerAddPlayer(NetworkConnectionToClient conn)
        {
            Transform positionRespawn = Spawners[Random.Range(0, Spawners.Length)];
            GameObject player = Instantiate(playerPrefab, positionRespawn.position, positionRespawn.rotation);
            NetworkServer.AddPlayerForConnection(conn, player);

            
        }

        public override void OnServerDisconnect(NetworkConnectionToClient conn)
        {
            // destroy ball
           

            // call base functionality (actually destroys the player)
            base.OnServerDisconnect(conn);
        }
    }

}

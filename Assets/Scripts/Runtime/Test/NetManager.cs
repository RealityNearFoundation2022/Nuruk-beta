using Mirror;
using UnityEngine;

public class NetManager : NetworkManager
{
        public override void OnServerAddPlayer(NetworkConnectionToClient conn)
        {
            base.OnServerAddPlayer(conn);

            conn.identity.GetComponent<NetworkHelper>().GetChannelUID();

        }
}

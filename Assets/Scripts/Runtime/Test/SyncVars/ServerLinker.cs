using Mirror;
using UnityEngine;


namespace Nuruk.Test
{

    public struct NativeFrame : NetworkMessage
    {
        public uint uid;

        public Transform position;
    }


    /// This is script is mainly modified for server behaviour.
    public class ServerLinker : NetworkManager
    {

        #region Server

        public override void OnServerAddPlayer(NetworkConnectionToClient conn)
        {
            base.OnServerAddPlayer(conn);

            conn.identity.GetComponent<Emissor>().ExternUser();
        }

        #endregion

    }
}

using Mirror;
using UnityEngine;

namespace Nuruk.Test
{
    public class Emissor : NetworkBehaviour
    {

        [ClientRpc]
        public void ExternUser()
        { 
            Debug.Log("A new mate has connected");
        }

    }
}
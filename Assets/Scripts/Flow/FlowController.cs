using CustomEvents;
using UnityEngine;

namespace Flow
{
   public class FlowController : MonoBehaviour
   {
      public void GoToOpening()
      {
         Events.ChangeScene.Invoke("Opening");
      }
   }
}

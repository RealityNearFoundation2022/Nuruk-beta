using CustomEvents;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Flow
{
   public class FlowController : MonoBehaviour
   {
        public void GoToOpening()
        {
            if (PlayerPrefs.GetString("City") == "true")
            {
                GoToCity();
                PlayerPrefs.DeleteKey("City");
            }
            else
            {
                Events.ChangeScene.Invoke("Opening");
            }
        }
        public void GoToLoginNuruk()
        {
            Events.ChangeScene.Invoke("LoginNuruk");
        }
        public void GoToCity()
        {
            SceneManager.UnloadSceneAsync("LoginNear");
        }
    }
}

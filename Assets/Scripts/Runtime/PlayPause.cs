using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Nuruk.Video
{
    public class PlayPause : MonoBehaviour
    {

        [SerializeField]
        private VideoPlayer videoPlayer;

        [SerializeField] 
        private Button pause;
        
        [SerializeField]
        private Button play;


        public void PauseVideo()
        {

            pause.gameObject.SetActive(false);
            play.gameObject.SetActive(true);

        }

        public void PlayVideo()
        {

            pause.gameObject.SetActive(true);
            play.gameObject.SetActive(false);

            // Play the thing

        }
    }
}
using UnityEngine;
using UnityEngine.UI;
using agora_gaming_rtc;

namespace Nuruk.Test
{
    /// Takes the image Surface and push the data.
    public class ScreenActivator : MonoBehaviour
    {

        #region Inspector

        [SerializeField]
        [Tooltip("The Raw image, where the screen cast is going to be pushed.")]
        private RawImage imageSurface;

        [Header("Debug Porpose")]
        [SerializeField]
        private uint entranceID;

        
        [SerializeField,Space(4)]
        private string channelName;

        [SerializeField,Space(4)]
        private string appID;

        #endregion

        private uint uid;

        private IRtcEngine ngin;

        // Is this atril in use?
        private bool portable = true;


        private void OnGUI()
        {

            if(GUI.Button(new Rect(80,340, 120, 45), "Agora Connect"))
            {
                // Creates the IRtc Engine with the App ID.
                ngin = IRtcEngine.GetEngine(appID);

                ngin.EnableAudio();
                ngin.EnableVideo();
                ngin.EnableVideoObserver();

                ngin.OnJoinChannelSuccess += OnJoinChannelSuccess;


                ChannelMediaOptions options = new ChannelMediaOptions()
                {
                    autoSubscribeAudio = true,
                    autoSubscribeVideo = true,
                    publishLocalAudio = true,
                    publishLocalVideo = true,
                };

                ngin.JoinChannel("",channelName, "", 0, options);
            }
        }


        /// Starts the streaming 
        private void OnMouseDown()
        {

            if(!portable)
                return;

            /// Turns false when someone has take it.
            portable = false;

            AdaptImageSurface(channelName,uid);

            ngin.StartScreenCaptureForWeb(true);
        }

        private void OnJoinChannelSuccess(string channel, uint uid, int timeElapsed)
        {
            Debug.Log("Completly Connected");
            this.uid = uid;
        }


        private void AdaptImageSurface(string channel, uint uid)
        {
            ImageSurface streamer = imageSurface.gameObject.AddComponent<ImageSurface>();

            streamer.LoadResources(in imageSurface, 0);
        }
    }
}
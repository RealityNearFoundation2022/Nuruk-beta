using UnityEngine;
using UnityEngine.UI;
using agora_gaming_rtc;

namespace Nuruk.Test
{
    ///<summary>
    /// Streams the screen capture.
    ///</summary>
    public class ImageSurface : MonoBehaviour
    {

        /// The UID from Agora.
        private uint uid;

        /// Raw Image, usually preseted in the game.
        private RawImage surface;

        // Texture that is going to be modified by agora.
        private Texture2D nativeTexture;

#if UNITY_EDITOR || UNITY_WEBGL

        private InSurfaceRenderer surfaceRenderer = new InSurfaceRenderer();

#endif


        ///<summary>
        /// Called when instantiated.
        ///</summary>
        public void LoadResources(in RawImage surface, in uint userUid)
        {
            // Enables set resources.

            uid = userUid;

            this.surface = surface;

            // Creates the texture.
            nativeTexture = new Texture2D(1,1,TextureFormat.ARGB32,false);

            nativeTexture.wrapMode = TextureWrapMode.Clamp;
            nativeTexture.Apply(false,false);

            surface.texture = nativeTexture;
        }


        ///<summary>
        /// Constantly ask for the image data in a late loop.
        ///</summary>
        private void Update()
        {

            if(surface == null)
                return;

#if UNITY_EDITOR || UNITY_WEBGL

            // Locally pushing .
            surfaceRenderer.UpdateTexture(nativeTexture);

#endif

        }
    }
}
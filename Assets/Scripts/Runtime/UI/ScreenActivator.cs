using UnityEngine;

namespace Nuruk
{

    /// 3D Game Object in the scene     
    public class ScreenActivator : MonoBehaviour
    {

        // Is this stand in use?
        private bool portable;

        private void OnMouseDown()
        {
            // Verify portability.

            if(!portable)
                return;

            // Search for the IRtcEngine.
        }
    
        public void OnUserStartScreenCast()
        {
            portable = false;
        }

        public void OnUserStopScreenCast()
        {
            portable = true;
        }
    }
}
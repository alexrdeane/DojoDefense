using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDG
{
    public class Settings : MonoBehaviour
    {
        [AddComponentMenu("TDG/Menu/Settings")]
        #region Vol
        public void SetVolume(float volume)
        {
            //Displays volume (volume doesnt change cause there is no sound in the game)
            Debug.Log(volume);
        }
        #endregion
        #region Qualtiy
        public void SetQuality (int qualityIndex)
        {
            //Changes the inUnity setting for graphics quality via the dropdown
            QualitySettings.SetQualityLevel(qualityIndex);
        }
        #endregion
        #region Full
        public void SetFullScreen (bool isFullScreen)
        {
            //Changes the inUnity setting for full screen resolution via the toggle button
            Screen.fullScreen = isFullScreen;
        }
        #endregion
    }
}


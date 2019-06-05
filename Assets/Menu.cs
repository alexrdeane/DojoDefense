using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TDG
{
    public class Menu : MonoBehaviour
    {
        [AddComponentMenu("TDG/Menu/Menu")]
        #region PlayGame
        public void PlayGame()
        {
            //Changes the scene when button START is pressed
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        #endregion
        #region QuitGame
        public void QuitGame()
        {
            //QUits the application when EXIT button is pressed
            Debug.Log("Quit");
            Application.Quit();
        }
        #endregion
    }
}


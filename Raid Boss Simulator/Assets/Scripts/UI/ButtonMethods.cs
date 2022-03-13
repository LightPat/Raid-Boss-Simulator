using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

namespace LightPat.UI
{
    public class ButtonMethods : NetworkBehaviour
    {
        public void QuitGame()
        {
            Application.Quit();
        }

        public void OpenSettingsMenu()
        {
            Debug.Log("Need to create settings menu");
        }
    }
}
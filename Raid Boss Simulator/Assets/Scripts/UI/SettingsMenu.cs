using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LightPat.UI
{
    public class SettingsMenu : MonoBehaviour
    {
        public void OpenSubMenu(GameObject menuPrefab)
        {
            Instantiate(menuPrefab, transform.parent);

            Destroy(gameObject);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Linq;

namespace LightPat.UI
{
    public class DisplaySettingsMenu : MonoBehaviour
    {
        public TMP_Dropdown resolutionDropdown, fullscreenModeDropdown, graphicsQualityDropdown;

        private FullScreenMode[] fsModes = new FullScreenMode[3];
        private List<Resolution> supportedResolutions = new List<Resolution>();

        private void Start()
        {
            // Resolution Dropdown
            List<string> resolutionOptions = new List<string>();

            int currentResIndex = 0;
            for (int i = 0; i < Screen.resolutions.Length; i++)
            {
                // If the resolution is 16:9
                if ((Screen.resolutions[i].width * 9 / Screen.resolutions[i].height) == 16 & Screen.currentResolution.refreshRate == Screen.resolutions[i].refreshRate)
                {
                    resolutionOptions.Add(Screen.resolutions[i].ToString());
                    supportedResolutions.Add(Screen.resolutions[i]);
                }

                if (Screen.resolutions[i].Equals(Screen.currentResolution))
                {
                    currentResIndex = resolutionOptions.Count - 1;
                }
            }

            resolutionDropdown.AddOptions(resolutionOptions);
            resolutionDropdown.value = currentResIndex;

            // Full screen mode dropdown
            // Dropdown Options are assigned in inspector since these don't vary
            fsModes[0] = FullScreenMode.ExclusiveFullScreen;
            fsModes[1] = FullScreenMode.FullScreenWindow;
            fsModes[2] = FullScreenMode.Windowed;
            int fsModeIndex = Array.IndexOf(fsModes, Screen.fullScreenMode);
            fullscreenModeDropdown.value = fsModeIndex;

            // Graphics Quality dropdown
            graphicsQualityDropdown.AddOptions(QualitySettings.names.ToList());
            graphicsQualityDropdown.value = QualitySettings.GetQualityLevel();
        }

        public void ApplyChanges()
        {
            // Fullscreen Dropdown
            FullScreenMode fsMode = fsModes[fullscreenModeDropdown.value];

            // Resolution Dropdown
            // Options are assigned automatically in OpenSettingsMenu()
            Resolution res = supportedResolutions[resolutionDropdown.value];

            QualitySettings.SetQualityLevel(graphicsQualityDropdown.value, true);

            Screen.SetResolution(res.width, res.height, fsMode, res.refreshRate);
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer AudioMasterMixer;
    public Dropdown ResolutionDropdown;

    Resolution[] Resolutions;
    private void Start()
    {
        Resolutions = Screen.resolutions;

        ResolutionDropdown.ClearOptions();

        List<string> Options = new List<string>();

        int CurrentResolutionIndex = 0;
        for (int i = 0; i < Resolutions.Length; i++)
        {
            string Option = Resolutions[i].width + "x" + Resolutions[i].height;
            Options.Add(Option);

            if (Resolutions[i].width == Screen.currentResolution.width && Resolutions[i].height == Screen.currentResolution.height)
            {
                CurrentResolutionIndex = i;
            }
        }

        ResolutionDropdown.AddOptions(Options);
        ResolutionDropdown.value = CurrentResolutionIndex;
        ResolutionDropdown.RefreshShownValue();
    }

    public void SetAudio (float Audio)
    {
        AudioMasterMixer.SetFloat("Audio", Audio);
    }

    public void SetResolution(int ResolutionIndex)
    {
        Resolution Resolution = Resolutions[ResolutionIndex];
        Screen.SetResolution(Resolution.width, Resolution.height, Screen.fullScreen);
    }

    public void SetQuality (int QualityIndex)
    {
        QualitySettings.SetQualityLevel(QualityIndex);
    }

    public void SetFullscreen(bool IsFullScreen)
    {
        Screen.fullScreen = IsFullScreen;
    }
}

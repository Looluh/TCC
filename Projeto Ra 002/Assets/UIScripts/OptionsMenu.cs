using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityStandardAssets.Utility;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMix;

    private RespawnBrain rB;
    private GameObject FoVSlider;
    private GameObject sfxVolumeSlider;
    private GameObject musicVolumeSlider;
    private float volume;

    Resolution[] resolutions;
    public TMP_Dropdown resolutionDropdown;

    public SmoothFollow cameraScript;
    void Start()
    {
        FoVSlider = GameObject.Find("FoV Slider");
        sfxVolumeSlider = GameObject.Find("SFX Volume Slider");
        musicVolumeSlider = GameObject.Find("Music Volume Slider");
        rB = GameObject.FindGameObjectWithTag("respawnBrain").GetComponent<RespawnBrain>();

        FoVSlider.GetComponent<Slider>().value = rB.height;
        sfxVolumeSlider.GetComponent<Slider>().value = rB.sfxVolume;
        musicVolumeSlider.GetComponent<Slider>().value = rB.musicVolume;

        //SetVolume(volume);
        //SetFoV();

        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();

        int currResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetSFXVolume()
    {
        rB.sfxVolume = GameObject.Find("SFX Volume Slider").GetComponent<Slider>().value;
        audioMix.SetFloat("sfxVolume", rB.sfxVolume);
    }

    public void SetMusicVolume()
    {
        rB.musicVolume = GameObject.Find("Music Volume Slider").GetComponent<Slider>().value;
        audioMix.SetFloat("musicVolume", rB.musicVolume);
    }


    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetFoV()
    {
        //FoVSlider = GameObject.Find("FoV Slider");
        //rB = GameObject.FindGameObjectWithTag("respawnBrain").GetComponent<RespawnBrain>();

        rB.height = GameObject.Find("FoV Slider").GetComponent<Slider>().value;
        if (cameraScript != null)
            cameraScript.UpdateCamera();
    }

}

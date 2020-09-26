using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMix;

    private RespawnBrain rB;
    private GameObject FoVSlider;
    private float volume;

    Resolution[] resolutions;
    public TMP_Dropdown resolutionDropdown;
    void Start()
    {
        FoVSlider = GameObject.Find("FoV Slider");
        rB = GameObject.FindGameObjectWithTag("respawnBrain").GetComponent<RespawnBrain>();

        SetVolume(volume);
        SetFoV();

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

    public void SetVolume(float volume)
    {
        audioMix.SetFloat("Volume", volume);
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
        FoVSlider = GameObject.Find("FoV Slider");
        rB = GameObject.FindGameObjectWithTag("respawnBrain").GetComponent<RespawnBrain>();

        rB.height = GameObject.Find("FoV Slider").GetComponent<Slider>().value;
    }

}

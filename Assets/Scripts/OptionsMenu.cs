using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    Resolution[] resolutions;
    public Dropdown resolutiondropdown;
    public GameObject checkmark;

    void Start()
    {
        resolutions = Screen.resolutions;

        resolutiondropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentresindex = 0;
        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].height == Screen.currentResolution.height && resolutions[i].width == Screen.currentResolution.width)
            {
                currentresindex = i;
            }
        }

        resolutiondropdown.AddOptions(options);
        resolutiondropdown.value = currentresindex;
        resolutiondropdown.RefreshShownValue();
    }

    private void Update()
    {
        checkmark.SetActive(Screen.fullScreen);
    }

    public void setResolution(int resolutionindex)
    {
        Screen.SetResolution(resolutions[resolutionindex].width, resolutions[resolutionindex].height, Screen.fullScreen);
    }
    public void SetVolume(float volume) 
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void setQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void setFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}

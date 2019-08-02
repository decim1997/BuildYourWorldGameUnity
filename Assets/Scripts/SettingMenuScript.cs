using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingMenuScript : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void setVolume(float volume)
    {
        audioMixer.SetFloat("Volume",volume);
    }
    public void setQuality(int qualityindex)
    {
        Debug.Log(qualityindex);
        QualitySettings.SetQualityLevel(qualityindex);
        Debug.Log("NQ: " + QualitySettings.GetQualityLevel());
    }

    public void setFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }


}

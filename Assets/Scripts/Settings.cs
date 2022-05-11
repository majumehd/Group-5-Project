using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class Settings : MonoBehaviour
{
    public Slider volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnVolumeChanged()
    {
        AudioListener.volume = volumeSlider.value;
        PlayerPrefs.SetFloat("MusicVolume", volumeSlider.value);
    }
}
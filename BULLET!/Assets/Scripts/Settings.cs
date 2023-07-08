using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Toggle toggle;
    [SerializeField] TextMeshProUGUI sliderText;
    GameObject menuMusic;
    void Start()
    {
        menuMusic = GameObject.Find("MenuMusic");
        toggle.SetIsOnWithoutNotify(menuMusic.GetComponent<AudioSource>().isPlaying);
        slider.value = menuMusic.GetComponent<AudioSource>().volume * 100;
    }

    void Update()
    {
        if (toggle.isOn)
        {
            menuMusic.GetComponent<AudioSource>().UnPause();
        }
        else if (!toggle.isOn)
        {
            menuMusic.GetComponent<AudioSource>().Pause();
        }

        sliderText.text = slider.value.ToString();
        menuMusic.GetComponent<MenuMusic>().volumeMultiplier = slider.value;
        menuMusic.GetComponent<MenuMusic>().isPlaying = toggle.isOn;
     }
}

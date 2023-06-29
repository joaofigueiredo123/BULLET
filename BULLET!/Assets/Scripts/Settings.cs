using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI sliderText;
    GameObject menuMusic;
    void Start()
    {
        menuMusic = GameObject.Find("MenuMusic");
        slider.value = menuMusic.GetComponent<AudioSource>().volume * 100;
    }

    void Update()
    {
        sliderText.text = slider.value.ToString();
        menuMusic.GetComponent<MenuMusic>().volumeMultiplier = slider.value;
    }
}

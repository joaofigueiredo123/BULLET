using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSettings : MonoBehaviour
{
    AudioSource levelAudioSource;
    [SerializeField] Slider levelMusicSlider;
    [SerializeField] Toggle levelMusicToggle;
    [SerializeField] TextMeshProUGUI sliderText;

    void Start()
    {
        levelAudioSource = GameObject.Find("Level").GetComponent<AudioSource>();
        levelMusicSlider.value = levelAudioSource.volume * 100;
    }

    void Update()
    {
        levelAudioSource.volume = levelMusicSlider.value / 100;
        sliderText.text = levelMusicSlider.value.ToString();

    }
}

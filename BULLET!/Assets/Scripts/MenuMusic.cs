using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMusic : MonoBehaviour
{
    public static MenuMusic instance { get; private set; }
    AudioSource menuMusicAudioSource;
    public float volumeMultiplier, initialVolume;
    public bool isPlaying = true;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        volumeMultiplier = 10.0f;
        menuMusicAudioSource = GetComponent<AudioSource>();
        initialVolume = menuMusicAudioSource.volume;
    }

    private void Update()
    {
        menuMusicAudioSource.volume = initialVolume * (volumeMultiplier / 100);
    }

}

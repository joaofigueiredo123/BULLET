using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    public static MenuMusic instance { get; private set; }
    [SerializeField] AudioClip menuMusic;
    AudioSource menuMusicAudioSource;
    void Start()
    {
        menuMusicAudioSource = GetComponent<AudioSource>();
        menuMusicAudioSource.PlayOneShot(menuMusic, 0.1f);
    }

    void Update()
    {
        
    }

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
}

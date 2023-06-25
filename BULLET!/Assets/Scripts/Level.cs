using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] AudioClip levelMusic;
    AudioSource levelAudioSource;
    GameObject playerReference;
    void Start()
    {
        playerReference = GameObject.Find("Player");

        if (GameObject.Find("MenuMusic"))
        {
            GameObject.Find("MenuMusic").GetComponent<AudioSource>().Pause();
        }
        levelAudioSource = GetComponent<AudioSource>();
        levelAudioSource.PlayOneShot(levelMusic, 0.15f);
    }

    void Update()
    {
        if (playerReference.GetComponent<Player>().isDead)
        {
            levelAudioSource.Stop();
        }
    }
}

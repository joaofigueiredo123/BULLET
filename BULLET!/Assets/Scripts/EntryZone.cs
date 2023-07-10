using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryZone : MonoBehaviour
{
    [SerializeField] GameObject door1, door2;
    [SerializeField] AudioClip bossMusic, mainMusic, deathSound;
    [SerializeField] GameObject bossBar;
    AudioSource levelAudio;
    bool fightStarted = false;
    bool musicIsPlaying = false;
    private void Start()
    {
        levelAudio = GameObject.Find("Level").GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (GameObject.Find("Boss") == null)
        {
            if (!musicIsPlaying)
            {
                door1.SetActive(false);
                door2.SetActive(false);
                StartCoroutine(PlayEndSound(deathSound, mainMusic));
                musicIsPlaying = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Player>(out Player playerScript))
        {
            if (!fightStarted)
            {
                door1.SetActive(true);
                door2.SetActive(true);
                bossBar.SetActive(true);
                PlayLevelMusic(bossMusic);
                fightStarted = true;
            }
        }
    }
    void PlayLevelMusic(AudioClip music)
    {
        levelAudio.Stop();
        levelAudio.loop = true;
        levelAudio.clip = music;
        levelAudio.volume += 0;
        levelAudio.Play();
    }

    IEnumerator PlayEndSound(AudioClip deathSound, AudioClip music)
    {
        levelAudio.Stop();
        levelAudio.PlayOneShot(deathSound, levelAudio.volume);
        yield return new WaitForSeconds(deathSound.length * 0.7f);
        PlayLevelMusic(mainMusic);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryZone : MonoBehaviour
{
    [SerializeField] GameObject door1, door2;
    [SerializeField] AudioClip bossMusic;
    [SerializeField] GameObject bossBar;
    private void Update()
    {
        if (GameObject.Find("Boss").GetComponent<Enemy>().isDead)
        {
            bossBar.SetActive(false);
            door1.SetActive(false);
            door2.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Player>(out Player playerScript))
        {

            door1.SetActive(true);
            door2.SetActive(true);
            this.gameObject.SetActive(false);
            bossBar.SetActive(true);
            PlayBossMusic();
        }
    }

    void PlayBossMusic()
    {
        GameObject.Find("Level").GetComponent<AudioSource>().Stop();
        GameObject.Find("Level").GetComponent<AudioSource>().loop = true;
        GameObject.Find("Level").GetComponent<AudioSource>().clip = bossMusic;
        GameObject.Find("Level").GetComponent<AudioSource>().volume += 0;
        GameObject.Find("Level").GetComponent<AudioSource>().Play();
    }
}

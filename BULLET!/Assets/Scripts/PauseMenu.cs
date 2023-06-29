using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuUI;
    AudioSource levelSoundSource, playerSoundSource;
    void Start()
    {
        levelSoundSource = GameObject.Find("Level").GetComponent<AudioSource>();
        playerSoundSource = GameObject.Find("Player").GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pauseMenuUI.active)
            {
                PauseLevel();
            }
            else if (pauseMenuUI.active)
            {
                ResumeLevel();
            }
        }
    }

    public void ResumeLevel()
    {
        Time.timeScale = 1.0f;
        levelSoundSource.UnPause();
        playerSoundSource.UnPause();
        pauseMenuUI.SetActive(false);
    }

    public void PauseLevel()
    {
        Time.timeScale = 0.0f;
        levelSoundSource.Pause();
        playerSoundSource.Pause();
        pauseMenuUI.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuUI, levelSettingsUI;
    AudioSource levelSoundSource, playerSoundSource;
    [SerializeField] Toggle musicToggle;
    PowerupTimer powerupTimer;
    void Start()
    {
        levelSoundSource = GameObject.Find("Level").GetComponent<AudioSource>();
        playerSoundSource = GameObject.Find("Player").GetComponent<AudioSource>();
        powerupTimer = GameObject.Find("PlayerUICanvas").GetComponent<PowerupTimer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pauseMenuUI.active)
            {
                if (!levelSettingsUI.active)
                {
                    PauseLevel();
                }
                else if (levelSettingsUI.active)
                {
                    CloseSettings();
                }
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
        if (powerupTimer.hasStarted)
        {
            powerupTimer.timerOn = true;
        }
        if (musicToggle.isOn)
        {
            levelSoundSource.UnPause();
            playerSoundSource.UnPause();
        }
        else if (!musicToggle.isOn)
        {
            levelSoundSource.Pause();
            playerSoundSource.Pause();
        }
        pauseMenuUI.SetActive(false);
    }

    public void PauseLevel()
    {
        Time.timeScale = 0.0f;
        powerupTimer.timerOn = false;
        levelSoundSource.Pause();
        playerSoundSource.Pause();
        pauseMenuUI.SetActive(true);
    }

    public void OpenSettings()
    {
        pauseMenuUI.SetActive(false);
        levelSettingsUI.SetActive(true);
    }
    public void CloseSettings()
    {
        pauseMenuUI.SetActive(true);
        levelSettingsUI.SetActive(false);
    }
}

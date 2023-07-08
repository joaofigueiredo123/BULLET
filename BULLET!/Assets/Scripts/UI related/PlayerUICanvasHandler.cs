using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class PlayerUICanvasHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bulletCountText, coinCountText;
    [SerializeField] GameObject gameOverUI, mainGameUI, weaponAmmoUI;
    [SerializeField] GameObject[] hearthContainers, emptyHearthContainers, containers;
    [SerializeField] GameObject[] powerupIcons;
    public int coinCount = 0;
    private void Start()
    {
        UpdateCoinCount(0);
    }
    public void UpdateBulletCount(int currentBulletCount, int magSize)
    {
        bulletCountText.text = currentBulletCount + "/" + magSize;
    }

    public void UpdateCoinCount(int count)
    {
        coinCount = coinCount + count;
        coinCountText.text = "x" + coinCount.ToString();
    }

    public void UpdateHealthCount(int health)
    {
        if (health <= 0)
        {
            for (int i = 0; i < 7; i++)
            {
                hearthContainers[i].SetActive(false);
                emptyHearthContainers[i].SetActive(true);
            }
            return;
        }

        switch (health)
        {
            case 1:
                for (int i = 0; i < 1; i++)
                {
                    hearthContainers[i].SetActive(true);
                    emptyHearthContainers[i].SetActive(false);
                }
                for (int i = 1; i < 7; i++)
                {
                    hearthContainers[i].SetActive(false);
                    emptyHearthContainers[i].SetActive(true);
                }
                break;

            case 2:
                for (int i = 0; i < 2; i++)
                {
                    hearthContainers[i].SetActive(true);
                    emptyHearthContainers[i].SetActive(false);
                }
                for (int i = 2; i < 7; i++)
                {
                    hearthContainers[i].SetActive(false);
                    emptyHearthContainers[i].SetActive(true);
                }
                break;

            case 3:
                for (int i = 0; i < 3; i++)
                {
                    hearthContainers[i].SetActive(true);
                    emptyHearthContainers[i].SetActive(false);
                }
                for (int i = 3; i < 7; i++)
                {
                    hearthContainers[i].SetActive(false);
                    emptyHearthContainers[i].SetActive(true);
                }
                break;

            case 4:
                for (int i = 0; i < 4; i++)
                {
                    hearthContainers[i].SetActive(true);
                    emptyHearthContainers[i].SetActive(false);
                }
                for (int i = 4; i < 7; i++)
                {
                    hearthContainers[i].SetActive(false);
                    emptyHearthContainers[i].SetActive(true);
                }
                break;

            case 5:
                for (int i = 0; i < 5; i++)
                {
                    hearthContainers[i].SetActive(true);
                    emptyHearthContainers[i].SetActive(false);
                }
                for (int i = 5; i < 7; i++)
                {
                    hearthContainers[i].SetActive(false);
                    emptyHearthContainers[i].SetActive(true);
                }
                break;

            case 6:
                for (int i = 0; i < 6; i++)
                {
                    hearthContainers[i].SetActive(true);
                    emptyHearthContainers[i].SetActive(false);
                }
                for (int i = 6; i < 7; i++)
                {
                    hearthContainers[i].SetActive(false);
                    emptyHearthContainers[i].SetActive(true);
                }
                break;

            case 7:
                for (int i = 0; i < 7; i++)
                {
                    hearthContainers[i].SetActive(true);
                    emptyHearthContainers[i].SetActive(false);
                }
                for (int i = 7; i < 7; i++)
                {
                    hearthContainers[i].SetActive(false);
                    emptyHearthContainers[i].SetActive(true);
                }
                break;


            default:
                break;
        }
    }

    public void UpdateContainers(int health)
    {
        for (int i = 0; i < health; i++)
        {
            containers[i].SetActive(true);
        }
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void EnableWeaponAmmoUI(bool state)
    {
        weaponAmmoUI.SetActive(state);
    }

    public void EnablePowerupUI(int index, bool state)
    {
        powerupIcons[index].SetActive(state);
    }


}

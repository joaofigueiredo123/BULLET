using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.SceneManagement;
using DG.Tweening;

public class PlayerUICanvasHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bulletCountText, coinCountText;
    [SerializeField] GameObject gameOverUI, mainGameUI, weaponAmmoUI;
    [SerializeField] GameObject[] hearthContainers, emptyHearthContainers; 
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
        if (health == 0)
        {
            for (int i = 0; i < 3; i++)
            {
                hearthContainers[i].SetActive(false);
                emptyHearthContainers[i].SetActive(true);
            }
            return;
        }

        switch (health)
        {
            case 1:
                hearthContainers[0].SetActive(true);
                hearthContainers[1].SetActive(false);
                hearthContainers[2].SetActive(false);

                emptyHearthContainers[0].SetActive(false);
                emptyHearthContainers[1].SetActive(true);
                emptyHearthContainers[2].SetActive(true);
                break;
            case 2:
                hearthContainers[0].SetActive(true);
                hearthContainers[1].SetActive(true);
                hearthContainers[2].SetActive(false);

                emptyHearthContainers[0].SetActive(false);
                emptyHearthContainers[1].SetActive(false);
                emptyHearthContainers[2].SetActive(true);
                break;
            default:
                break;
        }
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void RestartLevel()
    {
        EditorSceneManager.LoadScene(EditorSceneManager.GetActiveScene().buildIndex);
    }

    public void EnableWeaponAmmoUI(bool state)
    {
        weaponAmmoUI.SetActive(state);
    }

    
}

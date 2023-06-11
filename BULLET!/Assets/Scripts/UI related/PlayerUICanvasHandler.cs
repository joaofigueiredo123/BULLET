using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.SceneManagement;

public class PlayerUICanvasHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthCountText, bulletCountText, coinCountText;
    [SerializeField] GameObject gameOverUI, mainGameUI, weaponAmmoUI;
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

    public void UpdateHealthCount()
    {

    }

    public void GameOver()
    {
        mainGameUI.SetActive(false);
        gameOverUI.SetActive(true);
    }

    public void RestartLevel()
    {
        EditorSceneManager.LoadScene(3);
    }

    public void EnableWeaponAmmoUI(bool state)
    {
        weaponAmmoUI.SetActive(state);
    }
}

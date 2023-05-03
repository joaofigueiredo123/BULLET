using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUICanvasHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthCountText, bulletCountText, coinCountText;
    public int coinCount = 0;
    private void Start() {
        UpdateCoinCount(0);
    }
    public void UpdateBulletCount(int currentBulletCount, int magSize)
    {
        bulletCountText.text = currentBulletCount + "/" + magSize;
    }

    public void UpdateCoinCount(int count){
        coinCount = coinCount + count;
        coinCountText.text = "Moedas: " + coinCount; 
    }

    public void UpdateHealthCount()
    {

    }
}

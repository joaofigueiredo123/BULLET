using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUICanvasHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthCountText, bulletCountText, coinCountText;
    private void Start() {
        coinCountText.text = "Moedas: 0";
    }
    public void UpdateBulletCount(int currentBulletCount, int magSize)
    {
        bulletCountText.text = currentBulletCount + "/" + magSize;
    }

    public void UpdateCoinCount(){
        coinCountText.text = "Moedas: "; 
    }

    public void UpdateHealthCount()
    {

    }
}

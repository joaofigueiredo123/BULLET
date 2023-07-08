using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerupTimer : MonoBehaviour
{
    float timeLeft;
    public bool timerOn = false;
    public bool hasStarted = false;
    public TextMeshProUGUI powerupTimerText;
   
    void Start()
    {
        timeLeft = 15;
    }

    void Update()
    {
        if(timerOn)
        {
            hasStarted = true;
            if(timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                UpdateTimer(timeLeft);
            }
            else
            {
                Debug.Log("Powerup has ended");
                timeLeft = 0;
                timerOn = false;
                powerupTimerText.enabled = false;
            }
        }
    }

    void UpdateTimer(float currentTime)
    {
        currentTime += 1;

        float seconds = Mathf.FloorToInt(currentTime % 60);

        powerupTimerText.text = string.Format("{0:00}", seconds);
    }

}

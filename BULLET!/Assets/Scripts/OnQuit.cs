using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnQuit : MonoBehaviour
{

    public void QuitGame()
    {
        Application.Quit();
    }

    private void OnApplicationQuit() {
        
    }
}

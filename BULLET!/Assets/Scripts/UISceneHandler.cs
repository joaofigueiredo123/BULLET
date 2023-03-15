using UnityEngine;
using UnityEditor.SceneManagement;

public class UISceneHandler : MonoBehaviour
{
    public static UISceneHandler instance { get; private set; }

    private void Awake() {
        if(instance != null) {
            Debug.LogError("Foi encontrada mais do que uma instância de UISceneHandler na cena.");
        }
        instance = this;
    }

    public void PlayGame(){
        EditorSceneManager.LoadScene("Game");
    }

    public void Settings(){
        EditorSceneManager.LoadScene("Settings");
    }

    public void Saves(){
        EditorSceneManager.LoadScene("Saves");
    }
}

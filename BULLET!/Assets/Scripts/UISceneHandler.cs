using UnityEngine;
using UnityEditor.SceneManagement;

public class UISceneHandler : MonoBehaviour
{
    public static UISceneHandler instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Foi encontrada mais do que uma instância de UISceneHandler na cena.");
        }
        instance = this;
    }

    public static void SceneMainMenu()
    {
        // MainMenu
        EditorSceneManager.LoadScene(0);
    }

    public static void SceneSaves()
    {
        // Saves
        EditorSceneManager.LoadScene(1);
    }

    public static void SceneCharacters()
    {
        // Characters
        EditorSceneManager.LoadScene(2);
    }

    public static void SceneGame()
    {
        // Game
        EditorSceneManager.LoadScene(3);
    }

    public static void SceneSettings()
    {
        // Settings
        EditorSceneManager.LoadScene(4);
    }
}

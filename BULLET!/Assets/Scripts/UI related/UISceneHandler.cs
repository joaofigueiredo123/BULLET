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

    public static void SceneSettings()
    {
        // Settings
        EditorSceneManager.LoadScene(3);
    }

    public static void SceneStatistics()
    {

        // Statistics
        EditorSceneManager.LoadScene(4);
    }

    public static void SceneUpgrades()
    {

        // Statistics
        EditorSceneManager.LoadScene(7);
    }

    public static void SceneLevelMenu()
    {

        // Levels menu
        EditorSceneManager.LoadScene(5);
        if (!GameObject.Find("MenuMusic").GetComponent<AudioSource>().isPlaying)
        {
            GameObject.Find("MenuMusic").GetComponent<AudioSource>().Play();
        }

    }

    public static void SceneLevel1()
    {

        // Level 1
        EditorSceneManager.LoadScene("Level 1");
    }
    public static void SceneLevel2()
    {

        // Level 2
        EditorSceneManager.LoadScene("Level 2");
    }
    public static void SceneLevel3()
    {

        // Level 3
        EditorSceneManager.LoadScene("Level 3");
    }

}

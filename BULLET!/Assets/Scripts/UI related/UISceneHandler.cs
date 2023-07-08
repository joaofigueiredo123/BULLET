using UnityEngine;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene(0);
    }

    public static void SceneSaves()
    {
        // Saves
        SceneManager.LoadScene(1);
    }

    public static void SceneCharacters()
    {
        // Characters
        SceneManager.LoadScene(2);
    }

    public static void SceneSettings()
    {
        // Settings
        SceneManager.LoadScene(3);
    }

    public static void SceneStatistics()
    {

        // Statistics
        SceneManager.LoadScene(4);
    }

    public static void SceneUpgrades()
    {

        // Upgrades
        SceneManager.LoadScene(5);
    }

    public static void SceneLevelMenu()
    {

        // Levels menu
        SceneManager.LoadScene(6);
        
        if (!GameObject.Find("MenuMusic").GetComponent<AudioSource>().isPlaying)
        {
            GameObject.Find("MenuMusic").GetComponent<AudioSource>().Play();

            if (GameObject.Find("MenuMusic").GetComponent<MenuMusic>().isPlaying)
            {
                GameObject.Find("MenuMusic").GetComponent<AudioSource>().UnPause();
            }
            else if (!GameObject.Find("MenuMusic").GetComponent<MenuMusic>().isPlaying)
            {
                GameObject.Find("MenuMusic").GetComponent<AudioSource>().Pause();
            }
        }
    }

    public static void SceneLevel1()
    {

        // Level 1
        SceneManager.LoadScene("Level 1");
    }
    public static void SceneLevel2()
    {

        // Level 2
        SceneManager.LoadScene("Level 2");
    }
    public static void SceneLevel3()
    {

        // Level 3
        SceneManager.LoadScene("Level 3");
    }

}

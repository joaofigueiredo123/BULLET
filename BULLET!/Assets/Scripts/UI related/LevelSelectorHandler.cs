using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectorHandler : MonoBehaviour
{
    [SerializeField] GameObject[] levelLockIcons, levelIcons;
    void Start()
    {
        int level = GameObject.Find("DDOLIds").GetComponent<SaveIDs>().level;
        UpdateLevelsUI(level);
    }

    void Update()
    {

    }

    void UpdateLevelsUI(int level)
    {
        switch (level)
        {
            case 1:
                levelLockIcons[0].SetActive(false);
                levelLockIcons[1].SetActive(true);
                levelLockIcons[2].SetActive(true);
                levelIcons[0].SetActive(true);
                levelIcons[1].SetActive(false);
                levelIcons[2].SetActive(false);
                break;
            case 2:
                levelLockIcons[0].SetActive(false);
                levelLockIcons[1].SetActive(false);
                levelLockIcons[2].SetActive(true);
                levelIcons[0].SetActive(true);
                levelIcons[1].SetActive(true);
                levelIcons[2].SetActive(false);
                break;
            case 3:
            default:
                levelLockIcons[0].SetActive(false);
                levelLockIcons[1].SetActive(false);
                levelLockIcons[2].SetActive(false);
                levelIcons[0].SetActive(true);
                levelIcons[1].SetActive(true);
                levelIcons[2].SetActive(true);
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterMenuUIHandler : MonoBehaviour
{
    int savefileID;
    int characterID;
    int level;
    string playerName;
    [SerializeField] GameObject characterCards;
    [SerializeField] GameObject playerNameUI;
    // private void Start()
    // {
    //     playerNameUI = GameObject.Find("PlayerNameUI");
    //     playerNameUI.SetActive(false);
    // }
    public void DisableCharactersCardsEnablePlayerNameUI()
    {
        characterCards.SetActive(false);
        playerNameUI.SetActive(true);
    }

    public void ConfirmPlayerName()
    {
        savefileID = GameObject.Find("DDOLIds").GetComponent<SaveIDs>().savefileID;
        characterID = GameObject.Find("DDOLIds").GetComponent<SaveIDs>().characterID;
        playerName = GameObject.Find("PlayerName_InputField").GetComponent<TMP_InputField>().text;
        HandleGameData.InsertSaveFileData(savefileID, characterID, playerName, 0, 0, 1);
        HandleGameData.InsertStatistics(savefileID, 0, 0, 0, 0, 0);
        HandleGameData.InsertUpgrades(savefileID, 0, 0, 0, 0);
        UISceneHandler.SceneLevelMenu();
    }
}

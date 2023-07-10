using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System.IO;
using TMPro;

public class End : MonoBehaviour
{
    [SerializeField] int levelID;
    private static string dbPath = "URI=file:./gameDB.db";
    int saveID, playerLevel;
    PlayerUICanvasHandler playerUI;
    void Start()
    {
        saveID = GameObject.Find("DDOLIds").GetComponent<SaveIDs>().savefileID;
        playerUI = GameObject.Find("PlayerUICanvas").GetComponent<PlayerUICanvasHandler>();
        playerLevel = GetLevel(saveID);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Player>(out Player player))
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (playerLevel == levelID)
                {
                    UpdateLevel(saveID, 1);
                    playerLevel = GetLevel(saveID);
                    GameObject.Find("DDOLIds").GetComponent<SaveIDs>().level = playerLevel;
                }
                
                UpgradesManager.UpdateBalance(saveID, playerUI.coinCount);
                UISceneHandler.SceneLevelMenu();
            }
        }
    }

    int GetLevel(int saveID)
    {
        IDbConnection dbConnection = OpenConnection();

        IDbCommand query = dbConnection.CreateCommand();
        string query_Level = "SELECT level FROM save_files WHERE id = " + saveID + "";
        query.CommandText = query_Level;
        IDataReader reader = query.ExecuteReader();

        int level = Convert.ToInt16(reader[0]);

        dbConnection.Close();

        return level;
    }
    public static void UpdateLevel(int save_id, int amount)
    {
        IDbConnection dbConnection = OpenConnection();

        IDbCommand query = dbConnection.CreateCommand();
        string query_UpdateLevel = "UPDATE save_files SET level = level + " + amount + " WHERE id = " + save_id + "";
        query.CommandText = query_UpdateLevel;
        query.ExecuteNonQuery();

        dbConnection.Close();
    }
    private static IDbConnection OpenConnection()
    {
        IDbConnection dbConnection = new SqliteConnection(dbPath);
        dbConnection.Open();
        return dbConnection;
    }
}

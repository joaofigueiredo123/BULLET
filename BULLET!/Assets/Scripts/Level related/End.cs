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
    int saveID;
    void Start()
    {
        saveID = GameObject.Find("DDOLIds").GetComponent<SaveIDs>().savefileID;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Player>(out Player player))
        {
            Debug.Log("tá a tocar");
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("wtfffasdasdasd");
                if (GetLevel(saveID) == levelID)
                {
                    UpdateLevel(saveID, 1);
                    GameObject.Find("DDOLIds").GetComponent<SaveIDs>().level = GetLevel(saveID);
                }
                
                UpgradesManager.UpdateBalance(saveID, GameObject.Find("PlayerUICanvas").GetComponent<PlayerUICanvasHandler>().coinCount);
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

        return Convert.ToInt16(reader[0]);
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

using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using System.Globalization;
using System;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System.IO;
using TMPro;
public class HandleGameData : MonoBehaviour
{
    // public static HandleGameData instance {get; private set;}
    [SerializeField] int savefileID;
    [SerializeField] int characterID;
    string playerName;
    private static string dbPath = "URI=file:./gameDB.db";

    // private void Awake()
    // {
    //     if (instance != null)
    //     {
    //         Destroy(gameObject);
    //         return;
    //     }
    //     instance = this;
    // }

    public void HandleSaveFiles()
    {
        if (!File.Exists(@"gameDB.db"))
        {
            Debug.Log("Creating data base...");
            CreateDataBase();
            GameObject.Find("DDOLIds").GetComponent<SaveIDs>().savefileID = savefileID;
            UISceneHandler.SceneCharacters();
        }
        else if (File.Exists(@"gameDB.db"))
        {
            if (!CheckSavefileExistance(savefileID))
            {
                Debug.Log("Data base is already created...");
                GameObject.Find("DDOLIds").GetComponent<SaveIDs>().savefileID = savefileID;
                UISceneHandler.SceneCharacters();

            }
            else if (CheckSavefileExistance(savefileID))
            {
                Debug.Log("Save file already exists, so loading data...");
                LoadSaveFileData(savefileID);
                UISceneHandler.SceneGame();
            }
        }
    }

    private void CreateDataBase()
    {
        IDbConnection dbConnection = OpenConnection();

        IDbCommand query = dbConnection.CreateCommand();
        string query_CreateTableSaveFiles = "CREATE TABLE IF NOT EXISTS save_files(id INTEGER PRIMARY KEY, id_char INTEGER, username VARCHAR(30), playtime INTEGER, stage VARCHAR(30), coins INTEGER);";
        query.CommandText = query_CreateTableSaveFiles;
        query.ExecuteReader();

        query = dbConnection.CreateCommand();
        string query_CreateTableCharacters = "CREATE TABLE IF NOT EXISTS characters(id INTEGER PRIMARY KEY, name VARCHAR(30), class VARCHAR(30));";
        query.CommandText = query_CreateTableCharacters;
        query.ExecuteReader();

        InsertCharacters();

        dbConnection.Close();
    }

    public static void InsertSaveFileData(int savefileID, int characterID, string username, int playtime, string stage, int coins)
    {
        IDbConnection dbConnection = OpenConnection();

        IDbCommand query = dbConnection.CreateCommand();
        query.CommandText = "INSERT INTO save_files(id, id_char, username, playtime, stage, coins) VALUES (@savefileID, @characterID, @username, @playtime, @stage, @coins)";
        query.Parameters.Add(new SqliteParameter("@savefileID", savefileID));
        query.Parameters.Add(new SqliteParameter("@characterID", characterID));
        query.Parameters.Add(new SqliteParameter("@username", username));
        query.Parameters.Add(new SqliteParameter("@playtime", playtime));
        query.Parameters.Add(new SqliteParameter("@stage", stage));
        query.Parameters.Add(new SqliteParameter("@coins", coins));
        query.ExecuteNonQuery();

        dbConnection.Close();
    }
    private void LoadSaveFileData(int savefileID)
    {
    }

    private void UpdateGameData(string username, int playtime, string stage, int coins)
    {
        IDbConnection dbConnection = OpenConnection();

        IDbCommand query = dbConnection.CreateCommand();
        query.CommandText = "INSERT OR REPLACE INTO player (username, playtime, stage, coins) VALUES (@username, @playtime, @stage, @coins)";
        query.ExecuteNonQuery();

        dbConnection.Close();
    }
    private bool CheckSavefileExistance(int savefileID)
    {
        IDbConnection dbConnection = OpenConnection();

        IDbCommand query = dbConnection.CreateCommand();
        string query_VerifyExistance = "SELECT id FROM save_files WHERE id = " + savefileID + "";
        query.CommandText = query_VerifyExistance;
        IDataReader reader = query.ExecuteReader();

        return reader[0].ToString().Equals(savefileID.ToString());
    }

    private void InsertCharacters()
    {
        IDbConnection dbConnection = OpenConnection();

        IDbCommand query = dbConnection.CreateCommand();
        query.CommandText = "INSERT INTO characters(id, name, class) VALUES (1, 'character1', 'class1')";
        query.Parameters.Add(new SqliteParameter("@id", 1));
        query.Parameters.Add(new SqliteParameter("@name", "character1"));
        query.Parameters.Add(new SqliteParameter("@class", "class1"));
        query.ExecuteNonQuery();

        query = dbConnection.CreateCommand();
        query.CommandText = "INSERT INTO characters(id, name, class) VALUES (2, 'character2', 'class2')";
        query.Parameters.Add(new SqliteParameter("@id", 2));
        query.Parameters.Add(new SqliteParameter("@name", "character2"));
        query.Parameters.Add(new SqliteParameter("@class", "class2"));
        query.ExecuteNonQuery();

        query = dbConnection.CreateCommand();
        query.CommandText = "INSERT INTO characters(id, name, class) VALUES (3, 'character3', 'class3')";
        query.Parameters.Add(new SqliteParameter("@id", 3));
        query.Parameters.Add(new SqliteParameter("@name", "character3"));
        query.Parameters.Add(new SqliteParameter("@class", "class3"));
        query.ExecuteNonQuery();

        query = dbConnection.CreateCommand();
        query.CommandText = "INSERT INTO characters(id, name, class) VALUES (4, 'character4', 'class4')";
        query.Parameters.Add(new SqliteParameter("@id", 4));
        query.Parameters.Add(new SqliteParameter("@name", "character4"));
        query.Parameters.Add(new SqliteParameter("@class", "class4"));
        query.ExecuteNonQuery();

        dbConnection.Close();
    }
    public void SelectCharacter()
    {
        GameObject.Find("DDOLIds").GetComponent<SaveIDs>().characterID = characterID;
        GameObject.Find("ChractersCanvas").GetComponent<CharacterMenuUIHandler>().DisableCharactersCardsEnablePlayerNameUI();
    }


    private static IDbConnection OpenConnection()
    {
        IDbConnection dbConnection = new SqliteConnection(dbPath);
        dbConnection.Open();
        return dbConnection;
    }

}

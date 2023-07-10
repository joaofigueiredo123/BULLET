using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System.IO;
using TMPro;

public class SaveButtonsText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] buttonsText;
    private static string dbPath = "URI=file:./gameDB.db";
    void Start()
    {
        if (File.Exists(@"gameDB.db"))
        {
            for (int i = 1; i < 5; i++)
            {
                if (CheckSavefileExistance(i))
                {
                    buttonsText[i - 1].text = "Jogo de " + GetUsername(i) + "   Nivel: " + GetLevel(i);
                }
            }
        }
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

    string GetUsername(int saveID)
    {
        IDbConnection dbConnection = OpenConnection();

        IDbCommand query = dbConnection.CreateCommand();
        string query_Username = "SELECT username FROM save_files WHERE id = " + saveID + "";
        query.CommandText = query_Username;
        IDataReader reader = query.ExecuteReader();

        return reader[0].ToString();
    }
    string GetLevel(int saveID)
    {
        IDbConnection dbConnection = OpenConnection();

        IDbCommand query = dbConnection.CreateCommand();
        string query_Username = "SELECT level FROM save_files WHERE id = " + saveID + "";
        query.CommandText = query_Username;
        IDataReader reader = query.ExecuteReader();

        return reader[0].ToString();
    }
    private static IDbConnection OpenConnection()
    {
        IDbConnection dbConnection = new SqliteConnection(dbPath);
        dbConnection.Open();
        return dbConnection;
    }

}

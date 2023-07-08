using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System.IO;
using TMPro;

public class UpgradesManager : MonoBehaviour
{
    private static string dbPath = "URI=file:./gameDB.db";
    int savefileID;
    [SerializeField] GameObject[] upgrade1Icons, upgrade2Icons, upgrade3Icons, upgrade4Icons;
    [SerializeField] TextMeshProUGUI balanceText;
    int maxUpgradeLevel = 4, upgradeCost = 3;
    void Start()
    {
        savefileID = GameObject.Find("DDOLIds").GetComponent<SaveIDs>().savefileID;

        UpdateBalanceText();

        UpdateUpgrades();
    }

    void UpdateUpgrades()
    {
        for (int i = 1; i < 5; i++)
        {
            int index = GetUpgradeLevel(savefileID, i);

            for (int j = 0; j < index; j++)
            {
                switch (i)
                {
                    case 1:
                        upgrade1Icons[j].SetActive(true);
                        break;

                    case 2:
                        upgrade2Icons[j].SetActive(true);
                        break;

                    case 3:
                        upgrade3Icons[j].SetActive(true);
                        break;

                    case 4:
                        upgrade4Icons[j].SetActive(true);
                        break;
                }
            }
        }
    }

    public void Upgrade1()
    {
        if (GetBalance(savefileID) >= upgradeCost)
        {
            if (GetUpgradeLevel(savefileID, 1) < maxUpgradeLevel)
            {
                UpdateUpgradeLevel(savefileID, 1, 1);
                UpdateBalance(savefileID, -3);
                UpdateBalanceText();
            }
        }
    }

    public void Upgrade2()
    {
        if (GetBalance(savefileID) >= upgradeCost)
        {
            if (GetUpgradeLevel(savefileID, 2) < maxUpgradeLevel)
            {
                UpdateUpgradeLevel(savefileID, 2, 1);
                UpdateBalance(savefileID, -3);
                UpdateBalanceText();
            }
        }
    }

    public void Upgrade3()
    {
        if (GetBalance(savefileID) >= upgradeCost)
        {
            if (GetUpgradeLevel(savefileID, 3) < maxUpgradeLevel)
            {
                UpdateUpgradeLevel(savefileID, 3, 1);
                UpdateBalance(savefileID, -3);
                UpdateBalanceText();
            }
        }
    }

    public void Upgrade4()
    {
        if (GetBalance(savefileID) >= upgradeCost)
        {
            if (GetUpgradeLevel(savefileID, 4) < maxUpgradeLevel)
            {
                UpdateUpgradeLevel(savefileID, 4, 1);
                UpdateBalance(savefileID, -3);
                UpdateBalanceText();

            }
        }
    }

    public static int GetUpgradeLevel(int saveID, int upgradeID)
    {
        string upgradeLevelString = "upgrade" + upgradeID + "_level";

        IDbConnection dbConnection = OpenConnection();

        IDbCommand query = dbConnection.CreateCommand();
        string query_Upgrade = "SELECT " + upgradeLevelString + " FROM upgrades WHERE id = " + saveID + "";
        query.CommandText = query_Upgrade;
        IDataReader reader = query.ExecuteReader();

        int level = Convert.ToInt32(reader[0]);

        dbConnection.Close();

        return level;
    }

    public void UpdateUpgradeLevel(int saveID, int upgradeID, int amount)
    {
        IDbConnection dbConnection = OpenConnection();

        IDbCommand query = dbConnection.CreateCommand();
        string upgradeLevelString = "upgrade" + upgradeID + "_level";
        string query_UpdateUpgrade = "UPDATE upgrades SET " + upgradeLevelString + " = " + upgradeLevelString + " + " + amount + " WHERE id = " + saveID + "";
        query.CommandText = query_UpdateUpgrade;
        query.ExecuteNonQuery();

        dbConnection.Close();

        UpdateUpgrades();
    }

    int GetBalance(int saveID)
    {
        IDbConnection dbConnection = OpenConnection();

        IDbCommand query = dbConnection.CreateCommand();
        string query_Balance = "SELECT coins FROM save_files WHERE id = " + saveID + "";
        query.CommandText = query_Balance;
        IDataReader reader = query.ExecuteReader();

        int balance = Convert.ToInt32(reader[0]);

        dbConnection.Close();

        return balance;
    }

    static public void UpdateBalance(int saveID, int amount)
    {
        IDbConnection dbConnection = OpenConnection();

        IDbCommand query = dbConnection.CreateCommand();
        string query_UpdateBalance = "UPDATE save_files SET coins = coins + " + amount + " WHERE id = " + saveID + "";
        query.CommandText = query_UpdateBalance;
        query.ExecuteNonQuery();

        dbConnection.Close();
    }

    void UpdateBalanceText()
    {
        balanceText.text = "Saldo: " + GetBalance(savefileID);
    }

    private static IDbConnection OpenConnection()
    {
        IDbConnection dbConnection = new SqliteConnection(dbPath);
        dbConnection.Open();
        return dbConnection;
    }


}

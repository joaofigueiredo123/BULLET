using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System.IO;
using TMPro;

public class Statistics : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] statisticsTexts1, statisticsTexts2, statisticsTexts3, statisticsTexts4;
    [SerializeField] GameObject[] panels;
    private static string dbPath = "URI=file:./gameDB.db";
    List<statistic> statistics;
    public struct statistic
    {
        public int id;
        public int coins;
        public int kills;
        public int deaths;
        public int shots;
        public int jumps;

    }
    void Start()
    {
        statistics = GetStatistics();

        foreach (statistic s in statistics)
        {
            switch (s.id)
            {
                case 1:
                        statisticsTexts1[0].text += s.id.ToString();
                        statisticsTexts1[1].text += s.coins.ToString();
                        statisticsTexts1[2].text += s.kills.ToString();
                        statisticsTexts1[3].text += s.deaths.ToString();
                        statisticsTexts1[4].text += s.shots.ToString();
                        statisticsTexts1[5].text += s.jumps.ToString();
                        // statisticsTexts1[6].text += s.id.ToString();
                    break;
                case 2:
                        statisticsTexts2[0].text += s.id.ToString();
                        statisticsTexts2[1].text += s.coins.ToString();
                        statisticsTexts2[2].text += s.kills.ToString();
                        statisticsTexts2[3].text += s.deaths.ToString();
                        statisticsTexts2[4].text += s.shots.ToString();
                        statisticsTexts2[5].text += s.jumps.ToString();
                        // statisticsTexts2[6].text += s.id.ToString();
                    break;
                case 3:
                        statisticsTexts3[0].text += s.id.ToString();
                        statisticsTexts3[1].text += s.coins.ToString();
                        statisticsTexts3[2].text += s.kills.ToString();
                        statisticsTexts3[3].text += s.deaths.ToString();
                        statisticsTexts3[4].text += s.shots.ToString();
                        statisticsTexts3[5].text += s.jumps.ToString();
                        // statisticsTexts3[6].text += s.id.ToString();
                    break;
                case 4:
                        statisticsTexts4[0].text += s.id.ToString();
                        statisticsTexts4[1].text += s.coins.ToString();
                        statisticsTexts4[2].text += s.kills.ToString();
                        statisticsTexts4[3].text += s.deaths.ToString();
                        statisticsTexts4[4].text += s.shots.ToString();
                        statisticsTexts4[5].text += s.jumps.ToString();
                        // statisticsTexts4[6].text += s.id.ToString();
                    break;
                default:
                    break;
            }
        }
    }


    public List<statistic> GetStatistics()
    {
        List<statistic> output = new List<statistic>();

        IDbConnection dbConnection = OpenConnection();

        IDbCommand query = dbConnection.CreateCommand();
        string query_Statistics = "SELECT * FROM stats";
        query.CommandText = query_Statistics;
        IDataReader reader = query.ExecuteReader();

        while (reader.Read())
        {
            statistic r;
            r.id = Convert.ToInt32(reader[0]);
            r.coins = Convert.ToInt32(reader[1]);
            r.kills = Convert.ToInt32(reader[2]);
            r.deaths = Convert.ToInt32(reader[3]);
            r.shots = Convert.ToInt32(reader[4]);
            r.jumps = Convert.ToInt32(reader[5]);

            output.Add(r);
        }

        dbConnection.Close();

        return output;
    }

    private static IDbConnection OpenConnection()
    {
        IDbConnection dbConnection = new SqliteConnection(dbPath);
        dbConnection.Open();
        return dbConnection;
    }

}

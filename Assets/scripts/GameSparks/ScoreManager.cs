using System;
using System.Collections.Generic;
using GameSparks.Api.Requests;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static void SendScore(int score)
    {
        new LogEventRequest().SetEventKey("SendScore")
            .SetEventAttribute("Time", (long)score)
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
                    Debug.Log("Score Posted Successfully...");
                }
                else
                {
                    Debug.Log("Error Posting Score...");
                }
            });
    }

    public static void GetScore(Action<List<LeaderboardEntry>> callback, int EntryCount = 100)
    {
        new LeaderboardDataRequest().SetLeaderboardShortCode("Time").SetEntryCount(EntryCount).Send((response) =>
        {
            if (!response.HasErrors)
            {
                var list = new List<LeaderboardEntry>();
                Debug.Log("Found Leaderboard Data...");
                foreach (GameSparks.Api.Responses.LeaderboardDataResponse._LeaderboardData entry in response.Data)
                {
                    var resultentry = new LeaderboardEntry();
                    
                    resultentry.Rank = (int) entry.Rank;
                    resultentry.PlayerName = entry.UserName;
                    resultentry.Time = Convert.ToInt32(entry.JSONData["Time"]);

                    list.Add(resultentry);
                }

                callback(list);
            }
            else
            {
                Debug.LogError("Error Retrieving Leaderboard Data...");
            }
        });

    }
}

public class LeaderboardEntry {
    public int Rank;
    public string PlayerName;
    public int Time;
}
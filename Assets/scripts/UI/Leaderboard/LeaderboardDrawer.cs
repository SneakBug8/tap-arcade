using System.Collections.Generic;
using UnityEngine;

public class LeaderboardDrawer : MonoBehaviour {
    public GameObject LeaderboardEntryPref;
    public Transform EntriesParent;

    private void Start() {
        ScoreManager.GetScore(Draw, 10);
        Debug.Log("Drawing leaderboard");
    }

    void Draw(List<LeaderboardEntry> entries) {
        Debug.Log("Got " + entries.Count + " entries.");
        
        foreach (var entry in entries) {
            var gobject = Instantiate(LeaderboardEntryPref, EntriesParent);
            var entryobject = gobject.GetComponent<LeaderboardEntryObject>();
            entryobject.Nickname.text = entry.Rank + ". " + entry.PlayerName;
            entryobject.Score.text = entry.Time.ToString();
        }
    }
}
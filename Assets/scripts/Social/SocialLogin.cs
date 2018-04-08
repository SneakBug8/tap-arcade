using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class SocialLogin : MonoBehaviour
{
    void OnEnable()
    {
        Debug.Log("Social login");

        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder()
            .Build();

        PlayGamesPlatform.InitializeInstance(config);
        // recommended for debugging:
        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();

        PlayGamesPlatform.Instance.localUser.Authenticate(ProcessAuthentication);
    }

    void ProcessAuthentication(bool success, string error)
    {
        if (success)
        {
            Debug.Log("Authenticated, checking achievements");

            // Social.ShowLeaderboardUI("CgkI7fzbh-QdEAIQAA");

            // Request loaded achievements, and register a callback for processing them
            Social.LoadAchievements(ProcessLoadedAchievements);
        }
        else
            Debug.Log("Failed to authenticate: " + error);
    }

    void ProcessLoadedAchievements(IAchievement[] achievements)
    {
        if (achievements.Length == 0)
            Debug.Log("Error: no achievements found");
        else
            Debug.Log("Got " + achievements.Length + " achievements. Loading scores");


        Social.LoadScores("Leaderboard01", ProcessScores);
    }

    void ProcessScores(IScore[] scores)
    {
        if (scores.Length > 0)
        {
            Debug.Log("Got " + scores.Length + " scores");
            string myScores = "Leaderboard:\n";
            foreach (IScore score in scores)
                myScores += "\t" + score.userID + " " + score.formattedValue + " " + score.date + "\n";
            Debug.Log(myScores);

            Social.ShowLeaderboardUI();
        }
        else
            Debug.Log("No scores loaded");
    }
}
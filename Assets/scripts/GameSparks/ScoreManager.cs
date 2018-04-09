using UnityEngine;

public class ScoreManager : MonoBehaviour {
    public static void SendScore(int score) {
        new GameSparks.Api.Requests.LogEventRequest().SetEventKey("SendScore")
			.SetEventAttribute("Time", (long) score)
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
}
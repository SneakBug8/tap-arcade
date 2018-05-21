using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Outdated button to bypass login
/// </summary>
public class OfflineButton : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            GameSparksManager.Instance.UseGameSparks = false;
            LoginManager.Instance.BypassLogin();
        });
    }
}
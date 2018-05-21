using UnityEngine;
using UnityEngine.UI;

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
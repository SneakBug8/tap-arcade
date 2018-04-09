using UnityEngine;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;

public class LoginManager : MonoBehaviour
{
    bool RequestedAuth = false;

    public GameObject GameSparks;
    private void Update()
    {
        if (GameSparks.GetComponent<GameSparks.Platforms.PlatformBase>() == null) {
            return;
        }

        Auth();
    }

    void Auth() {
        if (RequestedAuth) {
            return;
        }

        RequestedAuth = true;

        new DeviceAuthenticationRequest().Send((response) =>
        {
            if (!response.HasErrors)
            {
                Debug.Log("Device Authenticated...");
                Destroy(gameObject);
            }
            else
            {
                Debug.LogError("Error Authenticating Device...");
                Destroy(gameObject);
            }
        });
    }
}

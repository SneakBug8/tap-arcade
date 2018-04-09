using UnityEngine;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;

public class LoginManager : MonoBehaviour
{
    string AuthToken;
    private void Update()
    {
        new DeviceAuthenticationRequest().Send((response) =>
        {
            if (!response.HasErrors)
            {
                Debug.Log("Device Authenticated...");
                AuthToken = response.AuthToken;
            }
            else
            {
                Debug.Log("Error Authenticating Device...");
            }
        });

        Destroy(gameObject);
    }
}

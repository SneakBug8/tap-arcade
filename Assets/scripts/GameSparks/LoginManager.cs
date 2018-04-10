using UnityEngine;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;
using System;

public class LoginManager : MonoBehaviour
{
    bool RequestedAuth = false;

    public GameObject GameSparks;

    public static void Auth(Action<bool> callback) {
        new DeviceAuthenticationRequest().Send((response) =>
        {
            if (!response.HasErrors)
            {
                Debug.Log("Device Authenticated...");
                callback(true);
            }
            else
            {
                Debug.LogError("Error Authenticating Device...");
                callback(false);
            }
        });
    }

    public static void Auth(Action<bool> callback, string facebooktoken) {
        new FacebookConnectRequest().SetAccessToken(facebooktoken).Send((response) => 
        {
            if (!response.HasErrors)
            {
                Debug.Log("Facebook Authenticated...");
                callback(true);
            }
            else
            {
                Debug.LogError("Error Authenticating Facebook...");
                callback(false);
            }
        });
    }
}

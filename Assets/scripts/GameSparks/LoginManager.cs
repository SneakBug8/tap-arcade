using UnityEngine;
using UnityEngine.SceneManagement;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;
using System;

public class LoginManager : MonoBehaviour
{
    public string SceneAfterLogin;
    public static LoginManager Instance;
    private void Awake() {
        Instance = this;
    }

    private void Start() {
        GameSparksManager.Instance.OnGameSparksInitializationCompleted.AddListener(AutoAuth);
    }

/// <summary>
/// Try to login and register automatically
/// </summary>
    private void AutoAuth() {
        if (PlayerPrefs.HasKey("login")) {
            Debug.Log(PlayerPrefs.GetString("login"));
            Login(Instance.Success, BypassLogin);
        }
        else {
            Register(SystemInfo.deviceUniqueIdentifier, SystemInfo.deviceUniqueIdentifier, Instance.Success, BypassLogin);
        }
    }
    public static void Login(Action success, Action error = null)
    {
        var login = PlayerPrefs.GetString("login");
        Login(login, success, error);
    }

    public static void Login(string login, Action success, Action error = null)
    {
        Login(login, SystemInfo.deviceUniqueIdentifier, success);
    }

    static void Login(string login, string password, Action success, Action<string, string> error = null)
    {
        new AuthenticationRequest()
            .SetUserName(login)
            .SetPassword(password)
            .Send((response) =>
            {
                if (response.HasErrors)
                {
                    error(login, password);
                    Debug.LogError(response.Errors);
                }
                else
                {
                    Debug.Log("Successful login");
                    PlayerPrefs.SetString("login", login);
                    success();
                }
            });
    }

/// <summary>
/// Change player's displayname for leadrboard
/// </summary>
/// <param name="displayname">New display name</param>
/// <param name="success">callback for success</param>
/// <param name="error">callback for error</param>
    public static void SetDisplayName(string displayname, Action success, Action error = null) {
        new ChangeUserDetailsRequest()
        .SetDisplayName(displayname)
        .Send(response => {
            if (!response.HasErrors) {
                success();
                PlayerPrefs.SetInt("DisplayNameSet", 1);
            }
            else {
                Debug.LogError(response.Errors);
                error();
            }
        });
    }

    static void Register(string login, string password, Action success, Action error = null) {
        new RegistrationRequest()
            .SetUserName(login)
            .SetPassword(SystemInfo.deviceUniqueIdentifier)
            .Send((response) =>
            {
                if (response.HasErrors)
                {
                    Debug.LogError(response.Errors);
                    if (error != null) {
                        error();
                    }
                }
                else
                {
                    Debug.Log("Successful registration");
                    PlayerPrefs.SetString("login", SystemInfo.deviceUniqueIdentifier);
                    success();
                }
            });
    }

/// <summary>
/// Bypass auth in case of errors
/// </summary>
    public void BypassLogin() {
        GameSparksManager.Instance.UseGameSparks = false;
        Success();
    }

    public void Success() {
        Debug.Log("Successful login");
        SceneManager.LoadScene(SceneAfterLogin);
    }
}

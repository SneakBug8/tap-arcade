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
        GameSparksManager.Instance.OnGameSparksInitializationCompleted.AddListener(TryAutoLogin);
    }

    private void TryAutoLogin() {
        if (PlayerPrefs.HasKey("login")) {
            Debug.Log(PlayerPrefs.HasKey("login"));
            Login(PlayerPrefs.GetString("login"));
        }
    }
    public static void Login(Action<string> registrationerror = null)
    {
        var login = new System.Guid().ToString();
        Login(login, registrationerror);
    }

    public static void Login(string login, Action<string> registrationerror = null)
    {
        Login(login, SystemInfo.deviceUniqueIdentifier, Instance.Success, 
        (s1, s2) => Register(s1, s2, Instance.Success, registrationerror));
    }

    static void Login(string login, string password, Action success, Action<string, string> error = null)
    {
        new AuthenticationRequest()
            .SetUserName(login)
            .SetPassword(SystemInfo.deviceUniqueIdentifier)
            .Send((response) =>
            {
                if (response.HasErrors)
                {
                    if (error != null) {
                        error(login, password);
                    }
                    else {
                        Debug.LogError(response.Errors);
                    }
                }
                else
                {
                    Debug.Log("Successful login");
                    PlayerPrefs.SetString("login", login);
                    success();
                }
            });
    }

    static void Register(string login, string password, Action success, Action<string> error = null) {
        new RegistrationRequest()
            .SetUserName(login)
            .SetDisplayName(login)
            .SetPassword(SystemInfo.deviceUniqueIdentifier)
            .Send((response) =>
            {
                if (response.HasErrors)
                {
                    if (error != null) {
                        error(login);
                    }
                    else {
                        Debug.LogError(response.Errors);
                    }
                }
                else
                {
                    Debug.Log("Successful registration");
                    success();
                }
            });
    }

    public void BypassLogin() {
        Success();
    }

    void Success() {
        Debug.Log("Success");
        SceneManager.LoadScene(SceneAfterLogin);
    }
}

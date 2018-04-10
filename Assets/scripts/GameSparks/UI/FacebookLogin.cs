using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Facebook.Unity;
using System.Collections.Generic;

[RequireComponent(typeof(Button))]
public class FacebookLogin : MonoBehaviour
{
    public string SceneAfterLogin;
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }
    void OnClick()
    {
        if (PlayerPrefs.HasKey("facebook_token"))
        {
            LoginManager.Auth(OnLogin, PlayerPrefs.GetString("facebook_token"));
        }
        else if (!FB.IsInitialized)
        {
            // Initialize the Facebook SDK
            FB.Init(InitCallback, OnHideUnity);
        }
        else
        {
            FB.ActivateApp();
            ShowLoginUI();
        }
    }

    private void InitCallback()
    {
        if (FB.IsInitialized)
        {
            FB.ActivateApp();
            ShowLoginUI();
        }
        else
        {
            Debug.Log("Failed to Initialize the Facebook SDK");
        }
    }

    private void OnHideUnity(bool isGameShown)
    {
        if (!isGameShown)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    void ShowLoginUI()
    {
        var perms = new List<string>() { "public_profile", "email" };
        FB.LogInWithReadPermissions(perms, AuthCallback);
    }

    private void AuthCallback(ILoginResult result)
    {
        if (FB.IsLoggedIn)
        {
            // AccessToken class will have session details
            var aToken = Facebook.Unity.AccessToken.CurrentAccessToken;

            PlayerPrefs.SetString("facebook_token", aToken.UserId);

            LoginManager.Auth(OnLogin, aToken.UserId);
        }
        else
        {
            Debug.Log("User cancelled login");
        }
    }

    void OnLogin(bool result)
    {
        if (result)
        {
            SceneManager.LoadScene(SceneAfterLogin);
        }
        else
        {
            PlayerPrefs.DeleteKey("facebook_token");
        }
    }
}
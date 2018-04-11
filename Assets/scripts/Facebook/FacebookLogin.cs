using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Facebook.Unity;
using System.Collections.Generic;
using System;

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
            // LoginManager.Auth(OnLogin, PlayerPrefs.GetString("facebook_token"));
            throw new NotImplementedException("Autologin in FB");
        }
        else
        {
            ShowLoginUI();
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

            LoginManager.Auth(aToken.UserId);
        }
        else
        {
            Debug.Log("User cancelled login");
        }
    }

    void OnLogin()
    {
        SceneManager.LoadScene(SceneAfterLogin);
    }
}
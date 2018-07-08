using System;
using TwitterKit.Unity;

using UnityEngine;

public class TwitterLogin : MonoBehaviour
{
    public void StartLogin(Action<TwitterSession> successcallback)
    {
        Twitter.Init();

        TwitterSession session = Twitter.Session;
        if (session == null)
        {
            Twitter.LogIn(successcallback, LoginFailure);
        }
        else
        {
            LoginComplete(session);
        }
    }

    public void LoginComplete(TwitterSession session)
    {
        // Start composer or request email
    }

    public void LoginFailure(ApiError error)
    {
        UnityEngine.Debug.Log("code=" + error.code + " msg=" + error.message);
    }
}
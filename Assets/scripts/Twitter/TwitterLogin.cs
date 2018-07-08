using TwitterKit.Unity;

using UnityEngine;

public class TwitterLogin : MonoBehaviour
{
    private void Start()
    {
        Twitter.Init();
    }

    public void StartLogin()
    {
        TwitterSession session = Twitter.Session;
        if (session == null)
        {
            Twitter.LogIn(LoginComplete, LoginFailure);
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
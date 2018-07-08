using UnityEngine;
using UnityEngine.UI;
// using Facebook.Unity;
using TwitterKit.Unity;
#if UNITY_ADS
using UnityEngine.Advertisements;
#endif

public class AdsButton : MonoBehaviour
{
    Button button;
    Text ButtonText;
    int usedTimes = 0;

    private void Awake()
    {
#if !UNITY_ADS
        Destroy(this.gameObject);
#endif

        ButtonText = GetComponentInChildren<Text>();
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void Update()
    {
        switch (usedTimes)
        {
            case 0:
                if (Advertisement.IsReady("rewardedVideo"))
                {
                    button.interactable = true;
                }
                else
                {
                    button.interactable = false;
                }
                break;
            case 1:
                button.interactable = true;
                break;
            default:
                button.interactable = false;
                break;
        }

    }

    void OnClick()
    {
        if (usedTimes == 0)
        {
            ShowAd();
        }
        else if (usedTimes == 1)
        {
            ShareDialog();
        }
    }

    void ShowAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions();
            options.resultCallback = AdCallback;
            Advertisement.Show("rewardedVideo", options);
        }

        ChangeTextToShare();
    }

    void AdCallback(ShowResult result)
    {
        if (result == ShowResult.Finished)
        {
            GivePlayerNewChance();
            usedTimes++;
        }
    }

    void ChangeTextToShare()
    {
        ButtonText.text = "Share to continue";
    }

    void ShareDialog()
    {
        Twitter.Compose(Twitter.Session, "", "Best game ever! Check it out: https://sneakbug8.com/tap-arcade", new string[] { "#TapArcade" },
              (string tweetId) =>
              {
                  UnityEngine.Debug.Log("Tweet Success, tweetId = " + tweetId);
                  GivePlayerNewChance();
                  usedTimes++;
              },
              (ApiError error) =>
              {
                  UnityEngine.Debug.Log("Tweet Failed " + error.message);
              },
              () =>
              {
                  Debug.Log("Compose cancelled");
              }
      );
        /*
        FB.FeedShare(
            link: new System.Uri("https://sneakbug8.com"),
            linkName: "Checkout this awesome game",
            callback: ShareCallback
        );
        */
    }
    /*
    void ShareCallback(IShareResult result)
    {
        if (!result.Cancelled && result.Error == null)
        {
            GivePlayerNewChange();
            usedTimes++;
        }
    }
    */

    void GivePlayerNewChance()
    {
        LostMenu.Global.gameObject.SetActive(false);
        LevelController.Global.Resume();
    }
}
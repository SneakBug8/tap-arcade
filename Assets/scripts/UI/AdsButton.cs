using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
// using Facebook.Unity;
#if UNITY_ADS
using UnityEngine.Advertisements;

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

    private void OnEnable()
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

    void GivePlayerNewChance()
    {
        LostMenu.Global.gameObject.SetActive(false);
        LevelController.Global.Resume();
    }
}
#endif

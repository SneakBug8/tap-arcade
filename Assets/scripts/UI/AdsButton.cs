using UnityEngine;
using UnityEngine.UI;
#if UNITY_ADS
using UnityEngine.Advertisements;
#endif

public class AdsButton : MonoBehaviour {
    Button button;
    bool wasUsed = false;

    private void Awake() {
        #if !UNITY_ADS
        Destroy(this.gameObject);
        #endif

        button = GetComponent<Button>();
        button.onClick.AddListener(ShowAd);
    }

    private void Update() {
        if (Advertisement.IsReady("rewardedVideo") && !wasUsed) {
            button.interactable = true;
        }
        else {
            button.interactable = false;
        }
    }

    void ShowAd() {
        if (Advertisement.IsReady("rewardedVideo")) {
            var options = new ShowOptions();
            options.resultCallback = AdCallback;
            Advertisement.Show("rewardedVideo", options);
            wasUsed = true;
        }
    }

    void AdCallback(ShowResult result) {
        if (result == ShowResult.Finished) {
            LostMenu.Global.gameObject.SetActive(false);
            LevelController.Global.Resume();
        }
    }
}
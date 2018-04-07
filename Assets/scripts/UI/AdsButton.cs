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
        if (!Advertisement.IsReady("rewardedVideo")) {
            button.interactable = false;
        }
        
        if (wasUsed) {
            Destroy(gameObject);         
        }
        else {
            button.interactable = true;
        }
    }

    void ShowAd() {
        Debug.Log("Showing ad");
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
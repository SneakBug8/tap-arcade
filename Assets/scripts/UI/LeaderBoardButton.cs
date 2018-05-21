using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LeaderBoardButton : MonoBehaviour {
    public string Scene;
    private void Start() {
        if (GameSparksManager.Instance.UseGameSparks) {
            GetComponent<Button>().onClick.AddListener(ChangeScene);
        }
        else {
            GetComponent<Button>().interactable = false;
        }
    }

    void ChangeScene() {
        SceneManager.LoadScene(Scene);
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneButton : MonoBehaviour {
    public string Scene;
    private void Start() {
        GetComponent<Button>().onClick.AddListener(ChangeScene);
    }

    void ChangeScene() {
        SceneManager.LoadScene(Scene);
    }
}
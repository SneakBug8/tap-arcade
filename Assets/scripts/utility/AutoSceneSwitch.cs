using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoSceneSwitch : MonoBehaviour {
    public string Scene;

    private void Update() {
        foreach (var gameobject in GameObject.FindObjectsOfType<Transform>()) {
            if (gameobject.hideFlags != HideFlags.DontSave && gameobject != gameObject) {
                return;
            }
        }
        
        SceneManager.LoadScene(Scene);
    }
}
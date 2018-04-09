using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoSceneSwitch : MonoBehaviour {
    public string Scene;

    private void Update() {
        foreach (var gameobject in GameObject.FindObjectsOfType<GameObject>()) {
            if (gameobject.GetComponent<GameSparks.Platforms.PlatformBase>() == null && gameobject != gameObject) {
                return;
            }
        }
        
        SceneManager.LoadScene(Scene);
    }
}
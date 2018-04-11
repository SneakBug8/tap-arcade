using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoSceneSwitch : MonoBehaviour {
    public string Scene;

    public List<GameObject> ImmutableObjects;
    private void Update() {
        foreach (var gameobject in GameObject.FindObjectsOfType<GameObject>()) {
            if (!ImmutableObjects.Contains(gameobject) && gameobject != gameObject) {
                return;
            }
        }
        
        SceneManager.LoadScene(Scene);
    }
}
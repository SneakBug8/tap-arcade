using UnityEngine;

public class GameSparksManager : MonoBehaviour {
    public static GameSparksManager Manager;

    private void Awake() {
        if (Manager == null) {
            Manager = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }
}
using GameSparks.Platforms;
using UnityEngine;
using UnityEngine.Events;

public class GameSparksManager : MonoBehaviour {
    public static GameSparksManager Instance;
    public GameObject GameSparks;
    public UnityEvent OnGameSparksInitializationCompleted = new UnityEvent();
    public bool UseGameSparks = true;

    PlatformBase Platform;
    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }

    private void Update() {
        if (Platform != null) {
            return;
        }

        Platform = GameSparks.GetComponent<PlatformBase>();

        if (Platform != null) {
            Debug.Log("Initialization completed");
            OnGameSparksInitializationCompleted.Invoke();
        }
    }
}
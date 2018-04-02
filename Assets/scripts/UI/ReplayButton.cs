using UnityEngine;
using UnityEngine.UI;

public class ReplayButton : MonoBehaviour {
    private void Start() {
        GetComponent<Button>().onClick.AddListener(Replay);
    }

    void Replay() {
        LevelController.Global.Restart();
    }
}
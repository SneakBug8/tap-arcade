using UnityEngine;

public class LoseMenu : MonoBehaviour {
    public static LoseMenu Global;

    private void Awake() {
        Global = this;
        gameObject.SetActive(false);
    }
}
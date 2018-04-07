using UnityEngine;
using UnityEngine.Events;

public class LostMenu : MonoBehaviour {
    public static LostMenu Global;
    private void Awake() {
        Global = this;
        gameObject.SetActive(false);
    }

    public UnityEvent OnDraw = new UnityEvent();
}
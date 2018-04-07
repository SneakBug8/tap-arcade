using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour {
    private void Start() {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    void OnClick() {
        Application.Quit();
    }
}
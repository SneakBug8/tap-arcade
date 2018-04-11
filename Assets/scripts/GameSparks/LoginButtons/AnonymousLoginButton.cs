using UnityEngine;
using UnityEngine.UI;

public class AnonymousLoginButton : MonoBehaviour {
    private void Start() {
        GetComponent<Button>().onClick.AddListener(() => LoginManager.Auth());
    }
}
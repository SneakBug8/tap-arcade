using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class FacebookLogin : MonoBehaviour {
    public string SceneAfterLogin;
    private void Start() {
        GetComponent<Button>().onClick.AddListener(() => LoginManager.Auth(OnLogin));
    }

    void OnLogin(bool result) {
        if (result) {
            SceneManager.LoadScene(SceneAfterLogin);
        }
    }
}
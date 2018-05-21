using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Outdated button to enter with DeviceID
/// </summary>
public class AnonymousLoginButton : MonoBehaviour {
    private void Start() {
        GetComponent<Button>().onClick.AddListener(() => LoginManager.Login(LoginManager.Instance.Success, () => {}));
    }
}
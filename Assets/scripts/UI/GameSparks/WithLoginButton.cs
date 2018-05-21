using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Outdated button to login with login set in input field
/// </summary>

public class WithLoginButton : MonoBehaviour {
    public Button Button;
    public InputField Input;
    public Text PlaceHolder;
    private void Start() {
        Button.onClick.AddListener(() => {
            if (Input.text != "") {
                LoginManager.Login(Input.text, RegistrationError);
                Input.text = "";
            }
            else {
                PlaceHolder.text = "Please, enter valid login";
                Input.text = "";
            }
        });
    }
 
    void RegistrationError() {
        PlaceHolder.text = "This login is already taken";
        Input.text = "";
    }
}
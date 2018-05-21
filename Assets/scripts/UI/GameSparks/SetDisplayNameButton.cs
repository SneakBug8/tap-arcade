using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Button, used to set Display Name of Player
/// </summary>

public class SetDisplayNameButton : MonoBehaviour {
    public Button Button;
    public InputField Input;
    public Text PlaceHolder;
    public GameObject WindowObject;
    private void Start() {
        Button.onClick.AddListener(() => {
            if (Input.text != "") {
                LoginManager.SetDisplayName(Input.text, Success);
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

    void Success() {
        WindowObject.SetActive(true);
    }
}
using UnityEngine;
using UnityEngine.UI;

public class LinkButton : MonoBehaviour {
    public string Url;
    private void Start() {
        GetComponent<Button>().onClick.AddListener(() => Application.OpenURL(Url));
    }
}
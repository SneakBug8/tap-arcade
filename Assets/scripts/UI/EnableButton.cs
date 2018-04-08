using UnityEngine;
using UnityEngine.UI;

public class EnableButton : MonoBehaviour {
    public GameObject Object;
    private void Start() {
        GetComponent<Button>().onClick.AddListener(() => {
            Object.SetActive(true);
            GetComponent<Button>().interactable = false;
        });
    }
}
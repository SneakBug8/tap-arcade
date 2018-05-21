using UnityEngine;
using UnityEngine.UI;

public class ChangeStateButton : MonoBehaviour {
    public GameObject[] EnableObjects;
    public GameObject[] DisableObjects;
    public GameObject[] DestroyObjects;
    
    private void Start() {
        GetComponent<Button>().onClick.AddListener(() => {
            foreach (var obj in EnableObjects) {
                obj.SetActive(true);
            }

            foreach (var obj in DisableObjects) {
                obj.SetActive(false);
            }

            foreach (var obj in DestroyObjects) {
                Destroy(obj);
            }
        });
    }
}
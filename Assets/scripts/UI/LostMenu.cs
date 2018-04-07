using UnityEngine;
using UnityEngine.Events;

public class LostMenu : MonoBehaviour
{
    public static LostMenu Global;
    public UnityEvent OnDraw = new UnityEvent();
    private void Awake() {
        Global = this;
        gameObject.SetActive(false);        
    }

    public void Enable() {
        Debug.Log("Enabled LostMenu");
        gameObject.SetActive(true);
        OnDraw.Invoke();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController Global;
    public float deltaY = 0;
    public float FloatingTime { get { return _floatingTime; } }
    public float FloatingTimeInt { get { return Mathf.FloorToInt(_floatingTime); } }
    float _floatingTime = 0;
    public Text FloatingTimeText;
    public Camera Camera;
    public CameraShake CameraShake;
    bool Stopped;
    private void Awake()
    {
        Global = this;
    }

    private void Start()
    {
        ReposeTimeText();
        UpdateFlightTime();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            deltaY = 0;
        }
        else if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            deltaY = -Time.deltaTime * 10;
        }

        if (Stopped) {
            deltaY = 0;
        }

        // Change Floating Text
        if (deltaY < 0)
        {
            _floatingTime += Time.deltaTime;
            UpdateFlightTime();
        }

        // Starting Camera Movement
        if (Camera.transform.position.y + deltaY < Player.Global.transform.position.y)
        {
            ReposeTimeText();
            Vector3 tempos =
                Vector2.MoveTowards(Camera.transform.position, Player.Global.transform.position, Mathf.Abs(deltaY));
            tempos.z = Camera.transform.position.z;
            Camera.transform.position = tempos;
        }
        else if (Camera.transform.position.y != Player.Global.transform.position.y)
        {
            ReposeTimeText();
            var tpos = Camera.transform.position;
            tpos.y = Player.Global.transform.position.y;
            Camera.transform.position = tpos;
        }
    }

    void ReposeTimeText()
    {
        var timetextpos = Camera.main.WorldToScreenPoint(Player.Global.transform.position + Vector3.up);
        FloatingTimeText.transform.position = timetextpos;
    }

    void UpdateFlightTime()
    {
        FloatingTimeText.text = Mathf.FloorToInt(FloatingTime).ToString();
    }

    public void OnLose()
    {
        StartCoroutine(LoseAnimations());
        Stop();
        LostMenu.Global.Enable();
    }

    IEnumerator LoseAnimations()
    {
        Player.Global.Freeze();
        if (CameraShake != null)
        {
            CameraShake.ShakeCamera(1, 0.5f);
        }
        yield return null;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Stop() {
        Stopped = true;
    }

    public void Resume() {
        foreach (var child in LevelGenerator.Global.transform.GetComponentsInChildren<Obstacle>()) {
            if (child.gameObject != LevelGenerator.Global.LastGameObject) {
                Destroy(child.gameObject);
            }
        }

        Stopped = false;
    }
}

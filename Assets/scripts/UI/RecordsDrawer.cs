using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordsDrawer : MonoBehaviour {

	// Use this for initialization

	private void Start() {
		LostMenu.Global.OnDraw.AddListener(Redraw);
	}
	void Redraw() {
		var record = PlayerPrefs.GetFloat("RecordFloatingTime");
		var recordtext = (LevelController.Global.FloatingTime > record) ? " New record!" : "";
		GetComponent<Text>().text = string.Format(
			"Your score - {0}.{1}",
			LevelController.Global.FloatingTime,
			recordtext
			);
	}
}

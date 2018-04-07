using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public static Player Global;
	Rigidbody2D Rigidbody2D;
	SpriteRenderer Renderer;
	public TrailObject[] TrailObjects;
	private void Awake() {
		Global = this;
	}

	private void Start() {
		Rigidbody2D = GetComponent<Rigidbody2D>();
		Renderer = GetComponent<SpriteRenderer>();
	}

	public void Freeze() {
		Rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
	}

	private void Update() {
		if (LevelController.Global.deltaY != 0) {
			foreach (var TrailObject in TrailObjects) {
				var totransform = TrailObject.Object.transform;
				totransform.localPosition = Vector2.Lerp(
					totransform.localPosition,
					new Vector2(0, TrailObject.DeltaY),
					0.1f
				);
			}
		}
		else {
			foreach (var TrailObject in TrailObjects) {
				var totransform = TrailObject.Object.transform;
				totransform.localPosition = Vector2.Lerp(
					totransform.localPosition,
					Vector2.zero,
					0.1f
				);
			}
		}
	}
}

[System.Serializable]
public class TrailObject {
	public GameObject Object;

	public float DeltaY;
}
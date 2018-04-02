using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public static Player Global;
	public Rigidbody2D Rigidbody2D;
	private void Awake() {
		Global = this;
	}

	private void Start() {
		Rigidbody2D = GetComponent<Rigidbody2D>();
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutting : MonoBehaviour {
	public float mass;
	public Rigidbody rb;

	void Start () {
		
	}

	public void cutTree() {
		//wenn es nicht der Stamm ist
		if (this.transform.parent != null) {
			gameObject.transform.parent = null;
			setRb ();
			removeScripts ();
		}
	}

	void setRb() {
		gameObject.AddComponent<Rigidbody>();
		rb = GetComponent<Rigidbody> ();
		rb.mass = 1;
		rb.drag = 1;
	}

	void removeScripts() {
		Destroy(gameObject.GetComponent<MouseSelection>());
		Destroy(gameObject.GetComponent<Growing>());
		Destroy(gameObject.GetComponent<Cutting>());

		foreach (Transform child in transform) {
			Destroy(child.GetComponent<MouseSelection>());
			Destroy(child.GetComponent<Growing>());
			Destroy(child.GetComponent<Cutting>());
		}
	}
}

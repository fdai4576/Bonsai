using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour {

	public float ScrollSensitivity = 500.0f;
	float mouseZ;
	Vector3 zoom;

	void Start () {
		zoom = transform.localPosition;
	}

	//Veraendert den Abstand von Kamera zu Pivot mittels Scrollrad.
	void Update () {
		mouseZ = Input.GetAxis ("Mouse ScrollWheel");
		zoom.z += mouseZ * ScrollSensitivity * Time.deltaTime;
		transform.localPosition = zoom;
	}
}

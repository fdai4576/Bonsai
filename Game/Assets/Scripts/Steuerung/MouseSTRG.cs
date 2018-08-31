using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSTRG : MonoBehaviour {

	public float inputSensitivity = 500.0f;
	float mouseX;
	float mouseY;
	float rotX = 0.0f;
	float rotY = 0.0f;

	void Start () {
		Vector3 rot = transform.localRotation.eulerAngles;
		rotX = rot.x;
		rotY = rot.y;

	}

	void Update () {
		if (Input.GetMouseButton (1)) {
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
			mouseX = Input.GetAxis ("Mouse X");
			mouseY = Input.GetAxis ("Mouse Y");

			rotY += mouseX * inputSensitivity * Time.deltaTime;
			rotX -= mouseY * inputSensitivity * Time.deltaTime;

			Quaternion localRotation = Quaternion.Euler (rotX, rotY, 0.0f);
			transform.rotation = localRotation;
		} else {
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
	}
}

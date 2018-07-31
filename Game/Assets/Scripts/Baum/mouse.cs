using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse : MonoBehaviour {

	void Start () {
		Cursor.visible = true;
	}

	void Update () {
		//Tasten: links 0, rechts 1, mitte 2
		if (Input.GetMouseButtonDown(0)) {
			Debug.Log ("left mouse button pressed");
			//Pos x/y = 0/0 ist links unten
			Vector3 mousePos = Input.mousePosition;
			Debug.Log (mousePos.x);
			Debug.Log (mousePos.y);
		}
		if (Input.GetMouseButtonDown(1)) {
			Debug.Log ("right mouse button pressed");
		}
		if (Input.GetMouseButtonDown(2)) {
			Debug.Log ("middle mouse button pressed");
		}
			
	}
}

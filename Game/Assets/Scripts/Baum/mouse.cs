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
			//Pos x/y = 0/0 ist links unten
			//Vector3 mousePos = Input.mousePosition;
			//Debug.Log (mousePos.x);
			//Debug.Log (mousePos.y);

			//Erzeugt ein Strahl von Mausposition in die Zene hinein
			Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
			RaycastHit hitInfo;
			//Trifft der Strahl ein Object auf seinem Weg?
			if( Physics.Raycast( ray, out hitInfo ) ) {
				GameObject hitObject = hitInfo.transform.root.gameObject;
				Debug.Log ("Mouse is over: " + hitObject.name );
			}
		}
		if (Input.GetMouseButtonDown(1)) {
			
		}
		if (Input.GetMouseButtonDown(2)) {
			
		}
			
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSelection : MonoBehaviour {
	Color original;
	bool selected;

	void OnMouseEnter(){
		selected = true;
		original = GetComponent<Renderer>().material.color;
		GetComponent<Renderer>().material.color = Color.red;
	}

	void OnMouseExit(){
		selected = false;
		GetComponent<Renderer>().material.color = original;
	}

	void OnMouseDown()
	{
		Debug.Log ("Mouse is over: " + this.name );
        gameObject.AddComponent<Cut_Part>();
	}

	void Update () {
		if (Input.GetMouseButton (1) && selected == true) {
			GetComponent<Renderer>().material.color = original;
		}
	}
}
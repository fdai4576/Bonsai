using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSelection : MonoBehaviour {
	Color original;

	void OnMouseEnter(){
		original = GetComponent<Renderer>().material.color;
		GetComponent<Renderer>().material.color = Color.red;
	}

	void OnMouseExit(){
		GetComponent<Renderer>().material.color = original;
	}

	void OnMouseDown()
	{
		Debug.Log ("Mouse is over: " + this.name );
        gameObject.AddComponent<Cut_Part>();
	}
}
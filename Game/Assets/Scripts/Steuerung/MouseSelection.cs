using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSelection : MonoBehaviour {

	void OnMouseEnter(){
		GetComponent<Renderer>().material.color = Color.red;
	}

	void OnMouseExit(){
		GetComponent<Renderer>().material.color = Color.green;
	}

	void OnMouseDown()
	{
		Debug.Log ("Mouse is over: " + this.name );
        gameObject.AddComponent<Cut_Part>();
	}
}
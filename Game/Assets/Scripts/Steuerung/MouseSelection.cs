using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSelection : MonoBehaviour {
	Color original;
	bool selected;
	public Cutting cutting;

	void Start() {
		cutting = this.GetComponent<Cutting>();
	}

	//Highlightet ein Objekt mittels Material-Farbe bei Mausberuehrung.
	void OnMouseEnter(){
		selected = true;
		original = GetComponent<Renderer>().material.color;
		GetComponent<Renderer>().material.color = Color.red;
	}

	//Stellt Original Material-Farbe wieder her, wenn Maus Objekt verlaesst.
	void OnMouseExit(){
		selected = false;
		GetComponent<Renderer>().material.color = original;
	}

	//Ruft bei Mausklick cutting-Script des Objekts auf und stellt Material-Farbe wieder her.
	void OnMouseDown()
	{
		selected = false;
		GetComponent<Renderer>().material.color = original;
		cutting.cutTree();
	}

	//Stellt Original Material-Farbe wieder her, wenn Ansicht gedreht wird
	void Update () {
		if (Input.GetMouseButton (1) && selected == true) {
			GetComponent<Renderer>().material.color = original;
		}
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSelection : MonoBehaviour {
	Color originalColor;
	bool selected;
	public Cutting cutting;

	void Start() {
		cutting = this.GetComponent<Cutting>();
	}

	public void setOriginalColor() {
		originalColor = GetComponent<Renderer>().material.color;
	}

	//Highlightet ein Objekt mittels Material-Farbe bei Mausberuehrung.
	void OnMouseEnter(){
		setOriginalColor();
		if(!IngameMenu.menuOpened) {
			selected = true;
			GetComponent<Renderer>().material.color = Color.red;
		}
	}

	//Stellt Original Material-Farbe wieder her, wenn Maus Objekt verlaesst.
	void OnMouseExit(){
		selected = false;
		GetComponent<Renderer> ().material.color = originalColor;

	}

	//Ruft bei Mausklick cutting-Script des Objekts auf und stellt Material-Farbe wieder her.
	void OnMouseDown()
	{
		if (!IngameMenu.menuOpened) {
			OnMouseExit ();
			cutting.cutTree ();
		}
	}

	//Stellt Original Material-Farbe wieder her, wenn Ansicht gedreht wird
	void Update () {
		if (Input.GetMouseButton (1) && selected == true) {
			OnMouseExit ();
		}
	}
}
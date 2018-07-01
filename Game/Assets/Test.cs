using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {
	public GameObject obj;

	void Start () {
		
	}
		
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			//Wechsel Name aktuelle Instanz
			obj.transform.name = "Ast";

			//Erzeuge 3 neue Instanzen als Kindobj mit neuem Namen
			for(int i = 0; i < 3; i++) {
				obj = Instantiate (obj, transform.position, transform.rotation); //Im Projekt muss das Prefab zugewiesen werden
				obj.transform.parent = gameObject.transform;
				obj.transform.name = "Blatt";
			}

			//Vernichte Script nach einmaligen Einsatz
			Destroy(GetComponent<Test>());
		}
	}
}

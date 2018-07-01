using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {
	public GameObject obj;
	void Start () {
		
	}

	void grow() {
		obj = Instantiate (obj, transform.position, transform.rotation); //Im Projekt muss das Prefab zugewiesen werden
		obj.transform.parent = gameObject.transform;
		obj.transform.name = "Blatt";
	}
		
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			//Wechsel Name aktuelle Instanz
			obj.transform.name = "Ast";
			//Erzeuge 3 neue Instanzen als Kindobj mit neuem Namen
			grow();
			obj.transform.Translate( 2, 0, 0 );
			//obj.transform.Rotate( 0, 0, 10 );
			//obj.transform.Translate( 0, 1, 0 );

			//Vernichte Script nach einmaligen Einsatz
			Destroy(GetComponent<Test>());
		}
	}
}

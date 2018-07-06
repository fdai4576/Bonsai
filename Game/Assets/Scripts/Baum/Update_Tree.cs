using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Update_Tree : MonoBehaviour {

	public Init_Leaf instatiateLeaf;
	public GameObject leaf;

	void Start() {

		//Verbindung mit dem Realtionship-Skript
		instatiateLeaf = this.GetComponent<Init_Leaf>();

		//PrefabPath
		string leafPath = "Assets/Prefabs/Blatt.prefab";

		//Gibt das erste gefundene Asset vom Typ GameObject zurück (benötigt Cast auf GameObject, da Prefab kein GameObject ist)
		leaf = (GameObject) UnityEditor.AssetDatabase.LoadAssetAtPath(leafPath, typeof(GameObject));

	}

	void Update() {

		if (Input.GetKeyDown(KeyCode.Space)) {

			//Wechsel Name aktuelle Instanz
			gameObject.transform.name = "Ast ";
			instatiateLeaf.grow(leaf);


			//Vernichte Scripts nach einmaligen Einsatz
			Destroy(this);

		}
	}
}
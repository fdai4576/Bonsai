using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Update_Tree : MonoBehaviour {

	public Init_Leaf instatiateLeaf;
	public GameObject leaf;
	public GameObject wood;

	void Start() {

		//Verbindung mit dem Realtionship-Skript
		instatiateLeaf = this.GetComponent<Init_Leaf>();

		//PrefabPath
		string leafPath = "Assets/Prefabs/Blatt.prefab";
		string woodPath = "Assets/Prefabs/Ast.prefab";

		//Gibt das erste gefundene Asset vom Typ GameObject zurück (benötigt Cast auf GameObject, da Prefab kein GameObject ist)
		leaf = (GameObject) UnityEditor.AssetDatabase.LoadAssetAtPath(leafPath, typeof(GameObject));
		wood = (GameObject) UnityEditor.AssetDatabase.LoadAssetAtPath(woodPath, typeof(GameObject));
	}

	void Update() {

		if (Input.GetKeyDown(KeyCode.Space)) {
			//Tauscht aktuelles Objekt mit Prefab "Ast"
			GameObject newWood = Instantiate<GameObject>(wood, this.transform.position, this.transform.rotation);
			newWood.transform.name = "Ast";
			Relationship relation = GetComponent<Relationship>();
			Relationship newRelation = newWood.GetComponent<Relationship>();
			if(relation.getParent() != null) {
				newRelation.setParent(relation.getParent());
				Relationship grandrelation = relation.getParent().GetComponent<Relationship>();
				grandrelation.delChild(this.gameObject);
				grandrelation.addChild(newWood);
			}

			//Vernichte Objekt
			Destroy(this.gameObject);

		}
	}
}
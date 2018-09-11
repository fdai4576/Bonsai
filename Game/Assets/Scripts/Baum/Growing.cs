using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growing : MonoBehaviour {
	public GameObject leaf;
	public GameObject wood;

	void Start () {
		//PrefabPath
		string leafPath = "Assets/Prefabs/Leaf.prefab";
		string woodPath = "Assets/Prefabs/Wood.prefab";

		//Gibt das erste gefundene Asset vom Typ GameObject zurück (benötigt Cast auf GameObject, da Prefab kein GameObject ist)
		leaf = (GameObject) UnityEditor.AssetDatabase.LoadAssetAtPath(leafPath, typeof(GameObject));
		wood = (GameObject) UnityEditor.AssetDatabase.LoadAssetAtPath(woodPath, typeof(GameObject));
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			grow();
			//Vernichte Objekt
			Destroy(gameObject);
		}
	}

	void grow() {
		GameObject newWood = Instantiate<GameObject>(wood, this.transform.position, this.transform.rotation);
		newWood.transform.name = "Wood";
		newWood.transform.SetParent(gameObject.transform.parent);
		for (int rotation = 0; rotation < 360; rotation += 120) {
			//Prefab instanzieren
			GameObject newLeaf = Instantiate<GameObject>(leaf, this.transform.position, this.transform.rotation);
			newLeaf.transform.name = "Leaf";
			transformLeafs (newLeaf, rotation);
			newLeaf.transform.SetParent(newWood.transform);
		}


	}

	void transformLeafs(GameObject newLeaf, int rotation) {
		newLeaf.transform.Rotate( 0, rotation, 0 );
		newLeaf.transform.Translate(0, 2, 0);
		newLeaf.transform.Rotate( 0, 0, 45 );
		newLeaf.transform.Translate(0, 2, 0);
	}
}

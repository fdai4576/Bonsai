using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ansicht : MonoBehaviour {
	public GameObject leaf;
	public GameObject wood;
	public GameObject obj;
	Mesh new_mesh;
	Material new_material;
	// Use this for initialization
	void Start () {
		//PrefabPath
		string leafPath = "Assets/Prefabs/LeafTexture.prefab";
		string woodPath = "Assets/Prefabs/WoodTexture.prefab";

		//Gibt das erste gefundene Asset vom Typ GameObject zurück (benötigt Cast auf GameObject, da Prefab kein GameObject ist)
		leaf = (GameObject) UnityEditor.AssetDatabase.LoadAssetAtPath(leafPath, typeof(GameObject));
		wood = (GameObject) UnityEditor.AssetDatabase.LoadAssetAtPath(woodPath, typeof(GameObject));
	}
	
	void ChangeView() {
		//GameObject[] tree_parts = GameObject.FindGameObjectsWithTag("Tree");
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Tree")) {
			if (obj.name.Contains ("Leaf")) {
				new_mesh = leaf.GetComponent<MeshFilter> ().sharedMesh;
				new_material = leaf.GetComponent<MeshRenderer> ().sharedMaterial;
			} else {
				new_mesh = wood.GetComponent<MeshFilter> ().sharedMesh;
				new_material = wood.GetComponent<MeshRenderer> ().sharedMaterial;
			}
			obj.GetComponent<MeshFilter> ().mesh = Instantiate (new_mesh);
			obj.GetComponent<MeshRenderer> ().material.CopyPropertiesFromMaterial (new_material);
		}
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.A)) {
			ChangeView();
		}
	}
}

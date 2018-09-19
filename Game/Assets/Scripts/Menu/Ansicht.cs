using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ansicht : MonoBehaviour {
	public GameObject leaf;
	public GameObject wood;
	public GameObject obj;
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
		GameObject[] tree_parts = GameObject.FindGameObjectsWithTag("Tree");
		foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Tree")) {

		}

		Mesh wood_mesh = wood.GetComponent<MeshFilter>().sharedMesh;
		Material wood_material = wood.GetComponent<MeshRenderer>().sharedMaterial;

		gameObject.GetComponent<MeshFilter>().mesh = Instantiate(wood_mesh);
		gameObject.GetComponent<MeshRenderer>().material.CopyPropertiesFromMaterial(wood_material);
	}
}

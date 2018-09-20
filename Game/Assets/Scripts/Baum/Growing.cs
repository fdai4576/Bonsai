﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growing : MonoBehaviour {
	public GameObject leaf;
	public GameObject wood;
	public GameObject newParent;
    public Vector3 childs;

	void Start () {
		//PrefabPath
		string leafPath = "Assets/Prefabs/Leaf.prefab";
		string woodPath = "Assets/Prefabs/Wood.prefab";

		//Gibt das erste gefundene Asset vom Typ GameObject zurück (benötigt Cast auf GameObject, da Prefab kein GameObject ist)
		leaf = (GameObject) UnityEditor.AssetDatabase.LoadAssetAtPath(leafPath, typeof(GameObject));
		wood = (GameObject) UnityEditor.AssetDatabase.LoadAssetAtPath(woodPath, typeof(GameObject));
	}

	//Fragt Leertasten-Input ab, um dann Wachstum zu initieren.
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			grow();
		}
	}

	//Steuert den Wachstumsprozess eines Blatt- oder Ast-Elements.
	void grow() {
		childs = checkChilds();
        for (int i = 0; i < 3; i++) {
			if(childs[i] == 0) {
				//Prefab instanzieren
				GameObject newLeaf = Instantiate<GameObject>(leaf, this.transform.position, this.transform.rotation);
				newLeaf.transform.name = "Leaf" + i;
				transformLeafs(newLeaf, i*120);
				newLeaf.transform.SetParent(gameObject.transform);
			}
		}
		Destroy(this.GetComponent<Growing>());
    }

	//Vermerkt eventuell vorhandene Kindobjekte(Blaetter an einem Ast) in einem Vektor.
	Vector3 checkChilds() {
		if (this.transform.childCount > 0) {
			foreach (Transform child in this.transform) {
				switch (child.gameObject.name.Substring(4)) {
				case "0":
					childs += new Vector3 (1, 0, 0);
					break;
				case "1":
					childs += new Vector3 (0, 1, 0);
					break;
				case "2":
					childs += new Vector3 (0, 0, 1);
					break;
				default:
					break;
				}
			}
		} else {
			Leaf2Wood();
		}
		return childs;
	}

	//Tauscht Blatt- mit Ast-Element
	void Leaf2Wood() {
		gameObject.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
		if (gameObject.transform.parent != null) {
			gameObject.transform.Translate (0, -2, 0);
			gameObject.transform.Translate (0, 1.4f * gameObject.transform.parent.transform.lossyScale.x, 0);
		} else {
			gameObject.transform.Translate(0, -0.3f, 0);
		}

		Mesh wood_mesh = wood.GetComponent<MeshFilter>().sharedMesh;
        Material wood_material = wood.GetComponent<MeshRenderer>().sharedMaterial;

        gameObject.GetComponent<MeshFilter>().mesh = Instantiate(wood_mesh);
        gameObject.GetComponent<MeshRenderer>().material.CopyPropertiesFromMaterial(wood_material);
        gameObject.name = "Wood" + gameObject.name.Substring(4);
	}

	//Bringt neue Blaetter in Position
	void transformLeafs(GameObject newLeaf, int rotation) {
		newLeaf.transform.Rotate( 0, rotation, 0 );
		newLeaf.transform.Translate(0, 2*gameObject.transform.lossyScale.y, 0);
		newLeaf.transform.Rotate( 0, 0, 45 );
		newLeaf.transform.Translate(0, 2, 0);
		newLeaf.transform.Rotate( 0, Random.Range(0, 180), 0 );
    }
}

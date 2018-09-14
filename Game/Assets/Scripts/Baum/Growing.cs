using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growing : MonoBehaviour {
	public GameObject leaf;
	public GameObject wood;
	public GameObject newParent;
	Vector3 childs = new Vector3 (0, 0, 0);

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
				transformLeafs (newLeaf, i*120);
				newLeaf.transform.SetParent(newParent.transform);
			}
		}
		Destroy(this.GetComponent<Growing>());
    }

	//Vermerkt eventuell vorhandene Kindobjekte(Blaetter an einem Ast) in einem Vektor.
	Vector3 checkChilds() {
		if (this.transform.childCount > 0) {
			newParent = gameObject;
			foreach (Transform child in this.transform) {
				switch (child.gameObject.name) {
				case "Leaf0":
					childs += new Vector3 (1, 0, 0);
					break;
				case "Wood0":
					childs += new Vector3 (1, 0, 0);
					break;
				case "Leaf1":
					childs += new Vector3 (0, 1, 0);
					break;
				case "Wood1":
					childs += new Vector3 (0, 1, 0);
					break;
				case "Leaf2":
					childs += new Vector3 (0, 0, 1);
					break;
				case "Wood2":
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
		newParent = Instantiate<GameObject>(wood, this.transform.position, this.transform.rotation);
		switch (this.name) {
		case "Leaf0":
			newParent.transform.name = "Wood0";
			break;
		case "Leaf1":
			newParent.transform.name = "Wood1";
			break;
		case "Leaf2":
			newParent.transform.name = "Wood2";
			break;
		default:
			break;
		}
		newParent.transform.localScale = gameObject.transform.lossyScale;
		newParent.transform.SetParent(gameObject.transform.parent);
		Destroy(gameObject);
	}

	//Bringt neue Blaetter in Position
	void transformLeafs(GameObject newLeaf, int rotation) {
        float scale = Random.Range(0.90f, 1.0f);
        newLeaf.transform.localScale = Vector3.Scale(gameObject.transform.lossyScale, new Vector3(scale, scale, scale));

        newLeaf.transform.Rotate( 0, rotation, 0 );
		newLeaf.transform.Translate(0, 2*gameObject.transform.lossyScale.x, 0);
		newLeaf.transform.Rotate( 0, 0, 45 );
		newLeaf.transform.Translate(0, 2* gameObject.transform.lossyScale.x, 0);
    }
}

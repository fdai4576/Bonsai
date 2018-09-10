using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow : MonoBehaviour {
	public GameObject leaf;

	void Start () {
		string leafPath = "Assets/Prefabs/Blatt.prefab";
		leaf = (GameObject)UnityEditor.AssetDatabase.LoadAssetAtPath (leafPath, typeof(GameObject));

		//Realtionship-Skript das derzeitigen Objekts aufrufen
		Relationship relation = this.GetComponent<Relationship> ();

		for (int rotation = 0; rotation < 360; rotation += 120) {
			//Erzeuge Anfangskinder
			if (relation.getChilds().Count < 3){
				//Erstelle fehlende Kinder
				newLeaf(leaf, rotation, relation);
			}
			else {
				//Erzeuge fehlende Kinder neu
				if (relation.getChilds()[rotation/120] == null) {
					//Erstelle fehlende Kinder
					newLeaf(leaf, rotation, relation);
				}
			}
		}
	}

	public void newLeaf(GameObject clone, int rotation, Relationship relation) {

		//Prefab instanzieren
		GameObject newLeaf = Instantiate<GameObject>(clone, this.transform.position, this.transform.rotation);
		newLeaf.transform.name = "Blatt";

		//Eintragen der Kinder
		if(relation.getChilds().Count < 3) { 
			//Falls noch keine Blätter jemals erzeugt wurden
			relation.addChild(newLeaf);
		} else {
			//falls es bereits Blätter gab
			relation.setChild(rotation / 120, newLeaf);
		}

		//Realtionship-Skript des Kind-Objekts aufrufen + setzen des Elternteils
		Relationship relation_child = newLeaf.GetComponent<Relationship>();
		relation_child.setParent(gameObject);

		//Verbindung mit dem TransformObject-Skript
		Transformations transformations = newLeaf.GetComponent<Transformations>();
		transformations.transformate(newLeaf, rotation);

	}
}

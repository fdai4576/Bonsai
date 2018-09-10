using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Update_Tree : MonoBehaviour {

	public Init_Leaf instantiateLeaf;
	public GameObject leaf;
	public GameObject wood;

	void Start() {

		//Verbindung mit dem Realtionship-Skript
		instantiateLeaf = this.GetComponent<Init_Leaf>();

		//PrefabPath
		string leafPath = "Assets/Prefabs/Blatt.prefab";
		string woodPath = "Assets/Prefabs/Ast.prefab";

		//Gibt das erste gefundene Asset vom Typ GameObject zurück (benötigt Cast auf GameObject, da Prefab kein GameObject ist)
		leaf = (GameObject) UnityEditor.AssetDatabase.LoadAssetAtPath(leafPath, typeof(GameObject));
		wood = (GameObject) UnityEditor.AssetDatabase.LoadAssetAtPath(woodPath, typeof(GameObject));
	}

	void Update() {

		if (Input.GetKeyDown(KeyCode.Space)) {

            //Erzeugt neue Blätter
            instantiateLeaf.grow(leaf);

            //Tauscht aktuelles Objekt mit Prefab "Ast"
			GameObject newWood = Instantiate<GameObject>(wood, this.transform.position, this.transform.rotation);
			newWood.transform.name = "Ast";

            //Verbindung mit neuem und ehemaligen Beziehungsskript
            Relationship newRelation = newWood.GetComponent<Relationship>();
            Relationship oldRelation = gameObject.GetComponent<Relationship>();

            //Kinder bekommen neues Elternteil
            List<GameObject> children = oldRelation.getChilds();

            for (int i = 0; i < 3; i++)
            {
                children[i].GetComponent<Relationship>().setParent(newWood);
            }

            //wenn ein Elternteil vorhanden ist
            if (oldRelation.getParent() != null)
            {
                //Verbinde mit dem Beziehungsskript des Elternteils
                Relationship oldParentRelation = oldRelation.getParent().GetComponent<Relationship>();

                //Ändere das Kind zum neuen GameObject
                oldParentRelation.setChild(oldParentRelation.getChilds().IndexOf(gameObject), newWood);
                
                //Ändere das Elternteil des neuen Objektes
                newRelation.setParent(oldRelation.getParent());
            }

            //Übertrage die Kinder
            newRelation.children = oldRelation.getChilds();

            //Vernichte Objekt
            Destroy(gameObject);

        }
	}
}
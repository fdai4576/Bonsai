using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Sorgt dafür, dass die Farbe beim Abschneiden zurückgesetzt wird
public class FixColorIssue : MonoBehaviour {

    Material current_material;
    Material leaf_material;
    Material wood_material;

	// Use this for initialization
	void Start () {
        string wood_materialPath = "Assets/Materials/Wood.mat";
        string leaf_materialPath = "Assets/Materials/Leaf.mat";

        leaf_material = (Material)UnityEditor.AssetDatabase.LoadAssetAtPath(leaf_materialPath, typeof(Material));
        wood_material = (Material)UnityEditor.AssetDatabase.LoadAssetAtPath(wood_materialPath, typeof(Material));

        current_material = gameObject.GetComponent<MeshRenderer>().material;


    }
	
	// Update is called once per frame
	void Update () {

        if (current_material.color == Color.red)
        {
            if (gameObject.name.Contains("Leaf"))
            {
                current_material.color = leaf_material.color;
                Destroy(this);
            }
            else
            {
                current_material.color = wood_material.color;
                Destroy(this);
            }
        }
        else {
            Destroy(this);
        }

	}
}

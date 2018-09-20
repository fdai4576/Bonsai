using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameToScene : MonoBehaviour {

	//Initialisiert einen Speicherstand, wenn er geladen werden soll
	void Start () {
        Debug.Log(Laden.gameToLoad);
		if(Laden.gameToLoad != (int?) null)
        {
            rebuild_tree((int) Laden.gameToLoad);
        }
        Destroy(this);
	}

    //Stellt den Baum wieder her
    public void rebuild_tree(int index)
    {

        //PrefabPath
        string leafPath = "Assets/Prefabs/Leaf.prefab";
        string woodPath = "Assets/Prefabs/Wood.prefab";

        //Gibt das erste gefundene Asset vom Typ GameObject zurück (benötigt Cast auf GameObject, da Prefab kein GameObject ist)
        GameObject leaf = (GameObject)UnityEditor.AssetDatabase.LoadAssetAtPath(leafPath, typeof(GameObject));
        GameObject wood = (GameObject)UnityEditor.AssetDatabase.LoadAssetAtPath(woodPath, typeof(GameObject));

        //Ersetzt den Baum durch den geladenen Baum
        GameObject start = GameObject.FindGameObjectWithTag("Tree");
        Object.Destroy(start);

        //Liste für alle bereits erzeugten GameObjects
        List<GameObject> gameObjects = new List<GameObject>();

        //Referenz zum aktuellen GameObject
        GameObject go = new GameObject();

        //Erzeugt die Baumteile
        for (int i = 0; i < Laden.saveGames[index].tree.Count; i++)
        {

            if (Laden.saveGames[index].tree[i].Contains("wood"))
            {
                go = GameObject.Instantiate<GameObject>(wood, go.transform.position, go.transform.rotation);
            }
            else
            {
                go = GameObject.Instantiate<GameObject>(leaf, go.transform.position, go.transform.rotation);
            }

            go.transform.position.Set(Laden.saveGames[index].tree_positions[i].x, Laden.saveGames[index].tree_positions[i].y, Laden.saveGames[index].tree_positions[i].z);
            go.transform.rotation.Set(Laden.saveGames[index].tree_rotations[i].x, Laden.saveGames[index].tree_rotations[i].y, Laden.saveGames[index].tree_rotations[i].z, Laden.saveGames[index].tree_rotations[i].w);
            go.transform.localScale.Set(Laden.saveGames[index].tree_scales[i].x, Laden.saveGames[index].tree_scales[i].y, Laden.saveGames[index].tree_scales[i].z);
            if (Laden.saveGames[index].tree_parent_ids[i] != null)
            {
                go.transform.parent = gameObjects[Laden.saveGames[index].tree_ids.IndexOf((int) Laden.saveGames[index].tree_parent_ids[i])].transform;
            }

            if (Laden.saveGames[index].grow_attached[i])
            {
                go.AddComponent<Growing>();
            }
            go.tag = "Tree";
            gameObjects.Add(go);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameToScene : MonoBehaviour {

    //Initialisiert einen Speicherstand, wenn er geladen werden soll
    void Start () {
		if(Laden.gameToLoad != (int?) null)
        {
            Game.current = Laden.saveGames[(int) Laden.gameToLoad];
            rebuild_tree();
        }
        Destroy(this);
	}

    //Stellt den Baum wieder her
    public void rebuild_tree()
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

        //Referenz auf ein neues GameObject
        GameObject go = new GameObject();

        //Erzeugt die Baumteile
        for (int i = 0; i < Game.current.tree.Count; i++)
        {

            if (Game.current.tree[i].Contains("Wood"))
            {
               go = GameObject.Instantiate<GameObject>(wood, go.transform.position, go.transform.rotation);
            }
            else
            {
               go = GameObject.Instantiate<GameObject>(leaf, go.transform.position, go.transform.rotation);
            }
            go.transform.position = new Vector3(Game.current.tree_positions[i].x, Game.current.tree_positions[i].y, Game.current.tree_positions[i].z);
            go.transform.rotation = new Quaternion(Game.current.tree_rotations[i].x, Game.current.tree_rotations[i].y, Game.current.tree_rotations[i].z, Game.current.tree_rotations[i].w);
            go.transform.localScale = new Vector3(Game.current.tree_scales[i].x, Game.current.tree_scales[i].y, Game.current.tree_scales[i].z);
            if (Game.current.tree_parent_ids[i] != null)
            {
                go.transform.parent = gameObjects[Game.current.tree_ids.IndexOf((int) Game.current.tree_parent_ids[i])].transform;
            }

            if (Game.current.grow_attached[i])
            {
                go.AddComponent<Growing>();
            }
            go.name = Game.current.tree[i];
            gameObjects.Add(go);
        }

    }
}

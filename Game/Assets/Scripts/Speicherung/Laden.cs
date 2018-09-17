using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public static class Laden {

    public static List<Game> saveGames = new List<Game>();

    //Lädt und speichert die Spieldaten
    public static void Load() {
        if (File.Exists(Application.dataPath + "/savedGames.gd"))
        {
            Debug.Log(Application.persistentDataPath);
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.dataPath + "/savedGames.gd", FileMode.Open);
            saveGames = (List<Game>)bf.Deserialize(file);
            file.Close();
        }
    }

    //Stellt den Baum wieder her
    public static void rebuild_tree(int index) {

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
        for (int i = 0; i < saveGames[index].tree.Count; i++) {

            if (saveGames[index].tree[i].Contains("wood"))
            {
                go = GameObject.Instantiate<GameObject>(wood, go.transform.position, go.transform.rotation);
            }
            else {
                go = GameObject.Instantiate<GameObject>(leaf, go.transform.position, go.transform.rotation);
            }

            go.transform.position.Set(saveGames[index].tree_positions[i].x, saveGames[index].tree_positions[i].y, saveGames[index].tree_positions[i].z);
            go.transform.rotation.Set(saveGames[index].tree_rotations[i].x, saveGames[index].tree_rotations[i].y, saveGames[index].tree_rotations[i].z, saveGames[index].tree_rotations[i].w);
            go.transform.localScale.Set(saveGames[index].tree_scales[i].x, saveGames[index].tree_scales[i].y, saveGames[index].tree_scales[i].z);
            go.transform.parent = gameObjects[saveGames[index].tree_ids.IndexOf(saveGames[index].tree_parent_ids[i])].transform;
            if (saveGames[index].grow_attached[i]) {
                go.AddComponent<Growing>();
            }
            go.tag = "Tree";
            gameObjects.Add(go);
        }

    }
	
}

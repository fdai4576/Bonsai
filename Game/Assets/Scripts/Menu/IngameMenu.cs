using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IngameMenu : MonoBehaviour {

	public static bool menuOpened;
	public static bool textureOn;
    public List<GameObject> savegame_text;
    public GameObject savegame_panel;

	public GameObject leaf;
	public GameObject wood;
	public GameObject obj;
	Mesh new_mesh;
	Material new_material;
	string leafPath;
	string woodPath;

	void Start () {
	}

    public void escButton() {
        SceneManager.LoadSceneAsync(0);
        Debug.Log("ESC-Button pressed");
    }

    //Zeigt die Spielstände und lädt sie (falls notwendig)
    public void showSavegame() {
		menuOpened = true;
		Debug.Log(savegame_panel);
        if (!Laden.loaded) {
            Laden.Load();
        }

        int i = 0;

        foreach (Game save in Laden.saveGames) {
            savegame_text[i].GetComponent<Text>().text = save.name;
            i++;
        }
       
        while (i < 3) {
            savegame_text[i].GetComponent<Text>().text = "Freier Spielstand";
            i++;
        }

        savegame_panel.gameObject.SetActive(true);
    }

    //Versteckt die Spielstände
    public void hideSavegames() {
		menuOpened = false;
		savegame_panel.gameObject.SetActive(false);
    }


    public void ChangeView() {
		if (!textureOn) {
			//PrefabPath
			leafPath = "Assets/Prefabs/LeafTexture.prefab";
			woodPath = "Assets/Prefabs/WoodTexture.prefab";
		} else {
			leafPath = "Assets/Prefabs/Leaf.prefab";
			woodPath = "Assets/Prefabs/Wood.prefab";
		}

		//Gibt das erste gefundene Asset vom Typ GameObject zurück (benötigt Cast auf GameObject, da Prefab kein GameObject ist)
		leaf = (GameObject) UnityEditor.AssetDatabase.LoadAssetAtPath(leafPath, typeof(GameObject));
		wood = (GameObject) UnityEditor.AssetDatabase.LoadAssetAtPath(woodPath, typeof(GameObject));

		foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Tree")) {
			if (obj.name.Contains ("Leaf")) {
				new_mesh = leaf.GetComponent<MeshFilter> ().sharedMesh;
				new_material = leaf.GetComponent<MeshRenderer> ().sharedMaterial;
			} else {
				new_mesh = wood.GetComponent<MeshFilter> ().sharedMesh;
				new_material = wood.GetComponent<MeshRenderer> ().sharedMaterial;
			}
			obj.GetComponent<MeshFilter> ().mesh = new_mesh;
			obj.GetComponent<MeshRenderer> ().material.CopyPropertiesFromMaterial(new_material);
		}
	}

}
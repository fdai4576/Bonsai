using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class SaveGames : MonoBehaviour {

    public GameObject game_name;
    public GameObject savegame_panel;
    public GameObject save_panel;

    public void loadSavegames(int i)
    {
        if (i < Laden.saveGames.Count)
        {
            Laden.gameToLoad = i;
            SceneManager.LoadScene(1);
        }
    }

    public void setSaveSlot(int index) {
        Speichern.gameToSave = index;
        savegame_panel.SetActive(false);
        save_panel.SetActive(true);
    }

    public void saveGame()
    {
        Game.current = new Game();
        Game.current.name = game_name.GetComponent<Text>().text;
        setGame();
        Speichern.Save();
        Laden.loaded = false;
        save_panel.SetActive(false);
    }

    public void setGame()
    {
        GameObject[] tree_parts = GameObject.FindGameObjectsWithTag("Tree");

        foreach (GameObject go in tree_parts)
        {
            Game.current.tree.Add(go.name);
            Game.current.tree_positions.Add(new SerializableVector3(go.transform.position.x, go.transform.position.y, go.transform.position.z));
            Game.current.tree_rotations.Add(new SerializableQuaternion(go.transform.rotation.x, go.transform.rotation.y, go.transform.rotation.z, go.transform.rotation.w));
            Game.current.tree_scales.Add(new SerializableVector3(go.transform.lossyScale.x, go.transform.lossyScale.y, go.transform.lossyScale.z));
            if (go.transform.parent != null)
            {
                Game.current.tree_parent_ids.Add(go.transform.parent.gameObject.GetInstanceID());
            }
            else {
                Game.current.tree_parent_ids.Add(null);
            }
            Game.current.tree_ids.Add(go.GetInstanceID());
            Game.current.grow_attached.Add(go.GetComponent<Growing>() != null && go.name.Contains("Wood"));
        }
    }
}

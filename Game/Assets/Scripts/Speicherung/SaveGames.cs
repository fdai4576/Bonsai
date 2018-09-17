using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SaveGames : MonoBehaviour {

    public void loadSavegames(int i) {
        if(Laden.saveGames[i] != null)
        {
            SceneManager.LoadScene(1);
            Laden.rebuild_tree(i);
        }
    }
}

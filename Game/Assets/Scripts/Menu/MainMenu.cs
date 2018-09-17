using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public bool loaded = false;

    public void PlayGame() {
		SceneManager.LoadScene(1);
	}

    public void showSavegames() {
        if(!loaded) { 
            Laden.Load();
            loaded = true;
        }
        GameObject saveGames = GameObject.FindGameObjectWithTag("Menu");
        GameObject start_panel = saveGames.transform.GetChild(0).gameObject;
        GameObject panel = saveGames.transform.GetChild(1).gameObject;

        panel.SetActive(true);
        start_panel.SetActive(false);
        
    }

    public void hideSavegames()
    {
        GameObject saveGames = GameObject.FindGameObjectWithTag("Menu");
        GameObject start_panel = saveGames.transform.GetChild(0).gameObject;
        GameObject panel = saveGames.transform.GetChild(1).gameObject;

        panel.SetActive(false);
        start_panel.SetActive(true);

    }

}

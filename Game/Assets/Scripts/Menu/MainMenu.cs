using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    
    public GameObject main_panel;
    public GameObject savegame_panel;
    public List<GameObject> savegame_text;

    //Startet ein neues Spiel
    public void PlayGame() {
        Laden.gameToLoad = null;
        SceneManager.LoadScene(1);
	}

    //Zeigt/Lädt die Spielstände und versteckt das Hauptmenü 
    public void showSavegames() {
        if(!Laden.loaded) { 
            Laden.Load();
            Laden.loaded = true;
        }

        int i = 0;

        foreach (Game save in Laden.saveGames)
        {
            savegame_text[i].GetComponent<Text>().text = save.name;
            i++;
        }

        while (i < 3)
        {
            savegame_text[i].GetComponent<Text>().text = "Freier Spielstand";
            i++;
        }

        GameObject saveGames = GameObject.FindGameObjectWithTag("Menu");
        GameObject start_panel = saveGames.transform.GetChild(0).gameObject;
        GameObject panel = saveGames.transform.GetChild(1).gameObject;

        panel.SetActive(true);
        start_panel.SetActive(false);
        
    }

    //Zeigt das Hauptmenü und versteckt die Spielstände
    public void hideSavegames()
    {
        GameObject saveGames = GameObject.FindGameObjectWithTag("Menu");
        GameObject start_panel = saveGames.transform.GetChild(0).gameObject;
        GameObject panel = saveGames.transform.GetChild(1).gameObject;

        panel.SetActive(false);
        start_panel.SetActive(true);

    }

    public void Exit() {
        Application.Quit();
    }

}

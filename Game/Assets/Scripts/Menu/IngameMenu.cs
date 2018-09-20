using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IngameMenu : MonoBehaviour {

    public List<GameObject> savegame_text;
    public GameObject savegame_panel;

    public void escButton()
    {
        SceneManager.LoadSceneAsync(0);
        Debug.Log("ESC-Button pressed");
    }

    public void showSavegame()
    {
        Debug.Log(savegame_panel);
        if (!Laden.loaded)
        {
            Laden.Load();
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

        savegame_panel.gameObject.SetActive(true);

    }

    public void hideSavegames()
    {
        savegame_panel.gameObject.SetActive(false);
    }

}
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public static class Speichern {

    public static List<Game> saveGames = new List<Game>();
    public static int? gameToSave;

    //Holt sich die Daten des Spiels und speichert sie ab
    public static void Save()
    {
        if (!Laden.loaded)
        {
            Laden.Load();
            saveGames = Laden.saveGames;
        }
        if (saveGames.Count <= gameToSave)
        {
            saveGames.Add(Game.current);
        }
        else
        {
            saveGames[(int)gameToSave] = Game.current;
        }
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.dataPath + "/savedGames.gd");
        bf.Serialize(file, saveGames);
        file.Close();
        Laden.loaded = false;
    }

}

using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public static class Speichern {

    public static List<Game> saveGames = new List<Game>();

    //Holt sich die Daten des Spiels und speichert sie ab
	public static void Save() {
        Laden.Load();
        if(saveGames.Count < 3) { 
            saveGames.Add(Game.current);
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.dataPath + "/savedGames.gd");
            bf.Serialize(file, saveGames);
            file.Close();
        }
    }

}

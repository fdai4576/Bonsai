using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public static class Laden {

    public static List<Game> saveGames = new List<Game>();
    public static bool loaded;
    public static int? gameToLoad = null;

    //Lädt und speichert die Spieldaten
    public static void Load() {
        if (File.Exists(Application.dataPath + "/savedGames.gd"))
        {
            Debug.Log(Application.persistentDataPath);
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.dataPath + "/savedGames.gd", FileMode.Open);
            saveGames = (List<Game>)bf.Deserialize(file);
            file.Close();
            loaded = true;
        }
    }
	
}

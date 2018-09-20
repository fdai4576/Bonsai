using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Game {

    public static Game current;
    public string name;

    //Spieldaten vom Baum
    public List<string> tree;
    public List<SerializableVector3> tree_positions;
    public List<SerializableQuaternion> tree_rotations;
    public List<SerializableVector3> tree_scales;
    public List<int?> tree_parent_ids;
    public List<int> tree_ids;
    public List<bool> grow_attached;
    public bool quality;

    public Game()
    {
        quality = false;
        tree = new List<string>();
        tree_positions = new List<SerializableVector3>();
        tree_rotations = new List<SerializableQuaternion>();
        tree_scales = new List<SerializableVector3>();
        tree_parent_ids = new List<int?>();
        tree_ids = new List<int>();
        grow_attached = new List<bool>();

    }

}

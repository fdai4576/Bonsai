using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Game {

    public static Game current;

    //Spieldaten vom Baum
    public List<string> tree;
    public List<SerializableVector3> tree_positions;
    public List<SerializableQuaternion> tree_rotations;
    public List<SerializableVector3> tree_scales;
    public List<int> tree_parent_ids;
    public List<int> tree_ids;
    public List<bool> grow_attached;

    public Game() {
        GameObject[] tree_parts = GameObject.FindGameObjectsWithTag("Tree");

        foreach (GameObject go in tree_parts) {
            tree.Add(go.name);
            tree_positions.Add(new SerializableVector3(go.transform.position.x, go.transform.position.y, go.transform.position.z));
            tree_rotations.Add(new SerializableQuaternion(go.transform.rotation.x, go.transform.rotation.y, go.transform.rotation.z, go.transform.rotation.w));
            tree_scales.Add(new SerializableVector3(go.transform.lossyScale.x, go.transform.lossyScale.y, go.transform.lossyScale.z));
            tree_parent_ids.Add(go.transform.parent.gameObject.GetInstanceID());
            tree_ids.Add(go.GetInstanceID());
            grow_attached.Add(go.GetComponent<Growing>() != null && go.name.Contains("Wood"));
        }
    }

}

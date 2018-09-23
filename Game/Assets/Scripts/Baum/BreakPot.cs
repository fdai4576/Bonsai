using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakPot : MonoBehaviour {
    
    public int space_hits;
    private GameObject brokenPot;

	// Use this for initialization
	void Start () {
        string potPath = "Assets/Prefabs/brokenPot.prefab";
        brokenPot = (GameObject)UnityEditor.AssetDatabase.LoadAssetAtPath(potPath, typeof(GameObject));
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space)) {
            space_hits++;
            if (space_hits >= 9) {
                Instantiate<GameObject>(brokenPot, gameObject.transform.position, gameObject.transform.rotation);
                Destroy(gameObject);
            }
        }

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relationship : MonoBehaviour {

    public List<GameObject> children;
    public GameObject parent;

	// Use this for initialization
	void Start () {
		
	}

    //Verknüpft das GameObject mit seinen Kindern
    void addChild(GameObject child) {
        children.Add(child);
    }

    //verknüpft das GameObject mit seinem Elternteil
    void setParent(GameObject par) {
        parent = par;
    }

    void delParent() {
        parent = null;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutting : MonoBehaviour {
	public Rigidbody rb;

	//Steuert den Schneidevorgang beim Entfernen eines Asts oder Blattes.
	public void cutTree() {
        //wenn es nicht der Stamm ist
        if (this.transform.parent != null)
        {
            addScript();
            removeScripts(gameObject);
            setRb(gameObject);
            gameObject.transform.parent = null;
        }
        else {
            gameObject.AddComponent<Growing>();

            while(gameObject.transform.childCount > 0)
            {
                removeScripts(gameObject.transform.GetChild(0).gameObject);
                setRb(gameObject.transform.GetChild(0).gameObject);
                gameObject.transform.GetChild(0).parent = null;
            }
            
        }
	}

    //Fuegt Wachstums-Script an ein GameObject an.
	void addScript() {
        if (this.transform.parent.gameObject.AddComponent<Growing>() == null)
        this.transform.parent.gameObject.AddComponent<Growing>();
    }

	//Fuegt Rigidbody an ein GameObject an, welches dann mitsamt seinen Kindern auf Gravitation reagiert
	void setRb(GameObject go) {
		go.AddComponent<Rigidbody>();
		rb = go.GetComponent<Rigidbody>();
		rb.mass = 1;
		rb.drag = 1;
	}

	//Entfernt alle Scripte von einem GameObject.
	void removeScripts(GameObject go) {
        Destroy(go.GetComponent<MouseSelection>());
		Destroy(go.GetComponent<Growing>());
		Destroy(go.GetComponent<Cutting>());
        go.AddComponent<FixColorIssue>();
        go.tag = "Cut";

        if (go.transform.childCount > 0) {
            foreach (Transform child in go.transform) {
            	removeScripts(child.gameObject);
            }
        }
    }
}

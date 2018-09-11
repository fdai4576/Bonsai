using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutting : MonoBehaviour {

	public Rigidbody rb;

	void Start () {
		
	}

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

    void addScript() {
        this.transform.parent.gameObject.AddComponent<Growing>();
    }

	void setRb(GameObject go) {
		go.AddComponent<Rigidbody>();
		rb = go.GetComponent<Rigidbody>();
		rb.mass = 1;
		rb.drag = 1;
	}

	void removeScripts(GameObject go) {
        Destroy(go.GetComponent<MouseSelection>());
		Destroy(go.GetComponent<Growing>());
		Destroy(go.GetComponent<Cutting>());

        if (go.transform.childCount > 0)
        {
            foreach (Transform child in go.transform)
            {
                removeScripts(child.gameObject);
            }
        }
    }
}

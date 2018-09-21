using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour {

    Color color;

	// Use this for initialization
	void Start () {
        color = gameObject.GetComponent<MeshRenderer>().material.color;
	}
	
	// Update is called once per frame
	void Update () {
        color.a -= Time.deltaTime * 0.1f;
        gameObject.GetComponent<MeshRenderer>().material.color = color;
        if (color.a < 0.00f) {
            Destroy(this);
        }
	}
}

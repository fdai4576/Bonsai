using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour {
	float timer = 0.0f;
    Color color;
	private Material leaf;
	string leafPath;

	// Use this for initialization
	void Start () {
		//MeshRenderer renderer = gameObject.GetComponent <MeshRenderer>();
		//Material material = renderer.material;
		//material.SetFloat("_Mode", 3f);
		gameObject.GetComponent<MeshRenderer>().material.SetFloat("_Mode", 2);
		//leafPath = "Assets/Materials/LeafFade.mat";
		//leaf = (Material) UnityEditor.AssetDatabase.LoadAssetAtPath(leafPath, typeof(Material));

		//gameObject.GetComponent<MeshRenderer>().material = leaf;
		color = gameObject.GetComponent<MeshRenderer>().material.color;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > 5) {
			color.a -= 0.1f*Time.deltaTime;
			gameObject.GetComponent<MeshRenderer>().material.color = color;
			if (color.a <= 0) {
				Destroy (gameObject);
			}
		}
	}
}

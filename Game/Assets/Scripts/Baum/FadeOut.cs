using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour {
	float timer = 0.0f;
    Color color;
	private Material m;

	// Use this for initialization
	void Start () {
		m = gameObject.GetComponent<MeshRenderer>().material;
		m.SetFloat("_Mode", 2);
		m.SetInt ("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
		m.SetInt ("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
		m.DisableKeyword ("_ALPHATEST_ON");
		m.EnableKeyword ("_ALPHABLEND_ON");
		m.DisableKeyword ("_ALPHAPREMULTIPLY_ON");
		m.renderQueue = 3000;
		color = m.color;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer > 5) {
			color.a -= Time.deltaTime;
			gameObject.GetComponent<MeshRenderer>().material.color = color;
			if (color.a <= 0) {
				Destroy (gameObject);
			}
		}
	}
}

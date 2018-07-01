using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baum : MonoBehaviour {
	GameObject obj;
	void Start () {
		obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
		obj.GetComponent<Renderer>().material.color = new Color( 0.0f, 1.0f, 0.0f );
		obj.transform.localScale = new Vector3( 1, 2, 1 );
		obj.transform.Translate( 0, 1, 0 );

		obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
		obj.GetComponent<Renderer>().material.color = new Color( 0.0f, 1.0f, 0.0f );
		obj.transform.localScale = new Vector3( 1, 2, 1 );
		obj.transform.Translate( 0, 2, 0 );
		obj.transform.Rotate( 0, 0, 60 );
		obj.transform.Translate( 0, 1, 0 );

		obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
		obj.GetComponent<Renderer>().material.color = new Color( 0.0f, 1.0f, 0.0f );
		obj.transform.localScale = new Vector3( 1, 2, 1 );
		obj.transform.Translate( 0, 2, 0 );
		obj.transform.Rotate( 0, 120, 60 );
		obj.transform.Translate( 0, 1, 0 );

		obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
		obj.GetComponent<Renderer>().material.color = new Color( 0.0f, 1.0f, 0.0f );
		obj.transform.localScale = new Vector3( 1, 2, 1 );
		obj.transform.Translate( 0, 2, 0 );
		obj.transform.Rotate( 0, 240, 60 );
		obj.transform.Translate( 0, 1, 0 );
	}

	void Update () {
		
	}
}

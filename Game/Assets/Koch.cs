using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Koch : MonoBehaviour {
	GameObject turtle;
	GameObject obj;

	void step () {
		turtle.transform.Translate( 2, 0, 0 );
	}

	void turn ( int alpha ) {
		turtle.transform.Rotate( 0, alpha, 0 );
		step();
	}

	void move () {
		obj = GameObject.CreatePrimitive(PrimitiveType.Quad);
		obj.GetComponent<Renderer>().material.color = new Color( 0.0f, 0.0f, 1.0f );
		obj.transform.localScale = new Vector3( 4, 1, 1 );

		obj.transform.position = turtle.transform.position;
		obj.transform.eulerAngles = turtle.transform.eulerAngles;
		step ();
	}

	void koch ( int k ) {
		if ( k > 1 ) {
			koch( k -1 );
			turn( 60 );
			koch( k - 1 );
			turn( -120 );
			koch( k - 1 );
			turn( 60 );
			koch( k - 1 );
		} else {
			move();
			turn( 60 );
			move();
			turn( -120 );
			move();
			turn( 60 );
			move();
		}
	}

	void Start () {
		turtle = new GameObject(); //Empty Obj
		turtle.transform.localScale = new Vector3( 10, 1, 1 );
		turtle.transform.Translate( 0, 0, 0 );
		turtle.transform.Rotate( 90, 0, 0 );
		koch (3);
	}

	void Update () {
		
	}
}

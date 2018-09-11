using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformations : MonoBehaviour {

	public void transformate(GameObject newLeaf, int rotation)
    {
		newLeaf.transform.localScale = new Vector3(1, 2, 1);
		newLeaf.transform.Rotate( 0, rotation, 0 );
		newLeaf.transform.Translate(0, 1, 0);
		newLeaf.transform.Rotate( 0, 0, 45 );
		newLeaf.transform.Translate(0, 1, 0);
    }

}

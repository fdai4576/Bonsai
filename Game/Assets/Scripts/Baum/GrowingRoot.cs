using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingRoot : MonoBehaviour {

	//Fragt Leertasten-Input ab, um dann Wachstum zu initieren.
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			gameObject.transform.localScale += new Vector3 (0.2f*gameObject.transform.lossyScale.y, 0.2f*gameObject.transform.lossyScale.y, 0.2f*gameObject.transform.lossyScale.y);
		}
	}
}

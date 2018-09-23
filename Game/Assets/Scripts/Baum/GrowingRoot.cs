using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowingRoot : MonoBehaviour {

    private int countSpace;
	public Rigidbody rb;

	//Fragt Leertasten-Input ab, um dann Wachstum zu initieren.
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
            countSpace++;
			gameObject.transform.localScale += new Vector3 (0.2f*gameObject.transform.lossyScale.y, 0.2f*gameObject.transform.lossyScale.y, 0.2f*gameObject.transform.lossyScale.y);
            if(countSpace == 12)
            {
                gameObject.AddComponent<Rigidbody>();
				rb = gameObject.GetComponent<Rigidbody>();
				rb.mass = 4;
				rb.drag = 2;
            }
		}
	}
}
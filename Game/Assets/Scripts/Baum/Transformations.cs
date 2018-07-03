using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transformations : MonoBehaviour {

    //Variablen zur Nachvollziehbarkeit (wirken sich nicht auf
    public Vector3 position; 
    public Vector3 rotation;
    public Vector3 scale;

    public void transformate(GameObject child)
    {

        //Transformationen hier
        //child.transform.Translate(new Vector3(0.0f, 1.0f, 0.0f));
        scale = new Vector3(1.0f, 2.0f, 1.0f);
        child.transform.localScale = scale;

    }

}

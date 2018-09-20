using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializableVector3 {

    public float x;
    public float y;
    public float z;

    public SerializableVector3(float setx, float sety, float setz) {

        x = setx;
        y = sety;
        z = setz;

    }

}

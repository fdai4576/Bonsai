using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializableQuaternion {

    public float x;
    public float y;
    public float z;
    public float w;

    public SerializableQuaternion(float setx, float sety, float setz, float setW) {

        x = setx;
        y = sety;
        z = setz;
        w = setW;

    }

}

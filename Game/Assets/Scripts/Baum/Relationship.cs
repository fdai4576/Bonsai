using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relationship : MonoBehaviour {

    public List<GameObject> children; //Kinder
    public GameObject parent; //Elternteil

    //Verknüpft das GameObject mit seinen Kindern
    public void addChild(GameObject child) {
        children.Add(child);
    }

    //Entfernt ein Kind
    public void delChild(GameObject child) {
        children.Remove(child);
    }

    //Liefert Kinder
    public List<GameObject> getChilds(GameObject parent) {
        return children;
    }

    //verknüpft das GameObject mit seinem Elternteil
    public void setParent(GameObject par) {
        parent = par;
    }

    //Entfernt das Elternteil
    public void delParent() {
        parent = null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relationship : MonoBehaviour {

    public List<GameObject> children; //Kinder
	public GameObject parent; //Elternteil
    public int existingChilds; //vorhandene Kinder

    //Verknüpft das GameObject mit seinen Kindern
    public void addChild(GameObject child) {
        children.Add(child);
        existingChilds++;
    }

    //Setzt den Wert für den Index
    public void setChild(int index, GameObject child) {
        children[index] = child;

        if (child == null)
        {
            existingChilds--;
        }
    }

    //Entfernt ein Kind
    public void delChild(GameObject child) {
        children.Remove(child);
    }

    //Liefert Kinder
    public List<GameObject> getChilds() {
        return children;
    }

	//Liefert Parents
	public GameObject getParent() {
		return parent;
	}

    //verknüpft das GameObject mit seinem Elternteil
    public void setParent(GameObject newParent) {
        parent = newParent;

        
    }

    //Entfernt das Elternteil
    public void delParent() {
        parent = null;
    }
}

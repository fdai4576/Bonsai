using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cut_Part : MonoBehaviour {

    // Use this for initialization
    void Start () {
        
        setRigidbodyChilds(gameObject);

        //wenn es nicht der Stamm ist
        if (gameObject.GetComponent<Relationship>().parent != null) {

            setParent();
            Destroy(gameObject);

        } else {

            //hänge das Update-Skript an den Stamm
            gameObject.AddComponent<Update_Tree>();
        }

    }

    //Lässt den Baum am Elternteil erweiterbar werden und entfernt das gameObject von seinem Elternteil
    void setParent() {

        //hängt das Update_Tree-Skript an das Elternteil
        Relationship relation = gameObject.GetComponent<Relationship>();
        relation.parent.AddComponent<Update_Tree>();

        //Setzt die Referenz des Kindes auf null
        Relationship RSofParent = relation.parent.GetComponent<Relationship>();
        RSofParent.setChild(RSofParent.getChilds().IndexOf(gameObject), null);

    }

    //Fügt rekusiv einen Rigidbody ein, damit die Blätter von der Gravitation beeinflusst werden
    void setRigidbodyChilds(GameObject child) {

        //Hole die Liste aller Kinder
        Relationship relation = child.GetComponent<Relationship>();
        List<GameObject> childs = relation.getChilds();

        //solange es Kinder gibt
        Debug.Log(childs.Count != 0);
        if (childs.Count != 0) {

            //Füge Rigidbody an das GameObjekt an und rufe Funktion mit Kindern auf
            for (int i = 0; i < childs.Count; i++) {

                //solange es ein Kind gibt
                if (childs[i] != null) {

                    //Füge ein Rigidbody an
                    childs[i].AddComponent<Rigidbody>();
                    childs[i].GetComponent<Rigidbody>().drag = 10;
                    Destroy(childs[i].GetComponent<MouseSelection>());
                    Destroy(childs[i].GetComponent<Init_Leaf>());
                    Destroy(childs[i].GetComponent<Transformations>());
                    Destroy(childs[i].GetComponent<Relationship>());
                    childs[i].transform.name += " (abgeschnitten)";

                    //Suche Kinder des Kinds
                    setRigidbodyChilds(childs[i]);

                } else {

                    Update_Tree updateTree = child.GetComponent<Update_Tree>();

                    //solange es in den Kindern noch ein Update_Tree-Skript existiert
                    if (updateTree != null) {

                        //lösche das Skript
                        Destroy(updateTree);

                    }

                }
            }

        } else {

            //Entferne die Erweiterungsmöglichkeit der letzten Kinder
            Destroy(child.GetComponent<Update_Tree>());

        }

        
    }

}

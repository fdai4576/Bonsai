using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cut_Part : MonoBehaviour {

    // Use this for initialization
    void Start () {
        
        //wenn es nicht der Stamm ist
        if (gameObject.GetComponent<Relationship>().parent != null) {

            setParent();
            gameObject.AddComponent<Rigidbody>();
            setRigidbodyChilds(gameObject);

        } else {

            //hänge das Update-Skript an den Stamm
            gameObject.AddComponent<Update_Tree>();

            //Hole die Liste aller Kinder des ausgewählten Objects
            Relationship relation = gameObject.GetComponent<Relationship>();
            List<GameObject> childs = relation.getChilds();

            foreach (GameObject go in childs)
            {
                go.AddComponent<Rigidbody>();
                setRigidbodyChilds(gameObject);
            }

        }

    }

    //Lässt den Baum am Elternteil erweiterbar werden und entfernt das gameObject von seinem Elternteil
    void setParent() {

        //hängt das Update_Tree-Skript an das Elternteil
        Relationship relation = gameObject.GetComponent<Relationship>();
        relation.getParent().AddComponent<Update_Tree>();

        //Entfernen des Kindes vom Elternteil
        Relationship RSofParent = relation.parent.GetComponent<Relationship>();
        RSofParent.setChild(RSofParent.getChilds().IndexOf(gameObject), null);

        //Einfügen des Blattes, wenn kein Blatt mehr vorhanden ist
        if(RSofParent.existingChilds == 0) {

            string leafPath = "Assets/Prefabs/Blatt.prefab";
            GameObject leaf = (GameObject)UnityEditor.AssetDatabase.LoadAssetAtPath(leafPath, typeof(GameObject));

            GameObject newLeaf = Instantiate<GameObject>(leaf, relation.parent.transform.position, relation.parent.transform.rotation);

            //Realtionship-Skript des Kind-Objekts aufrufen + setzen des Elternteils
            Relationship newRelation = newLeaf.GetComponent<Relationship>();

            newRelation = RSofParent;

            //Verbindung mit dem TransformObject-Skript
            Transformations newTransformations = newLeaf.GetComponent<Transformations>();
            newTransformations = relation.parent.GetComponent<Transformations>();

            Destroy(relation.parent);

        }

            


    }

    //Fügt rekusiv einen Rigidbody ein, damit die Blätter von der Gravitation beeinflusst werden
    void setRigidbodyChilds(GameObject child) {

        //Hole die Liste aller Kinder
        Relationship relation = child.GetComponent<Relationship>();
        List<GameObject> childs = relation.getChilds();

        //solange es Kinder gibt
        if (childs.Count != 0) {

            //Füge Rigidbody an das GameObjekt an und rufe Funktion mit Kindern auf
            for (int i = 0; i < childs.Count; i++) {

                //solange es ein Kind gibt
                if (childs[i] != null) {

                    //Füge ein Rigidbody an
                    Rigidbody parent_rb = child.GetComponent<Rigidbody>();
                    childs[i].AddComponent<Rigidbody>();
                    childs[i].GetComponent<Rigidbody>().drag = 3;

                    //Füge ein Joint zum Elternobjekt ein
                    FixedJoint children_joint = childs[i].AddComponent<FixedJoint>();
                    children_joint.connectedBody = parent_rb;
                    children_joint.enableCollision = false;

                    //Entferne unnötige Skripte
                    Destroy(childs[i].GetComponent<MouseSelection>());
                    Destroy(childs[i].GetComponent<Init_Leaf>());
                    Destroy(childs[i].GetComponent<Transformations>());
                    Destroy(childs[i].GetComponent<Relationship>());

                    //Markiere das Objekt als abgeschnitten
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

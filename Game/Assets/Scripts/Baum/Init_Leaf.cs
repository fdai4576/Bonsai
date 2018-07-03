using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init_Leaf : MonoBehaviour {

    //Erzeugt Kinder
    public void instatiateObject(GameObject clone)
    {
        
        //Prefab instanzieren
        GameObject newLeaf = Instantiate<GameObject>(clone, this.transform.position, this.transform.rotation);

        //Realtionship-Skript das derzeitigen Objekts aufrufen + Eintragen der Kinder
        Relationship relation = this.GetComponent<Relationship>();
        relation.addChild(newLeaf);

        //Realtionship-Skript des Kind-Objekts aufrufen + setzen des Elternteils
        Relationship relation_child = newLeaf.GetComponent<Relationship>();
        relation_child.setParent(gameObject);

        //Verbindung mit dem TransformObject-Skript
        Transformations transformations = newLeaf.GetComponent<Transformations>();
        transformations.transformate(newLeaf);

        newLeaf.transform.name = "Blatt";

    }

}

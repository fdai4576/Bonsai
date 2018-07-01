using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	public GameObject obj;
    public Relationship relation;

	void Start () {

        //Verbindung mit dem Skript
        relation = this.GetComponent<Relationship>();

    }


    //Erzeugt Kinder
    void instatiateObject() {

        //Wechsel Name aktuelle Instanz
        obj.transform.name = "Ast";

        //Erzeuge 3 neue Instanzen als Kindobj mit neuem Namen
        for (int i = 0; i < 3; i++)
        {

            //Im Projekt muss das Prefab zugewiesen werden
            obj = Instantiate(obj, this.transform.position, this.transform.rotation); 


            setRelation(obj, gameObject);

            //Übertragen von Position und
            obj.transform.position = this.transform.position;
            obj.transform.rotation = this.transform.rotation;

            transformation(obj);
            
            obj.transform.name = "Blatt";

        }
        
    }

    //Setzt Kind und Elternteil
    void setRelation(GameObject child, GameObject parent) {

        //Setzt Kind
        relation.SendMessage("addChild", child);

        //Setzt Elternteil
        relation.SendMessage("setParent", parent);

    }

    void transformation(GameObject child) {

        //Transformationen hier
        //obj.transform.Translate(new Vector3(0.0f, 1.0f, 0.0f));
        obj.transform.localScale = new Vector3(1.0f, 2.0f, 1.0f);

    }

    void Update () {

		if (Input.GetKeyDown(KeyCode.Space)) {

            instatiateObject();

			//Vernichte Script nach einmaligen Einsatz
			Destroy(GetComponent<Test>());
		}
	}
}

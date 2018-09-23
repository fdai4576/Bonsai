using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakTable : MonoBehaviour {

    public int space_hits;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            space_hits++;
            if (space_hits >= 12)
            {
                foreach (Transform child in gameObject.transform) {
                    child.gameObject.AddComponent<Rigidbody>();
                }
                gameObject.GetComponent<AudioSource>().PlayDelayed(0);
            }
        }

    }
}

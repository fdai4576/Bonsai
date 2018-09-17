using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IngameMenu : MonoBehaviour {

	public void escButton() {
        SceneManager.LoadSceneAsync(0);
		Debug.Log ("ESC-Button pressed");
	}

}
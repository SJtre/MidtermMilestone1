using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

	int scene = SceneManager.GetActiveScene().buildIndex;

	// Update is called once per frame
	void Update () {
		

		if (Input.GetKeyDown (KeyCode.R)) {
			SceneManager.LoadScene (scene, LoadSceneMode.Single);
			Time.timeScale = 1;
		}
	}
}

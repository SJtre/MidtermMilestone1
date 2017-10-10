using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GoalTriggerR : MonoBehaviour {

	public bool goalRCheck = false;

	void Update() {

		if (goalRCheck && GameObject.Find ("TriggerB").GetComponent<GoalTriggerB> ().goalBCheck && GameObject.Find ("TriggerG").GetComponent<GoalTriggerG> ().goalGCheck) {
			GameObject.Find ("Text").GetComponent<Text> ().text = "Wow! Every book is on the correct shelf!";
		} else {
			//GameObject.Find ("Text").GetComponent<Text> ().text = "Place all of the Spheres on the correct Cubes.";
		}
	}

	void OnTriggerEnter(Collider activator) {
		Debug.Log("Entrance.");
		if (activator.gameObject == GameObject.Find ("Sphere Red")) {
			Debug.Log ("Correct Sphere Entered.");
			goalRCheck = true;
			GameObject.Find ("Text").GetComponent<Text> ().text = "That's the right book!";
		} else {
			GameObject.Find ("Text").GetComponent<Text> ().text = "That's the not right book!";
		}
	}
	void OnTriggerExit(Collider activator) {
		Debug.Log("Exit.");
		if (activator.gameObject == GameObject.Find ("Sphere Red")) {
			Debug.Log ("Correct Sphere Exited.");
			goalRCheck = false;
			GameObject.Find ("Text").GetComponent<Text> ().text = "Place the books on the correct shelves.";
		}
	}
}


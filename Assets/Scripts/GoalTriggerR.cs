using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GoalTriggerR : MonoBehaviour {

	public bool goalRCheck = false;
	public int goalRpoint;

	void Update() {

		if (goalRpoint == 5) {
			goalRCheck = true;
		} else {
			goalRCheck = false;
		}

		if (goalRCheck && GameObject.Find ("TriggerB").GetComponent<GoalTriggerB> ().goalBCheck && GameObject.Find ("TriggerG").GetComponent<GoalTriggerG> ().goalGCheck) {
			GameObject.Find ("Text").GetComponent<Text> ().text = "Wow! Every book is on the correct shelf!";
		} else {
			//GameObject.Find ("Text").GetComponent<Text> ().text = "Place all of the Spheres on the correct Cubes.";
		}
	}

	void OnTriggerEnter(Collider activator) {
		Debug.Log("Entrance.");
		if (activator.tag == ("PointObjectR")) {
			Debug.Log ("Correct Book Entered.");
			goalRpoint += 1;
			Debug.Log ("goalRpoint =" + goalRpoint);
			//goalRCheck = true;
			GameObject.Find ("Text").GetComponent<Text> ().text = "That's the right book!";
		} else {
			GameObject.Find ("Text").GetComponent<Text> ().text = "That's the not right book!";
		}
	}
	void OnTriggerExit(Collider activator) {
		Debug.Log("Exit.");
		if (activator.tag == ("PointObjectR")) {
			Debug.Log ("Correct Book Exited.");
			goalRpoint -= 1;
			Debug.Log ("goalRpoint =" + goalRpoint);
			//goalRCheck = false;
			GameObject.Find ("Text").GetComponent<Text> ().text = "Place the books on the correct shelves.";
		}
	}
}


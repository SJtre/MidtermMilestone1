using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GoalTriggerG : MonoBehaviour {

	public bool goalGCheck = false;
	public int goalGpoint;

	void Update() {
		
		if (goalGpoint == 5) {
			goalGCheck = true;
		} else {
			goalGCheck = false;
		}

		if (goalGCheck && GameObject.Find ("TriggerR").GetComponent<GoalTriggerR> ().goalRCheck && GameObject.Find ("TriggerB").GetComponent<GoalTriggerB> ().goalBCheck) {
			GameObject.Find ("Text").GetComponent<Text> ().text = "Wow! Every book is on the correct shelf!";
		} else {
			//GameObject.Find ("Text").GetComponent<Text> ().text = "Place all of the Spheres on the correct Cubes.";
		}
	}

	void OnTriggerEnter(Collider activator) {
		Debug.Log("Entrance.");
		if (activator.tag == ("PointObjectG")) {
			Debug.Log ("Correct Book Entered.");
			goalGpoint += 1;
			Debug.Log ("goalGpoint =" + goalGpoint);
			//goalGCheck = true;
			GameObject.Find ("Text").GetComponent<Text> ().text = "That's the right book!";
		} else {
			GameObject.Find ("Text").GetComponent<Text> ().text = "That's the not right book!";
		}
	}
	void OnTriggerExit(Collider activator) {
		Debug.Log("Exit.");
		if (activator.tag == ("PointObjectG")) {
			Debug.Log ("Correct Book Exited.");
			goalGpoint -= 1;
			Debug.Log ("goalGpoint =" + goalGpoint);
			//goalGCheck = false;
			GameObject.Find ("Text").GetComponent<Text> ().text = "Place the books on the correct shelves.";
		}
	}
}

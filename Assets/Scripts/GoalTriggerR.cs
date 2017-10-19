using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GoalTriggerR : MonoBehaviour {

	public bool goalRCheck = false;
	public int goalRpoint;

	void Update() {

		if (goalRpoint == 3) {
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
			GameObject.Find ("Score").GetComponent<Text> ().text = "Green: " + GameObject.Find ("TriggerG").GetComponent<GoalTriggerG> ().goalGpoint 
				+ "/3\n Blue: " + GameObject.Find ("TriggerB").GetComponent<GoalTriggerB> ().goalBpoint 
				+ "/3\n Red: " + goalRpoint + "/3";
		} else {
			GameObject.Find ("Text").GetComponent<Text> ().text = "That's not right!";
		}
	}
	void OnTriggerExit(Collider activator) {
		Debug.Log("Exit.");
		if (activator.tag == ("PointObjectR")) {
			Debug.Log ("Correct Book Exited.");
			goalRpoint -= 1;
			Debug.Log ("goalRpoint =" + goalRpoint);
			//goalRCheck = false;
			GameObject.Find ("Text").GetComponent<Text> ().text = "Oh no! The book isn't on the right shelf anymore!";
			GameObject.Find ("Score").GetComponent<Text> ().text = "Green: " + GameObject.Find ("TriggerG").GetComponent<GoalTriggerG> ().goalGpoint 
				+ "/3\n Blue: " + GameObject.Find ("TriggerB").GetComponent<GoalTriggerB> ().goalBpoint 
				+ "/3\n Red: " + goalRpoint + "/3";
		}
	}
}


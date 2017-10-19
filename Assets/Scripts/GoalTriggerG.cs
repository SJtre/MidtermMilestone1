using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GoalTriggerG : MonoBehaviour {

	public bool goalGCheck = false;
	public int goalGpoint;

	void Update() {
		
		if (goalGpoint == 3) {
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
			GameObject.Find ("Score").GetComponent<Text> ().text = "Green: " + goalGpoint 
			+ "/3\n Blue: "+ GameObject.Find ("TriggerB").GetComponent<GoalTriggerB> ().goalBpoint 
			+ "/3\n Red: " + GameObject.Find ("TriggerR").GetComponent<GoalTriggerR> ().goalRpoint + "/3";
		} else {
			GameObject.Find ("Text").GetComponent<Text> ().text = "That's not right!";
		}
	}
	void OnTriggerExit(Collider activator) {
		Debug.Log("Exit.");
		if (activator.tag == ("PointObjectG")) {
			Debug.Log ("Correct Book Exited.");
			goalGpoint -= 1;
			Debug.Log ("goalGpoint =" + goalGpoint);
			//goalGCheck = false;
			GameObject.Find ("Text").GetComponent<Text> ().text = "Oh no! The book isn't on the right shelf anymore!";
			GameObject.Find ("Score").GetComponent<Text> ().text = "Green: " + goalGpoint 
				+ "/3\n Blue: "+ GameObject.Find ("TriggerB").GetComponent<GoalTriggerB> ().goalBpoint 
				+ "/3\n Red: " + GameObject.Find ("TriggerR").GetComponent<GoalTriggerR> ().goalRpoint + "/3";
		}
	}
}

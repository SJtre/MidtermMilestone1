using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GoalTriggerB : MonoBehaviour {

	public bool goalBCheck = false;
	public int goalBpoint;

    void Update() {

		if (goalBpoint == 3) {
			goalBCheck = true;
		} else {
			goalBCheck = false;
		}
       
		if (goalBCheck && GameObject.Find ("TriggerG").GetComponent<GoalTriggerG> ().goalGCheck && GameObject.Find ("TriggerR").GetComponent<GoalTriggerR> ().goalRCheck) {
			GameObject.Find ("Text").GetComponent<Text> ().text = "Wow! Every book is on the correct shelf!";
		} else {
			//GameObject.Find ("Text").GetComponent<Text> ().text = "Place all of the Spheres on the correct Cubes.";
		}
    }

    void OnTriggerEnter(Collider activator) {
        Debug.Log("Entrance.");
		if (activator.tag == ("PointObjectB")) {
			Debug.Log ("Correct Book Entered.");
			goalBpoint += 1;
			Debug.Log ("goalBpoint =" + goalBpoint);
			//goalBCheck = true;
			GameObject.Find ("Text").GetComponent<Text> ().text = "That's the right book!";
			GameObject.Find ("Score").GetComponent<Text> ().text = "Green: " + GameObject.Find ("TriggerG").GetComponent<GoalTriggerG> ().goalGpoint 
				+ "/3\n Blue: " + goalBpoint 
				+ "/3\n Red: " + GameObject.Find ("TriggerR").GetComponent<GoalTriggerR> ().goalRpoint + "/3";
		} else {
			GameObject.Find ("Text").GetComponent<Text> ().text = "That's not right!";
		}
    }
    void OnTriggerExit(Collider activator) {
        Debug.Log("Exit.");
		if (activator.tag == ("PointObjectB")) {
			Debug.Log ("Correct Book Exited.");
			goalBpoint -= 1;
			Debug.Log ("goalBpoint =" + goalBpoint);
			//goalBCheck = false;
			GameObject.Find ("Text").GetComponent<Text> ().text = "Oh no! The book isn't on the right shelf anymore!";
			GameObject.Find ("Score").GetComponent<Text> ().text = "Green: " + GameObject.Find ("TriggerG").GetComponent<GoalTriggerG> ().goalGpoint 
				+ "/3\n Blue: " + goalBpoint 
				+ "/3\n Red: " + GameObject.Find ("TriggerR").GetComponent<GoalTriggerR> ().goalRpoint + "/3";
		}
    }
}

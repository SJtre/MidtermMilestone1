using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GoalTriggerB : MonoBehaviour {

	public bool goalBCheck = false;
	public int goalBpoint;

    void Update() {

		if (goalBpoint == 5) {
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
		} else {
			GameObject.Find ("Text").GetComponent<Text> ().text = "That's the not right book!";
		}
    }
    void OnTriggerExit(Collider activator) {
        Debug.Log("Exit.");
		if (activator.tag == ("PointObjectB")) {
			Debug.Log ("Correct Book Exited.");
			goalBpoint -= 1;
			Debug.Log ("goalBpoint =" + goalBpoint);
			//goalBCheck = false;
			GameObject.Find ("Text").GetComponent<Text> ().text = "Place the books on the correct shelves.";
		}
    }
}

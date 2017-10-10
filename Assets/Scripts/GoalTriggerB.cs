using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GoalTriggerB : MonoBehaviour {

	public bool goalBCheck = false;

    void Update() {
       
		if (goalBCheck && GameObject.Find ("TriggerG").GetComponent<GoalTriggerG> ().goalGCheck && GameObject.Find ("TriggerR").GetComponent<GoalTriggerR> ().goalRCheck) {
			GameObject.Find ("Text").GetComponent<Text> ().text = "Wow! Every book is on the correct shelf!";
		} else {
			//GameObject.Find ("Text").GetComponent<Text> ().text = "Place all of the Spheres on the correct Cubes.";
		}
    }

    void OnTriggerEnter(Collider activator) {
        Debug.Log("Entrance.");
		if (activator.gameObject == GameObject.Find("Sphere Blue")) {
			Debug.Log ("Correct Sphere Entered.");
			goalBCheck = true;
			GameObject.Find ("Text").GetComponent<Text> ().text = "That's the right book!";
		} else {
			GameObject.Find ("Text").GetComponent<Text> ().text = "That's the not right book!";
		}
    }
    void OnTriggerExit(Collider activator) {
        Debug.Log("Exit.");
		if (activator.gameObject == GameObject.Find ("Sphere Blue")) {
			Debug.Log ("Correct Sphere Exited.");
			goalBCheck = false;
			GameObject.Find ("Text").GetComponent<Text> ().text = "Place the books on the correct shelves.";
		}
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GoalTrigger : MonoBehaviour {

    void Start() {
       
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("Triggered.");
        GameObject.Find("Text").GetComponent<Text>().text = "Hey, good job!";
    }
    void OnTriggerExit(Collider other)
    {
        Debug.Log("Exited.");
        GameObject.Find("Text").GetComponent<Text>().text = "Place the Sphere on Cube.";
    }
}

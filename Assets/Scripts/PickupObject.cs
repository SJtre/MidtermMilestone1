﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour {
    GameObject mainCamera;
    bool carrying;
    GameObject carriedObject;
    public float distance;
    public float smooth;
	// Use this for initialization
	void Start () {
        mainCamera = GameObject.FindWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
        if (carrying) {
            carry(carriedObject);
            checkDrop();
        } else {
            pickup();
        }
		
	}

    void carry(GameObject o) {
        o.transform.position = Vector3.Lerp (o.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * smooth);
    }

    void pickup() {
        if(Input.GetKeyDown (KeyCode.E)) {
            int x = Screen.width / 2;
            int y = Screen.height / 2;

            Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit)) {
                Pickupable p = hit.collider.GetComponent<Pickupable>();
                if(p != null && Vector3.Distance(p.gameObject.transform.position, mainCamera.transform.position) < 3) {
                    carrying = true;
                    carriedObject = p.gameObject;
                    p.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                }
            }

        }
    
    }

    void checkDrop() {
        if (Input.GetKeyDown(KeyCode.E)) {
            dropObject();
        }
    }

    void dropObject() {
        carrying = false;
        carriedObject.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        carriedObject = null;
    }
}

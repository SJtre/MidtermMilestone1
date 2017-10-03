using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

    public float mouseSensitivity = 100f;
    float verticalLookAngle = 0f;

    // Update is called once per frame
    void Update() {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity; // horizontal mouse movement
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity; // vertical mouse movement

        // apply rotations to the Camera transform
        // transform.Rotate( -mouseY, mouseX, 0f); // rotate up/down for my Camera
        transform.parent.Rotate( 0f, mouseX, 0f);

        // new vertical looking up/down code:
        verticalLookAngle -= mouseY;
        verticalLookAngle = Mathf.Clamp(verticalLookAngle, -89f, 89f); // don't ;et player look straight up or down
       

        // correction pass: unroll the camera - straight it back upright
        // transform.localEulerAngles.z = 0f; // THIS IS WHAT WE WANT TO DO, BUT THIS WILL NOT WORK

        transform.localEulerAngles = new Vector3(
            verticalLookAngle, // overriding the X andle with my verticalLookAngle, always
            transform.localEulerAngles.y, // put Y back into itself
            0f // overriding the Z angle with 0, alwyas, to unroll the camera
            );

        // lock the mouse cursor and hide it for GREATER IMMERSION
        if ( Input.GetMouseButtonDown( 0 ) ) { // did they left-click their mouse?
            Cursor.visible = false; // hides the mouse cursor, but doesn't lock it
            Cursor.lockState = CursorLockMode.Locked; // actually locks cursor in center of screen
        }

        if ( Input.GetKeyDown( KeyCode.Escape ) ) {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        // TODO:
        // x increase mouse sensitivity
        // x movement is based on the cube's facing, not the camera's facing
        // x when you look straight up and down, you enter a new plane of existence / you spin around a lot

    }
       
}


    

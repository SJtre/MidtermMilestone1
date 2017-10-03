using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TreasureHunt : MonoBehaviour {

    public Text huntHints;
    public GameObject playerChar;
    public GameObject landmark1;
    public GameObject landmark2;
    public GameObject landmark3;
    public GameObject landmark4;
    public GameObject landmark5;

    bool atTreasure = false;
    bool winKey = false;

    // Update is called once per frame
    void Update () {
        huntHints = GetComponent<Text>();

        playerChar = GameObject.Find("Player");
        landmark1 = GameObject.Find("Landmark1");
        landmark2 = GameObject.Find("Landmark2");
        landmark3 = GameObject.Find("Landmark3");
        landmark4 = GameObject.Find("Landmark4");
        landmark5 = GameObject.Find("Landmark5");

        if (atTreasure == true)
        {
            Debug.Log("Found the Treasure");
        }

        Debug.Log(playerChar.transform.position);

        if (Vector3.Distance(playerChar.transform.position, landmark1.transform.position) > 10f)
        { 
            huntHints.text = "Let's find something to eat!";
        }
        else if (Vector3.Distance(playerChar.transform.position, landmark1.transform.position) < 10f)
        {
            huntHints.text = "Is this a huge, green donut?! Let's find something else to eat.";
        }

        if (Vector3.Distance(playerChar.transform.position, landmark2.transform.position) < 10f)
        {
            huntHints.text = "Now a green birthday cake! No, but what's that to the east?";
        }

        if (Vector3.Distance(playerChar.transform.position, landmark3.transform.position) < 10f)
        {
            huntHints.text = "Green snow cone?! Is that something to drink to the northwest?";
        }

        if (Vector3.Distance(playerChar.transform.position, landmark4.transform.position) < 10f)
        {
            huntHints.text = "A GENERIC GREEN DRINK?! What's that to the northwest?";
        }

        if (Vector3.Distance(playerChar.transform.position, landmark5.transform.position) < 10f)
        {
            huntHints.text = "*sigh* A bowl of spinach... Press SPACEBAR to win?";
            atTreasure = true;
        }

        if ( (atTreasure == true) && (Input.GetKey(KeyCode.Space)) )
        {
            winKey = true;
        }

        if (winKey == true)
        {
            huntHints.text = "You win!";
        }
    }
}

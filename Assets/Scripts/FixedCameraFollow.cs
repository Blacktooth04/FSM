using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedCameraFollow : MonoBehaviour {

    // create the player game object
    GameObject player;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        //print("Found player: " + player);
	}
	
	// Update is called once per frame
    // Late update ensure the camera updates after the player
	void LateUpdate () {

        // TODO IMPLEMENT ZOOM FUNCTION WITH MOUSE WHEEL
        // wanting the zoom function to save the z and y values
        // initially z = -7.5, y = 5.19



        // lock on player
        transform.position = player.transform.position;

    }
}

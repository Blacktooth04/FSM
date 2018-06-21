using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour {

	public Transform player;
	Animator anim;

	[SerializeField] float rotationSpeed = 2.0f;
    [SerializeField] float speed = 2.0f;
    [SerializeField] float visibilityDistance = 20.0f; // how far the npc can see
    [SerializeField] float visibilityAngle = 30.0f; // the FOV of the NPC
    [SerializeField] float shootingDistance = 5.0f; // how close to be until npc can shoot

	string state = "IDLE";

	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        // direction from NPC to player
		Vector3 direction = player.position - this.transform.position;
        // calculate the angle to see if player is withing FOV
		float angle = Vector3.Angle(direction, this.transform.forward);

        // if the lenght of the direction is within the visibility distance
        // and angle is withing the visibility angle
		if(direction.magnitude < visibilityDistance && angle < visibilityAngle)
		{
            // ignore y vector
			direction.y = 0;
            // rotate smoothly
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
			    Quaternion.LookRotation(direction), Time.deltaTime * rotationSpeed);

            // control animations
			if(direction.magnitude > shootingDistance)
			{ 
                // if not running, run
				if(state != "RUNNING")
				{ 
					state = "RUNNING";	
					anim.SetTrigger("isRunning");
				}	
			} else
			{
                // if not shooting, shoot
				if(state != "SHOOTING")
				{ 
					state = "SHOOTING";
					anim.SetTrigger("isShooting");
				}
			}

		} else
		{
			if(state != "IDLE")
			{ 
				state = "IDLE";
				anim.SetTrigger("isIdle");
			}
		}

        // if is running, move
		if(state == "RUNNING")
			this.transform.Translate(0,0, Time.deltaTime * speed);

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : NPCBaseFSM {

    GameObject[] waypoints;
    int currentWaypoint;

    // call on awake to populate waypoint list
    private void Awake()
    {
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex); // set up NPC
        currentWaypoint = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // if there are no waypoints, exit
        if (waypoints.Length == 0)
            return;

        // if NPC is within the accuracy of the waypoint
        if (Vector3.Distance(waypoints[currentWaypoint].transform.position,
            NPC.transform.position) < accuracy)
        {
            // get a new waypoint
            currentWaypoint++;
            // if at the end, restart
            if (currentWaypoint >= waypoints.Length)
                currentWaypoint = 0;
        }


        agent.SetDestination(waypoints[currentWaypoint].transform.position);

        // USE THIS IF NOT USING NAVMESH
        //// calculate the direction of npc
        //var direction = waypoints[currentWaypoint].transform.position - NPC.transform.position;
        //// rotate towards target
        //NPC.transform.rotation = Quaternion.Slerp(NPC.transform.rotation,
        //    Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
        //// move in the z axis
        //NPC.transform.Translate(0, 0, Time.deltaTime * speed);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}

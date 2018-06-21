# FSM

This project was one that I completed in order to get a grasp on Unity's state machine. 

The line of sight scene was just a test to work out some scripts for adding LOS to npc's.

The other two I created the entire animation controller. The enemy patrols an area until it sights the player. 
It then chases the player and when in range, attacks. If the player is out of range the tank resumes it's patrol.
The patrol path is dictated by waypoints. In one scene, I had the npc follow a set path for pathfinding. The other
uses Navmesh. The code to change between is in the Patrol script.
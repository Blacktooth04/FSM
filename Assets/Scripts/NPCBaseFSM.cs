using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBaseFSM : StateMachineBehaviour {

    public UnityEngine.AI.NavMeshAgent agent;
    public GameObject NPC;
    public GameObject enemy;
    public float speed = 4.0f;
    public float rotationSpeed = 1.0f;
    public float accuracy = 3.0f;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NPC = animator.gameObject;
        enemy = NPC.GetComponent<EnemyTankAI>().GetPlayer();
        agent = NPC.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Recover : StateMachineBehaviour
{
    GameObject npc;
    GameObject health; 
    UnityEngine.AI.NavMeshAgent agent;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        npc = animator.gameObject;
        health = GameObject.Find("Health");
        agent = npc.GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.speed = 7.0f;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(health.transform.position);
    }
    
}

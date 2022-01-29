using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : StateMachineBehaviour
{
    GameObject npc;
    GameObject[] waypoints;
    NavMeshAgent agent;
    int wpIndex = 0;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //H�mtar referencen till datorstrydra robotens spelobjekt
        npc = animator.gameObject;
        waypoints = GameObject.FindGameObjectsWithTag("waypoints");
        agent = npc.GetComponent<NavMeshAgent>();

        wpIndex = Random.Range(0, waypoints.Length - 1);
        agent.SetDestination(waypoints[wpIndex].transform.position);
        agent.speed = 3.5f;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Vector3.Distance(npc.transform.position, waypoints[wpIndex].transform.position) < 0.5f)
        {
            wpIndex = Random.Range(0, waypoints.Length - 1);
        }

        agent.SetDestination(waypoints[wpIndex].transform.position);

    }
}

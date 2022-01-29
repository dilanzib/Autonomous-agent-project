using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackEnemy : StateMachineBehaviour
{
    GameObject npc;
    GameObject enemy; 
    NavMeshAgent agent;
    
    public GameObject projectile; 
    public float launchVelocity = 300f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        npc = animator.gameObject;
        enemy = GameObject.Find("Enemy");
        agent = npc.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    { 
        GameObject ball = Instantiate(projectile, npc.transform.position, npc.transform.rotation); //creating projectiles 
        ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0,launchVelocity));
        
        Object.Destroy(ball, 2.0f);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumanRobot : MonoBehaviour
{
    Animator stateMachine;

    UnityEngine.AI.NavMeshAgent agent;

    float speed = 0.16f;
    float rotSpeed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, 0, speed);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, 0, -speed);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -rotSpeed, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, rotSpeed, 0);
        }

    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotAI : MonoBehaviour
{
    Animator stateMachine;
    GameObject enemy;
    GameObject npc;

    public HealthBar healthbar;
    int maxHealth = 100;
    public int currentHealth;


    void Start()
    {
        stateMachine = GetComponent<Animator>();
        enemy = GameObject.Find("Enemy");
        npc = GameObject.Find("NPC");

        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //Om fienden är tillräckligt nära, går den över till chase-mode 
        if(Vector3.Distance(transform.position, enemy.transform.position) < 10) 
        {
            stateMachine.SetBool("EnemyIsClose", true);
                //Om fienden är väldigt nära går den över till shoot-mode 
                if(Vector3.Distance(transform.position, enemy.transform.position) < 5){
                    stateMachine.SetBool("ShootEnemy", true);
                } else {
                    stateMachine.SetBool("ShootEnemy", false); //här kollar den runt i 360
                
                    if(Vector3.Distance(transform.position, enemy.transform.position) < 10) { 
                        stateMachine.SetBool("BackTo", true); //är det mindre än 10 mellan dem så jaga den pånytt
                    } else {
                        stateMachine.SetBool("Patrol", true);  //är det mer än 10 så gå på promenad
                    } 
                }
        } else {
            stateMachine.SetBool("EnemyIsClose", false);
        }

        if(currentHealth <= 30)  {
            if (currentHealth < 0){ //om hälsan blir mindre än 0
                currentHealth = 0; //....lägg ändå elikamed till 0 så att de inte blir på minus sidan
                healthbar.SetHealth(currentHealth); 
            }
            stateMachine.SetBool("Recover", true);

        } else  {
            stateMachine.SetBool("Recover", false);
        } 
    }

    void OnCollisionEnter (Collision col) 
    {
        if(col.gameObject.tag == "health") {
            getLife(50);
        } else if (col.gameObject.tag == "clone") {
            TakeDamage(10);
        }
    }

    void TakeDamage(int damage)
        {
            currentHealth -= damage;
            healthbar.SetHealth(currentHealth);
        }

    void getLife(int life)
        {
            currentHealth += life;
            healthbar.SetHealth(currentHealth);
        }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchProjectile : MonoBehaviour
{
    public GameObject projectile; 
    public float launchVelocity = 300f;

    void Start()
    {

    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1")) //trycker ner leftmouse, "Fire1" betyder leftmouse-click  
        { 
            GameObject ball = Instantiate(projectile, transform.position, transform.rotation); //creating projectiles 
            ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0,launchVelocity));
            ball.gameObject.tag = "clone"; //sätter de nya bollarna till att få tagen "clone"

            Object.Destroy(ball, 5.0f); 
        }
    }


}

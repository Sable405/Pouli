using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
 
    void Start()
    {
 
    }
 
    void Update()
    {
 
        if (Vector3.Distance(player.position, this.transform.position) < 10) //if player comes within a distance less than 10, Apex activates
        {
            Vector3 direction = player.position - this.transform.position;
        //right now this causes Apex to face the player with its stinger. this will be useful for the virus effected, but wasn't what I was going for
 
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                            Quaternion.LookRotation(direction), 0.1f); //same as above note. not sure what went wrong
 
    if(direction.magnitude > 5)
    {
        this.transform.Translate(0,0,0.05f); //this is supposed to stop the chasing and make Apex sit right side up again if the player moves far enough away. so far it just stops chasing
    }
 
        }
 
    }
 
}



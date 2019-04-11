using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class to play grow/shrink animation when close to moon stone
public class CollectableProximity : MonoBehaviour
{

    // Member variable that controls the stone's animation
	private Animator anim;

    // Set animation speed to 0
    void Start()
    {
        anim = GetComponent<Animator>();

        if (anim == null)
            Debug.Log("Animator could not be found");

        anim.speed = 0;
    }

    // When collider is triggered, set animation speed to 1
    void OnTriggerEnter(Collider c) {
        // Check if the collider is from the player
        if (c.CompareTag("Player"))
        anim.speed = 1;
    }

    // When collider is exited, set animation speed to 0
    void OnTriggerExit(Collider c) {
        if (c.CompareTag("Player")) {
            anim.Play("ApproachCollectable",0,0.0f);
            anim.speed = 0;
        }
    }
}

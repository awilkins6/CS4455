using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class to remove stone from game when collider is triggered
public class CollectablePickUp : MonoBehaviour
{


    // When collider is triggered, remove parent game object from game
    void OnTriggerEnter(Collider c) {
        if (c.CompareTag("The Player"))
        this.transform.parent.gameObject.SetActive(false);

        // Increment the number of points collected
        // Global variable points += 1, for example
    }
}

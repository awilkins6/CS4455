using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class to remove cockpit ship part from game when collected
public class CockpitPickUp : MonoBehaviour
{


    // When collider is triggered, remove parent game object from game
    void OnTriggerEnter(Collider c) {
        if (c.CompareTag("Player"))
        this.transform.parent.gameObject.SetActive(false);

        // Store that the cockpit was now collected
        CockpitTextScript.setToFound();
    }
}

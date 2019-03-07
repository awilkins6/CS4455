using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class to remove satellite ship part from game when collected
public class SatellitePickUp : MonoBehaviour
{


    // When collider is triggered, remove parent game object from game
    void OnTriggerEnter(Collider c) {
        if (c.CompareTag("The Player"))
        this.transform.parent.gameObject.SetActive(false);

        // Store that the satellite was now collected
        // SatelliteCollected = true, for example
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class to play grow/shrink animation when close to moon stone
public class CollectableProximity : MonoBehaviour {
  void OnTriggerStay(Collider c) {
  	// Check if the collider is from the player
      if (c.CompareTag("Player")) {
        // anim.speed = 1;
        transform.position = Vector3.Lerp(transform.position, c.transform.position, 0.2f);
      }
  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class to remove cockpit ship part from game when collected
public class PartPickUpScript : MonoBehaviour
{

    public bool found = false;
    public AudioSource pickUpJingle;
    GameObject gameManager;

    void Start() {
      gameManager = GameObject.FindWithTag("GameManager");
    }

    // When collider is triggered, remove parent game object from game
    void OnTriggerEnter(Collider c) {
        if (c.CompareTag("Player")) {
          GameManagerScript2.togglePart();
          found = true;
          gameObject.SetActive(false);
          gameManager.GetComponent<GameManagerScript2>().UpdateParts();
        }
    }

    void OnCollisionEnter(Collision c) {
      pickUpJingle.Play();
    }
}

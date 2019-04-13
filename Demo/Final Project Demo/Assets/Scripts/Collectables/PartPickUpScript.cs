using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class to remove cockpit ship part from game when collected
public class PartPickUpScript : MonoBehaviour
{

    public bool found = false;
    GameObject gameManager;

    void Start() {
      gameManager = GameObject.FindWithTag("GameManager");
    }

    // When collider is triggered, remove parent game object from game
    void OnTriggerEnter(Collider c) {
        if (c.CompareTag("Player")) {
          found = true;
          gameObject.SetActive(false);
          gameManager.GetComponent<GameManagerScript2>().UpdateParts();
        }
    }
}

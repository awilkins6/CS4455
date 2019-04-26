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

    void OnCollisionEnter(Collision c) {
      if (c.gameObject.CompareTag("Player")) {
        gameManager.GetComponent<GameManagerScript2>().playJingle();
        found = true;
        gameManager.GetComponent<GameManagerScript2>().UpdateParts();
        gameObject.SetActive(false);
      }
    }
}

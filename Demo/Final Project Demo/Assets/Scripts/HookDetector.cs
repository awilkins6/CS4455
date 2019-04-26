using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookDetector : MonoBehaviour {

    public GameObject player;

    void Start() {
      player = GameObject.FindWithTag("Player");
    }

    private void OnCollisionEnter(Collision c) {
        ContactPoint contact = c.contacts[0];
        player.GetComponent<GrappleController>().Hook(c.gameObject);
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.position = contact.point;
    }
}

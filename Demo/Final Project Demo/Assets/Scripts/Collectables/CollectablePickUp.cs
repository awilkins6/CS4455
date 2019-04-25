using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class to remove stone from game when collider is triggered
public class CollectablePickUp : MonoBehaviour
{
	public int temp;
	private bool first = true;
	public AudioSource pickUpSound;

    // When collider is triggered, remove parent game object from game
    void OnTriggerEnter(Collider c) {
        if (c.CompareTag("Player")) {
	        this.transform.parent.gameObject.SetActive(false);

	        // Increment the number of points collected
	        if (first) {
	        	CurrencyScript.currency += 1;
	        	GameManagerScript2.toggleMoney();
	        }

	        first = false;
				}
    }
}

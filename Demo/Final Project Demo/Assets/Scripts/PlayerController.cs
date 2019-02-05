using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private Rigidbody rb;

	public float speed;

	public float jumpPower;

	public GameObject bullet;
	public Transform bulletSpawn;

	public float fireRate;
	private float nextFire;

    void Start() {
    	rb = GetComponent<Rigidbody>();
    }

    void update() {
    	if (Input.GetButton("Fire1") && Time.time > nextFire) {
    		nextFire = Time.time + fireRate;
    		Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
    	}
    }

    void FixedUpdate() {
    	float moveHorizontal = Input.GetAxis("Horizontal");
    	float moveVertical = Input.GetAxis("Vertical");

    	Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

    	rb.AddForce(movement * speed);

    	updateJump();
    }

    // void updateShoot() {
    // 	Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
    // }

  //   void updateHook() {
  //   	if (Input.GetKeyDown("z")) {
			
		// }
  //   }

    void updateJump() {
    	if (Input.GetKeyDown("space")) {
			Vector3 movement = new Vector3(0.0f, 1.0f, 0.0f);
			rb.AddForce(movement * jumpPower);
		}
    }
}

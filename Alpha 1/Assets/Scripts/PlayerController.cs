using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private Rigidbody rb;

	public float speed;

	public float jumpPower;
    private bool grounded;

	public GameObject bullet;
	public Transform bulletSpawn;

	public float fireRate;
	private float nextFire;
	public float turnSpeed = 0.25f;

    public GameObject camera;
    public GameObject costume;
    public float costumeSwingFactor = 0.9f;

    [SerializeField]
    public Transform turretPrefab;


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

    	Vector3 movement =  camera.transform.rotation * new Vector3 (moveHorizontal, 0.0f, moveVertical);

    	rb.AddForce(movement * speed);


        costume.transform.position = Vector3.Lerp(costume.transform.position, transform.position, costumeSwingFactor);


        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("space");
            if (grounded) {
                grounded = false;
                rb.AddForce(Vector3.up * jumpPower);
                Debug.Log("jump!");
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("spawn turret!");
            Object.Instantiate(turretPrefab, transform.position + camera.transform.rotation * Vector3.forward * 2f, camera.transform.rotation);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        grounded = true;
    }

    // void updateShoot() {
    // 	Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
    // }

    //   void updateHook() {
    //   	if (Input.GetKeyDown("z")) {

    // }
    //   }

}

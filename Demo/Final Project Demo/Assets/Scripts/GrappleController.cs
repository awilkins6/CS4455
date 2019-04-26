using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleController : MonoBehaviour
{
    public GameObject hook;
    public GameObject hookHolder;
    public GameObject camera;

    public float hookTravelSpeed;
    public float playerTravelSpeed;

    public bool hooked;
    public bool fired;
    public bool clicking = false;

    public GameObject hookedObject;

    public float maxDistance;
    private float currentDistance;

    public Vector3 dir;

    private float timer = 0f;
    private float maxTime = 5f;

    private LineRenderer lr;

    void Start() {
      camera = GameObject.FindWithTag("MainCamera");
      lr = hook.GetComponent<LineRenderer>();
    }

    void Update() {

        if (Input.GetButtonDown("Grapple") && Time.timeScale > 0) {
          if (!fired) {
            GetComponent<PlayerController>().shootHook();
            fired = true;
            dir = camera.transform.forward.normalized;
            timer = maxTime;
            lr.enabled = true;
            hook.SetActive(true);
          }
        }

        if (Input.GetButton("Grapple") && fired) {
          hook.transform.parent = null;
          if (hookedObject) { //sticking
            hook.GetComponent<Rigidbody>().velocity = Vector3.zero;
            //transform.position = Vector3.MoveTowards(transform.position, hook.transform.position, Time.deltaTime * playerTravelSpeed);
            GetComponent<Rigidbody>().AddForce((hook.transform.position - transform.position).normalized * playerTravelSpeed);
            float distanceToHook = Vector3.Distance(transform.position, hook.transform.position);
            // this.GetComponent<Rigidbody>().useGravity = false;
            if (distanceToHook < 1) {
                ReturnHook();
            }
          } else { //shooting
            hook.GetComponent<Rigidbody>().velocity = dir * hookTravelSpeed;
            currentDistance = Vector3.Distance(transform.position, hook.transform.position);
            if (currentDistance >= maxDistance) {
                ReturnHook();
            }

            if (timer < 0) {
              ReturnHook();
            }
          }

          lr.SetPosition(0, transform.position);
          lr.SetPosition(1, hook.transform.position);

          timer -= Time.deltaTime;
        } else {
          if (fired) {
            ReturnHook();
          }
          hook.transform.parent = hookHolder.transform;
          hook.transform.position = hookHolder.transform.position;
        }
    }

    public void ReturnHook() {
        hook.GetComponent<Rigidbody>().velocity = Vector3.zero;
        hook.transform.position = hookHolder.transform.position;
        hook.SetActive(false);
        fired = false;
        hookedObject = null;
        lr.enabled = false;
    }

    public void Hook(GameObject obj) {
        hookedObject = obj;
    }
}

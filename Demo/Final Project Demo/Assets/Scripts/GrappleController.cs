using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleController : MonoBehaviour
{
    public GameObject hook;
    public GameObject hookHolder;
    public GameObject camera;
    // public GameObject

    public float hookTravelSpeed;
    public float playerTravelSpeed;

    public bool hooked;
    public bool fired;
    public bool clicking = false;

    public GameObject hookedObject;

    public float maxDistance;
    private float currentDistance;

    public Vector3 dir;
    // private Vector3 target;
    // private RaycastHit hit;
    // private Ray ray;

    private float timer = 0f;
    private float maxTime = 5f;

    private LineRenderer lr;

    void Start() {
      camera = GameObject.FindWithTag("MainCamera");
      lr = hook.GetComponent<LineRenderer>();
    }

    void Update()
    {
        //firing hook by left clicking mouse

        // clicking = Input.GetMouseButton(0);

        // if (Input.GetMouseButtonDown(0)) {
        //   if (fired) {
        //     fired = false;
        //     ReturnHook();
        //   } else {
        //     // Debug.DrawRay(ray.origin, ray.direction*10, Color.blue, 10f);
        //     // dir = ray.direction.normalized;
        //     // fired = true;
        //     // timer = maxTime;
        //     if (Physics.Raycast(ray, out hit)) {
        //         // Debug.Log("hit!!");
        //         fired = true;
        //         dir = (hit.point - hook.transform.position).normalized;
        //         Debug.DrawRay(hook.transform.position, hit.point - hook.transform.position, Color.green, 10f);
        //         // hookedObject = hit.transform.gameObject;
        //         fired = true;
        //         timer = maxTime;
        //         // Do something with the object that was hit by the raycast.
        //     }
        //   }
        //   // hook.transform.position = hookHolder.transform.position;
        //   hookedObject = null;
        // }

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

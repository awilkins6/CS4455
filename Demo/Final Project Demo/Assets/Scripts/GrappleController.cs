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
    public static bool fired;

    public GameObject hookedObject;

    public float maxDistance;
    private float currentDistance;

    private Vector3 dir;
    private Vector3 target;
    private RaycastHit hit;
    private Ray ray;

    private float timer = 0f;
    private float maxTime = 5f;

    void Start() {
      camera = GameObject.FindWithTag("MainCamera");
    }

    void Update()
    {
        //firing hook by left clicking mouse
        if (Input.GetMouseButtonDown(0))
        {
          if (fired) {
            fired = false;
            ReturnHook();
          } else {
            ray = new Ray(hook.transform.position+camera.transform.forward*2f, camera.transform.forward);
            Debug.DrawRay(ray.origin, ray.direction*10, Color.blue, 10f);
            // dir = ray.direction.normalized;
            // fired = true;
            // timer = maxTime;
            if (Physics.Raycast(ray, out hit)) {
                Debug.Log("hit!!");
                fired = true;
                dir = (hit.point - hook.transform.position).normalized;
                Debug.DrawRay(hook.transform.position, hit.point - hook.transform.position, Color.green, 10f);
                // hookedObject = hit.transform.gameObject;
                fired = true;
                timer = maxTime;
                // Do something with the object that was hit by the raycast.
            }
          }
          // hook.transform.position = hookHolder.transform.position;
          hookedObject = null;
        }

        if (fired) {
          hook.transform.parent = null;
          if (hookedObject) {
            //transform.position = Vector3.MoveTowards(transform.position, hook.transform.position, Time.deltaTime * playerTravelSpeed);
            GetComponent<Rigidbody>().AddForce((hook.transform.position - transform.position).normalized * playerTravelSpeed);
            float distanceToHook = Vector3.Distance(transform.position, hook.transform.position);

            // this.GetComponent<Rigidbody>().useGravity = false;

            if (distanceToHook < 1) {
                ReturnHook();
            }
          } else {
            // this.GetComponent<Rigidbody>().useGravity = true;
            hook.transform.position += (dir * Time.deltaTime * hookTravelSpeed);
            currentDistance = Vector3.Distance(transform.position, hook.transform.position);
            if (currentDistance >= maxDistance) {
                ReturnHook();
            }
          }
          timer -= Time.deltaTime;
          if (timer < 0) {
            ReturnHook();
          }
        } else {
          hook.transform.parent = hookHolder.transform;
        }
    }

    public void ReturnHook() {
        hook.transform.position = hookHolder.transform.position;
        fired = false;
        hookedObject = null;
    }

    public void Hook(GameObject obj) {
        hookedObject = obj;
    }
}
